using DDZ.MongoDBConsole.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.DB
{
    public class QueryModel2Helper<T>
    {
        public static FilterDefinition<T> ToMongodbFilter(QueryModel2 queryModel)
        {
            return ToMongodbFilter2(queryModel.StrFilter, queryModel.KeyValues, new Dictionary<string, FilterDefinition<T>>());
        }

        private static FilterDefinition<T> ToMongodbFilter2(string filterStr, Dictionary<string, QueryUnit> keyValues, Dictionary<string, FilterDefinition<T>> dicFilterDefinition)
        {
            int startIndex = filterStr.LastIndexOf("(");
            if (startIndex != -1)
            {
                //  截取括号中的表达式
                int endIndex = filterStr.IndexOf(")", startIndex);
                int len = endIndex - startIndex - 1;
                string simpleExpress = filterStr.Substring(startIndex + 1, len);
                //  处理简单的表达式并结果保存到字典中
                string tempGuid = Guid.NewGuid().ToString();
                FilterDefinition<T> fd1 = HandleSimpleExpression(simpleExpress, keyValues, dicFilterDefinition);
                dicFilterDefinition.Add(tempGuid, fd1);
                //  继续处理剩余表达式
                string leftStr = filterStr.Substring(0, startIndex);
                string rightStr = filterStr.Substring(endIndex + 1);
                return ToMongodbFilter2($"{leftStr}{tempGuid}{rightStr}", keyValues, dicFilterDefinition);
            }
            return HandleSimpleExpression(filterStr, keyValues, dicFilterDefinition);
        }

        private static FilterDefinition<T> HandleSimpleExpression(string filterStr, Dictionary<string, QueryUnit> keyValues, Dictionary<string, FilterDefinition<T>> dicFilterDefinition)
        {
            //  1、筛选出操作符：&、|
            Queue<char> qOperator = new Queue<char>();
            //Regex regexOperator = new Regex("[&|]");
            //foreach (Match item in regexOperator.Matches(logicalExpression))
            //{
            //    qOperator.Enqueue(item.Value);
            //}
            foreach (char c in filterStr)
            {
                if (c == '&' || c == '|')
                {
                    qOperator.Enqueue(c);
                }
            }
            //  2、筛选出所有的变量
            Queue<string> qVariable = new Queue<string>();
            string[] tempVariables = filterStr.Replace("&", ",").Replace("|", ",").Split(",");
            foreach (string v in tempVariables)
            {
                qVariable.Enqueue(v);
            }
            //  3、返回结果组装
            FilterDefinition<T> filter = null;
            if (qVariable.Count >= 1)
            {
                string tempV = qVariable.Dequeue();
                filter = dicFilterDefinition.ContainsKey(tempV) ? dicFilterDefinition[tempV] : MongodbHelper.HandleQueryUnitModel<T>(keyValues[tempV]);
                while (qVariable.Count > 0)
                {
                    string rightV = qVariable.Dequeue();
                    var tempFilter = dicFilterDefinition.ContainsKey(rightV) ? dicFilterDefinition[rightV] : MongodbHelper.HandleQueryUnitModel<T>(keyValues[rightV]);
                    char tempOperator = qOperator.Dequeue();
                    switch (tempOperator)
                    {
                        case '&':
                            {
                                filter &= tempFilter;
                                break;
                            }
                        case '|':
                            {
                                filter |= tempFilter;
                                break;
                            }
                    }
                }
                filter = Builders<T>.Filter.Empty & (filter);
            }
            return filter ?? Builders<T>.Filter.Empty;
        }
    }
}
