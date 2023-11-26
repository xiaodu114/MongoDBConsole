using DDZ.MongoDBConsole.Test;
using System;

namespace DDZ.MongoDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string queryModel1_1 = QueryModel1Test.Test1();
            string queryModel1_2 = QueryModel1Test.Test2();
            string queryModel1_3 = QueryModel1Test.Test3();
            string queryModel1_4 = QueryModel1Test.Test4();

            string queryModel2_1 = QueryModel2Test.Test1();
            string queryModel2_2 = QueryModel2Test.Test2();
            string queryModel2_3 = QueryModel2Test.Test3();
            string queryModel2_4 = QueryModel2Test.Test4();

            bool b1 = queryModel1_1 == queryModel2_1;
            bool b2 = queryModel1_2 == queryModel2_2;
            bool b3 = queryModel1_3 == queryModel2_3;
            bool b4 = queryModel1_4 == queryModel2_4;

            Console.WriteLine($"测试结果：{b1&b2&b3&b4}");
        }
    }
}
