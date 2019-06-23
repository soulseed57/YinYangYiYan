using System;

namespace 阴阳释义
{
    using Antlr4.Runtime;
    using Grammar;

    class Program
    {
        static void Main(string[] args)
        {
            string input = @"5 对应地支取1,五行为.";

            var stream = new AntlrInputStream(input);
            var lexer = new UniverseChangesParaphraseLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new UniverseChangesParaphraseParser(tokens);
            var tree = parser.program();

            var visitor = new UniverseChangesParaphraseVisitor();
            var result = visitor.Visit(tree);

            Console.WriteLine($"树状图:{tree.ToStringTree(parser)}");
            Console.WriteLine($"计算结果:{result}");
            Console.ReadKey();
        }
    }
}
