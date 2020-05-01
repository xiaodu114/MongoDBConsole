using DDZ.MongoDBConsole.DB;
using DDZ.MongoDBConsole.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.Test
{
    public class QueryModel3Test
    {
        public static string Test1()
        {
            // ((1|2)&3)|((1&2&4)|5)
            QueryModel3 queryModel = new QueryModel3()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel3>()
                {
                    new QueryModel3()
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
                    new QueryModel3()
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
            var filter = QueryModel3Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test2()
        {
            //(1&((2&3&4&5)|6|7))|8
            QueryModel3 queryModel = new QueryModel3()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel3>()
                {
                    new QueryModel3()
                    {
                        QueryModels=new List<QueryModel3>()
                        {
                            new QueryModel3()
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
                            new QueryModel3()
                            {
                                LogicalOperator = LogicalOperatorKind.Or,
                                QueryModels=new List<QueryModel3>()
                                {
                                    new QueryModel3()
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
                                    new QueryModel3()
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
                                    new QueryModel3()
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
                    new QueryModel3()
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
            var filter = QueryModel3Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test3()
        {
            //1&2&3|(1&(4|5))
            QueryModel3 queryModel = new QueryModel3()
            {
                LogicalOperator = LogicalOperatorKind.Or,
                QueryModels = new List<QueryModel3>()
                {
                    new QueryModel3()
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
                    new QueryModel3()
                    {
                        QueryModels= new List<QueryModel3>()
                        {
                            new QueryModel3()
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
                            new QueryModel3()
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
            var filter = QueryModel3Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }

        public static string Test4()
        {
            // { "$and" : [{ "AppCode" : "OperationControlCooperation" }, { "BusinessModuleId" : "1c9adc31-8587-11e8-8d4d-00155d0a1925" }, { "GroupCode" : "1c9adc31-8587-11e8-8d4d-00155d0a1925" }, { "OrganizationId" : "53305584107157536" }, { "SceneCode" : "53305584107157536" }, { "SceneType" : "Organization" }, { "ModelId" : "333517087378771968" }, { "CreateUserId" : "129034539499524096" }, { "FormValues" : { "$elemMatch" : { "key" : "1531120324893", "value" : /00/i } } }, { "FormValues" : { "$elemMatch" : { "key" : "1531120511867", "value" : { "$ne" : "", "$gte" : "2020-04-01 17:37:05 00:00" } } } }, { "FormValues" : { "$elemMatch" : { "key" : "1531120511867", "value" : { "$ne" : "", "$lte" : "2020-04-24 17:37:09 23:59" } } } }] }
            QueryModel3 queryModel = new QueryModel3()
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
            var filter = QueryModel3Helper<BsonDocument>.ToMongodbFilter(queryModel);
            return MongodbHelper.FilterDefinitionToJsonString(filter);
        }
    }
}
