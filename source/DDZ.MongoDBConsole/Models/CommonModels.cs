using System;
using System.Collections.Generic;
using System.Text;

namespace DDZ.MongoDBConsole.Models
{
    /// <summary>
    /// 逻辑操作符：and、or
    /// </summary>
    public enum LogicalOperatorKind
    {
        And = 1,
        Or = 2
    }

    /// <summary>
    /// 查询操作符
    /// </summary>
    public enum QueryOperatorKind
    {
        /// <summary>
        /// 等于
        /// </summary>
        EQ = 1,

        /// <summary>
        /// 不等
        /// </summary>
        NE = 2,

        /// <summary>
        /// 模糊查询
        /// </summary>
        LIKE = 3,

        /// <summary>
        /// 大于
        /// </summary>
        GT = 4,

        /// <summary>
        /// 大于等于
        /// </summary>
        GTE = 5,

        /// <summary>
        /// 小于
        /// </summary>
        LT = 6,

        /// <summary>
        /// 小于等于
        /// </summary>
        LTE = 7,

        /// <summary>
        /// 在范围内
        /// </summary>
        IN = 8,

        /// <summary>
        /// 不在范围内
        /// </summary>
        NIN = 9,

        /// <summary>
        /// 全部包含
        /// </summary>
        ALL = 10
    }

    /// <summary>
    /// 查询的值:数据类型
    /// </summary>
    public enum QueryValueKind
    {
        Boolean = 1,

        Number = 2,

        String = 3,

        DateTime = 4,

        NULL = 5,

        Object = 6,

        Array = 7
    }

    /// <summary>
    /// 查询的值:查询操作
    /// </summary>
    public class QueryFactorOperator
    {
        public object Value { get; set; }

        public QueryOperatorKind QueryOperator { get; set; } = QueryOperatorKind.EQ;
    }

    /// <summary>
    /// 查询因子，最小的查询单位
    /// </summary>
    public class QueryFactor
    {
        public string Key { get; set; }
        public QueryValueKind ValueKind { get; set; }
        public List<QueryFactorOperator> ValueOperators { get; set; }
    }

    /// <summary>
    /// 最小的查询单元
    /// 满足 $elemMatch 查询
    /// </summary>
    public class QueryUnit
    {
        /// <summary>
        /// 如果该值存在，则 List<QueryFactor> Factors 之间是 and 的关系
        /// </summary>
        public string ElemMatchName { get; set; }

        public LogicalOperatorKind LogicalOperator { get; set; } = LogicalOperatorKind.And;

        public List<QueryFactor> Factors { get; set; }
    }
}
