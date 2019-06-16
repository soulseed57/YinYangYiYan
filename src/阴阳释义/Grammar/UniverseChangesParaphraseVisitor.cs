namespace 阴阳释义.Grammar
{
    public class UniverseChangesParaphraseVisitor : UniverseChangesParaphraseBaseVisitor<object>
    {
        public override object VisitMap(UniverseChangesParaphraseParser.MapContext context)
        {
            object left = context;
            return base.VisitMap(context);
        }

        public override object VisitAs(UniverseChangesParaphraseParser.AsContext context)
        {
            object left = Visit(context.expression(0));
            return base.VisitAs(context);
        }
    }
}