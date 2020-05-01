using DDZ.MongoDBConsole.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DDZ.MongoDBConsole.DB
{
    public class MongodbHelper
    {
        public static string FilterDefinitionToJsonString<T>(FilterDefinition<T> filterDefinition)
        {
            if (filterDefinition == null) return null;
            return filterDefinition.Render(BsonSerializer.SerializerRegistry.GetSerializer<T>(), BsonSerializer.SerializerRegistry).ToString();
        }

        public static string FilterDefinitionToJsonString<T>(IMongoCollection<T> conn, FilterDefinition<T> filterDefinition)
        {
            if (filterDefinition == null) return null;
            return filterDefinition.Render(conn.DocumentSerializer, conn.Settings.SerializerRegistry).ToString();
        }

        public static FilterDefinition<T> ToMogodbFilter<T>(QueryOperatorKind operatorType, string key, object value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            FilterDefinition<T> filter = null;
            switch (operatorType)
            {
                case QueryOperatorKind.NE:
                    {
                        filter = Builders<T>.Filter.Ne(key, value);
                        break;
                    }
                case QueryOperatorKind.LIKE:
                    {
                        if (value == null || string.IsNullOrEmpty(value.ToString())) throw new ArgumentException("OperatorType.LIKE时，value需要有具体值");
                        filter = Builders<T>.Filter.Regex(key, new BsonRegularExpression(new Regex(".*" + Regex.Escape(value.ToString()) + ".*", RegexOptions.IgnoreCase)));
                        break;
                    }
                case QueryOperatorKind.GT:
                    {
                        filter = Builders<T>.Filter.Gt(key, value);
                        break;
                    }
                case QueryOperatorKind.GTE:
                    {
                        filter = Builders<T>.Filter.Gte(key, value);
                        break;
                    }
                case QueryOperatorKind.LT:
                    {
                        filter = Builders<T>.Filter.Lt(key, value);
                        break;
                    }
                case QueryOperatorKind.LTE:
                    {
                        filter = Builders<T>.Filter.Lte(key, value);
                        break;
                    }
                case QueryOperatorKind.IN:
                    {
                        filter = Builders<T>.Filter.In(key, JsonSerializer.Deserialize<IList<String>>(JsonSerializer.Serialize(value)));
                        break;
                    }
                case QueryOperatorKind.NIN:
                    {
                        filter = Builders<T>.Filter.Nin(key, JsonSerializer.Deserialize<IList<object>>(JsonSerializer.Serialize(value)));
                        break;
                    }
                case QueryOperatorKind.ALL:
                    {
                        filter = Builders<T>.Filter.All(key, JsonSerializer.Deserialize<IList<object>>(JsonSerializer.Serialize(value)));
                        break;
                    }
                case QueryOperatorKind.EQ:
                default:
                    {
                        filter = Builders<T>.Filter.Eq(key, value);
                        break;
                    }
            }
            return filter ?? Builders<T>.Filter.Empty;
        }

        public static FilterDefinition<T> HandleQueryUnitModel<T>(QueryUnit queryUnit)
        {
            if (queryUnit == null) throw new ArgumentNullException("queryUnit");
            if (queryUnit.Factors == null || !queryUnit.Factors.Any()) throw new ArgumentException("queryUnit.Factors至少包含一项");

            List<FilterDefinition<T>> factorFilters = new List<FilterDefinition<T>>();
            foreach (var factorItem in queryUnit.Factors)
            {
                if (factorItem.ValueOperators == null || !factorItem.ValueOperators.Any()) continue;
                List<FilterDefinition<T>> minFilters = new List<FilterDefinition<T>>();
                foreach (var minItem in factorItem.ValueOperators)
                {
                    minFilters.Add(ToMogodbFilter<T>(minItem.QueryOperator, factorItem.Key, minItem.Value));
                }
                if (minFilters.Count == 1)
                {
                    factorFilters.Add(minFilters[0]);
                }
                else
                {
                    factorFilters.Add(Builders<T>.Filter.And(minFilters));
                }
            }

            if (!factorFilters.Any()) return Builders<T>.Filter.Empty;

            if (!string.IsNullOrEmpty(queryUnit.ElemMatchName))
            {
                return Builders<T>.Filter.ElemMatch(queryUnit.ElemMatchName, Builders<T>.Filter.And(factorFilters));
            }

            return HandleFilterDefinitions(factorFilters, queryUnit.LogicalOperator);
        }

        public static FilterDefinition<T> HandleFilterDefinitions<T>(List<FilterDefinition<T>> filterDefinitions, LogicalOperatorKind operatorKind)
        {
            if (filterDefinitions == null) throw new ArgumentNullException("filterDefinitions");

            if (!filterDefinitions.Any()) return Builders<T>.Filter.Empty;

            if (filterDefinitions.Count == 1)
            {
                return filterDefinitions[0];
            }

            switch (operatorKind)
            {
                case LogicalOperatorKind.Or:
                    {
                        return Builders<T>.Filter.Or(filterDefinitions);
                    }
                case LogicalOperatorKind.And:
                default:
                    {
                        return Builders<T>.Filter.And(filterDefinitions);
                    }
            }
        }
    }
}
