using DDZ.MongoDBConsole.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDZ.MongoDBConsole.DB
{
    public class QueryModel2Helper<T>
    {
        public static FilterDefinition<T> ToMongodbFilter(QueryModel2 queryModel)
        {
            if (queryModel.QueryUnits != null && queryModel.QueryUnits.Any())
            {
                List<FilterDefinition<T>> unitFilters = new List<FilterDefinition<T>>();
                foreach (var unitItem in queryModel.QueryUnits)
                {
                    var unitFilter = MongodbHelper.HandleQueryUnitModel<T>(unitItem);
                    if (unitFilter != null)
                    {
                        unitFilters.Add(unitFilter);
                    }
                }

                return MongodbHelper.HandleFilterDefinitions(unitFilters, queryModel.LogicalOperator);
            }
            else
            {
                var filter = Builders<T>.Filter.Empty;
                if (queryModel.QueryModels == null || !queryModel.QueryModels.Any()) return filter;

                List<FilterDefinition<T>> queryModelFilters = new List<FilterDefinition<T>>();
                foreach (var queryModel2Item in queryModel.QueryModels)
                {
                    queryModelFilters.Add(ToMongodbFilter(queryModel2Item));
                }

                return MongodbHelper.HandleFilterDefinitions(queryModelFilters, queryModel.LogicalOperator);
            }
        }
    }
}
