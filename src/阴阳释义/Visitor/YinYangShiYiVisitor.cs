namespace 阴阳释义.Visitor
{
    using Grammar;
    using System;
    using 阴阳易演.查询类;

    public class YinYangShiYiVisitor : YinYangShiYiBaseVisitor<object>
    {

        /// <summary>
        /// ('天干'|'地支')为
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitEarthBranchAs(YinYangShiYiParser.EarthBranchAsContext context)
        {
            var node = Visit(context);
            var opt = context.Stop.Text;
            /**
             * todo
             * '(' expr ')' '为' 会匹配到所有带括号表达式,这不对,需要强匹配'为'运算符
             */

            try
            {
                var txt = node as string;
                if (干支表.天干列表.Exists(t => t.名称 == txt))
                {
                    var 天干 = 干支表.天干查询(txt);
                    return 天干.五行.名称;
                }
                if (干支表.地支列表.Exists(t => t.名称 == txt))
                {
                    var 地支 = 干支表.地支查询(txt);
                    return 地支.五行.名称;
                }
                throw new Exception($"未找到对象[{txt}]匹配的操作");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}