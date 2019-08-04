namespace 阴阳释义.Visitor
{
    using Antlr4.Runtime;
    using Grammar;

    public class InputVisitor
    {
        public static object Visit(string input)
        {
            var stream = new AntlrInputStream(input);
            var lexer = new YinYangShiYiLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new YinYangShiYiParser(tokens);
            var tree = parser.program();
            var visitor = new YinYangShiYiVisitor();
            return visitor.Visit(tree);
        }

        public static object Visit(string input, out string stringTree)
        {
            var stream = new AntlrInputStream(input);
            var lexer = new YinYangShiYiLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new YinYangShiYiParser(tokens);
            var tree = parser.program();
            stringTree = tree.ToStringTree(parser);
            var visitor = new YinYangShiYiVisitor();
            return visitor.Visit(tree);
        }

    }
}
