namespace 阴阳释义.Grammar
{
    using System;
    using System.Linq;
    using Antlr4.Runtime.Misc;
    using 阴阳易演.容器类;
    using 阴阳易演.查询类;

    public class UniverseChangesParaphraseVisitor : UniverseChangesParaphraseBaseVisitor<object>
    {
        /// <summary>
        /// 对应('天干'|'地支'|'五行')
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitHeLuoNumMap(UniverseChangesParaphraseParser.HeLuoNumMapContext context)
        {
            try
            {
                var res = "";
                switch (context.GetChild(1).GetText())
                {
                    case "对应":
                        {
                            var num = int.Parse(context.heluo_expr().GetText());
                            var 河洛数 = new 河洛数(num);
                            switch (context.GetChild(2).GetText())
                            {
                                case "天干":
                                    res = 河洛数.天干.名称;
                                    break;
                                case "地支":
                                    {
                                        var arr = 河洛数.地支.Select(t => t.名称).ToArray();
                                        if (arr.Length > 1)
                                        {
                                            if (context.GetChild(3).GetText() != "取")
                                            {
                                                throw new Exception("返回结果为集合,但是没有指定取哪一个");
                                            }
                                            else
                                            {
                                                if (int.TryParse(context.GetChild(4).GetText(), out var pickNum))
                                                {
                                                    var arrMax = arr.Length;
                                                    var index = pickNum - 1;
                                                    if (index < 0 || index >= arrMax)
                                                    {
                                                        throw new Exception($"取数[{pickNum}]超限,当前集合最大值为[{arrMax}]");
                                                    }
                                                    else
                                                    {
                                                        res = arr[index];
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("取数不是合法数字");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            res = arr[0];
                                        }
                                    }
                                    break;
                                case "五行":
                                    res = 河洛数.五行.名称;
                                    break;
                            }
                        }
                        break;
                }
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override object VisitEarthBranchInit([NotNull] UniverseChangesParaphraseParser.EarthBranchInitContext context)
        {
            return base.VisitEarthBranchInit(context);
        }

        /// <summary>
        /// ('天干'|'地支')为
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitEarthBranchAs(UniverseChangesParaphraseParser.EarthBranchAsContext context)
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