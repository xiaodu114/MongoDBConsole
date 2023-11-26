using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.Models
{
    public class QueryModel1
    {
        public string StrFilter { get; set; }

        /// <summary>
        /// 这里使用 QueryUnit，而并非 QueryFactor
        /// 就是为了实现 mongodb 的 $elemMatch 查询
        /// </summary>
        public Dictionary<string, QueryUnit> KeyValues { get; set; }
    }
}
