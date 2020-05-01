using DDZ.MongoDBConsole.DB;
using DDZ.MongoDBConsole.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.Test
{
    public class QueryModel2Test
    {
        public static string Test1()
        {
            QueryModel2 qm = new QueryModel2
            {
                StrFilter = "((1|2)&3)|((1&2&4)|5)",
                KeyValues = new Dictionary<string, QueryUnit>()
                {
                    { "1",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_1", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_1_value" } } } } } },
                    { "2",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_2", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_2_value" } } } } } },
                    { "3",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_3", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_3_value" } } } } } },
                    { "4",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_4", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_4_value" } } } } } },
                    { "5",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_5", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_5_value" } } } } } },
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(qm);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test2()
        {
            QueryModel2 qm = new QueryModel2
            {
                StrFilter = "(1&((2&3&4&5)|6|7))|8",
                KeyValues = new Dictionary<string, QueryUnit>()
                {
                    { "1",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_1", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_1_value" } } } } } },
                    { "2",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_2", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_2_value" } } } } } },
                    { "3",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_3", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_3_value" } } } } } },
                    { "4",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_4", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_4_value" } } } } } },
                    { "5",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_5", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_5_value" } } } } } },
                    { "6",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_6", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_6_value" } } } } } },
                    { "7",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_7", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_7_value" } } } } } },
                    { "8",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_8", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_8_value" } } } } } },
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(qm);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test3()
        {
            QueryModel2 qm = new QueryModel2
            {
                StrFilter = "1&2&3|(1&(4|5))",
                KeyValues = new Dictionary<string, QueryUnit>()
                {
                    { "1",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_1", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_1_value" } } } } } },
                    { "2",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_2", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_2_value" } } } } } },
                    { "3",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_3", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_3_value" } } } } } },
                    { "4",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_4", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_4_value" } } } } } },
                    { "5",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_5", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_5_value" } } } } } },
                    { "6",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_6", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_6_value" } } } } } },
                    { "7",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "col_7", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "col_7_value" } } } } } },
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(qm);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test4()
        {
            QueryModel2 qm = new QueryModel2
            {
                StrFilter = "1&2&3&4&5",
                KeyValues = new Dictionary<string, QueryUnit>()
                {
                    { "1",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "FormId", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "CarInfo" } } } } } },
                    { "2",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "Level1", ValueOperators=new List<QueryFactorOperator>() { new QueryFactorOperator() { Value= "Apple" } } } } } },
                    { "3",new QueryUnit(){ Factors=new List<QueryFactor>(){ new QueryFactor() { Key= "CreateDate", ValueOperators=new List<QueryFactorOperator>()
                                {
                                    new QueryFactorOperator(){ Value="2010-01-01", QueryOperator=QueryOperatorKind.GTE },
                                    new QueryFactorOperator(){ Value="2020-12-31", QueryOperator=QueryOperatorKind.LTE }
                                }} } } },
                    { "4", new QueryUnit()
                           {
                                ElemMatchName="FormValues",
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="key",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="key1" }
                                        }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="value",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="", QueryOperator=QueryOperatorKind.NE },
                                            new QueryFactorOperator(){ Value="2020", QueryOperator=QueryOperatorKind.LTE }
                                        }
                                    }
                                }
                           }
                    },
                    { "5", new QueryUnit()
                           {
                                ElemMatchName="FormValues",
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="key",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="key2" }
                                        }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="value",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="2000", QueryOperator=QueryOperatorKind.GTE },
                                            new QueryFactorOperator(){ Value="2020", QueryOperator=QueryOperatorKind.LTE }
                                        }
                                    }
                                }
                           }
                    }
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(qm);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }
    }
}
