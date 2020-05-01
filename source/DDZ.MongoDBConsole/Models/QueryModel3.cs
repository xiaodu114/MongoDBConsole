using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.Models
{
    public class QueryModel3
    {
        /// <summary>
        /// 逻辑操作符：and、or
        /// List<QueryUnit> QueryUnits 之间的逻辑关系
        /// List<QueryModel2> QueryModels 之间的逻辑关系
        /// QueryUnits和QueryModels二者只能存在一个，优先使用QueryUnits
        /// </summary>
        public LogicalOperatorKind LogicalOperator { get; set; } = LogicalOperatorKind.And;

        public List<QueryUnit> QueryUnits { get; set; }

        public List<QueryModel3> QueryModels { get; set; }
    }
}
