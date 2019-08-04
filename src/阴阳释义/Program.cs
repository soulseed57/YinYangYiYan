namespace 阴阳释义
{
    using System;
    using Visitor;

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                var result = InputVisitor.Visit(input, out var tree);
                Console.WriteLine($"树状图:{tree}");
                Console.WriteLine($"计算结果:{result}");
            }

        }
    }
}
