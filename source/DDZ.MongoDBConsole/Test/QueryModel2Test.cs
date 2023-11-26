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
            // ((1|2)&3)|((1&2&4)|5)
            QueryModel2 queryModel = new QueryModel2()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel2>()
                {
                    new QueryModel2()
                    {
                        QueryUnits=new List<QueryUnit>()
                        {
                            new QueryUnit()
                            {
                                LogicalOperator=LogicalOperatorKind.Or,
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_1",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_1_value" }
                                        }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="col_2",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_2_value" }
                                        }
                                    }
                                }
                            },
                            new QueryUnit()
                            {
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_3",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_3_value" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new QueryModel2()
                    {
                        LogicalOperator = LogicalOperatorKind.Or,
                        QueryUnits=new List<QueryUnit>()
                        {
                            new QueryUnit()
                            {
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_1",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_1_value" }
                                        }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="col_2",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_2_value" }
                                        }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="col_4",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_4_value" }
                                        }
                                    }
                                }
                            },
                            new QueryUnit()
                            {
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_5",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_5_value" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test2()
        {
            //(1&((2&3&4&5)|6|7))|8
            QueryModel2 queryModel = new QueryModel2()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel2>()
                {
                    new QueryModel2()
                    {
                        QueryModels=new List<QueryModel2>()
                        {
                            new QueryModel2()
                            {
                                QueryUnits=new List<QueryUnit>()
                                {
                                    new QueryUnit()
                                    {
                                        Factors=new List<QueryFactor>()
                                        {
                                            new QueryFactor()
                                            {
                                                Key="col_1",
                                                ValueOperators=new List<QueryFactorOperator>()
                                                {
                                                    new QueryFactorOperator(){ Value="col_1_value" }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new QueryModel2()
                            {
                                LogicalOperator = LogicalOperatorKind.Or,
                                QueryModels=new List<QueryModel2>()
                                {
                                    new QueryModel2()
                                    {
                                        QueryUnits=new List<QueryUnit>()
                                        {
                                            new QueryUnit()
                                            {
                                                Factors=new List<QueryFactor>()
                                                {
                                                    new QueryFactor()
                                                    {
                                                        Key="col_2",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_2_value" }
                                                        }
                                                    },
                                                    new QueryFactor()
                                                    {
                                                        Key="col_3",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_3_value" }
                                                        }
                                                    },
                                                    new QueryFactor()
                                                    {
                                                        Key="col_4",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_4_value" }
                                                        }
                                                    },
                                                    new QueryFactor()
                                                    {
                                                        Key="col_5",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_5_value" }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new QueryModel2()
                                    {
                                        QueryUnits=new List<QueryUnit>()
                                        {
                                            new QueryUnit()
                                            {
                                                Factors=new List<QueryFactor>()
                                                {
                                                    new QueryFactor()
                                                    {
                                                        Key="col_6",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_6_value" }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new QueryModel2()
                                    {
                                        QueryUnits=new List<QueryUnit>()
                                        {
                                            new QueryUnit()
                                            {
                                                Factors=new List<QueryFactor>()
                                                {
                                                    new QueryFactor()
                                                    {
                                                        Key="col_7",
                                                        ValueOperators=new List<QueryFactorOperator>()
                                                        {
                                                            new QueryFactorOperator(){ Value="col_7_value" }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new QueryModel2()
                    {
                        QueryUnits=new List<QueryUnit>()
                        {
                            new QueryUnit()
                            {
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_8",
                                        ValueOperators=new List<QueryFactorOperator>()
                                        {
                                            new QueryFactorOperator(){ Value="col_8_value" }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test3()
        {
            //1&2&3|(1&(4|5))
            QueryModel2 queryModel = new QueryModel2()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel2>()
                {
                    new QueryModel2()
                    {
                        QueryUnits = new List<QueryUnit>()
                        {
                            new QueryUnit()
                            {
                                Factors=new List<QueryFactor>()
                                {
                                    new QueryFactor()
                                    {
                                        Key="col_1",
                                        ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_1_value" } }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="col_2",
                                        ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_2_value" } }
                                    },
                                    new QueryFactor()
                                    {
                                        Key="col_3",
                                        ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_3_value" } }
                                    }
                                }
                            }
                        }
                    },
                    new QueryModel2()
                    {
                        QueryModels= new List<QueryModel2>()
                        {
                            new QueryModel2()
                            {
                                QueryUnits=new List<QueryUnit>()
                                {
                                    new QueryUnit()
                                    {
                                        Factors=new List<QueryFactor>()
                                        {
                                             new QueryFactor()
                                             {
                                                 Key="col_1",
                                                 ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_1_value" } }
                                             },
                                        }
                                    }
                                }
                            },
                            new QueryModel2()
                            {
                                QueryUnits=new List<QueryUnit>()
                                {
                                    new QueryUnit()
                                    {
                                        LogicalOperator=LogicalOperatorKind.Or,
                                        Factors=new List<QueryFactor>()
                                        {
                                             new QueryFactor()
                                             {
                                                 Key="col_4",
                                                 ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_4_value" } }
                                             },
                                             new QueryFactor()
                                             {
                                                 Key="col_5",
                                                 ValueOperators=new List<QueryFactorOperator>(){new QueryFactorOperator(){ Value= "col_5_value" } }
                                             }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test4()
        {
            // { "$and" : [{ "FormId" : "CarInfo" }, { "Level1" : "Apple" }, { "CreateDate" : { "$gte" : "2010-01-01", "$lte" : "2020-12-31" } }, { "FormValues" : { "$elemMatch" : { "key" : "key1", "value" : { "$ne" : "", "$lte" : "2020" } } } }, { "FormValues" : { "$elemMatch" : { "key" : "key2", "value" : { "$gte" : "2000", "$lte" : "2020" } } } }] }
            QueryModel2 queryModel = new QueryModel2()
            {
                QueryUnits = new List<QueryUnit>()
                {
                    new QueryUnit()
                    {
                        Factors=new List<QueryFactor>()
                        {
                            new QueryFactor()
                            {
                                Key="FormId",
                                ValueOperators=new List<QueryFactorOperator>()
                                {
                                    new QueryFactorOperator(){ Value="CarInfo" }
                                }
                            },
                            new QueryFactor()
                            {
                                Key="Level1",
                                ValueOperators=new List<QueryFactorOperator>()
                                {
                                    new QueryFactorOperator(){ Value="Apple" }
                                }
                            },
                            new QueryFactor()
                            {
                                Key="CreateDate",
                                ValueOperators=new List<QueryFactorOperator>()
                                {
                                    new QueryFactorOperator(){ Value="2010-01-01", QueryOperator=QueryOperatorKind.GTE },
                                    new QueryFactorOperator(){ Value="2020-12-31", QueryOperator=QueryOperatorKind.LTE }
                                }
                            }
                        }
                    },
                    new QueryUnit()
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
                    },
                    new QueryUnit()
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
            };
            var filter = QueryModel2Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }
    }
}
