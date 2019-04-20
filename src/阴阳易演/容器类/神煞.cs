namespace 阴阳易演.容器类
{
    using System;
    using 引用库;
    using 枚举类;
    using 查询类;

    public class 神煞
    {
        #region 构造
        void 初始化(神煞枚举 枚)
        {
            名称 = 枚举转换类<神煞枚举>.获取名称(枚);
            枚举 = 枚;
            序数 = 枚举转换类<神煞枚举>.获取序数(枚);
            switch (枚)
            {
                case 神煞枚举.青龙:
                    黄道吉日 = true;
                    论断 = "消息吉。青龙黄道，天乙星，天贵星，利有攸往，所作必成，所求皆得。";
                    break;
                case 神煞枚举.天德:
                    黄道吉日 = true;
                    论断 = "官贵吉。天德黄道，宝光星，天德星，其时大郭，作事有成，利有攸往，出行吉。";
                    break;
                case 神煞枚举.玉堂:
                    黄道吉日 = true;
                    论断 = "玉堂黄道，少微星，天开星，百事吉，求事成，出行有财，宜文书喜庆之事，利见大人，利安葬，不利泥灶。";
                    break;
                case 神煞枚举.司命:
                    黄道吉日 = true;
                    论断 = "官长吉。司命黄道，凤辇星，月仙星，此时从寅至申时用事大吉，从酉至丑时有事不吉，即白天吉，晚上不利。";
                    break;
                case 神煞枚举.明堂:
                    黄道吉日 = true;
                    论断 = "明堂黄道，贵人星，明辅星，利见大人，利有攸往，怕作必成。";
                    break;
                case 神煞枚举.金匮:
                    黄道吉日 = true;
                    论断 = "财星吉。金匮黄道，福德星，月仙星，利释道用事，阍者女子用事，吉；宜嫁娶，不宜整戎伍。";
                    break;

                case 神煞枚举.天刑:
                    黄道吉日 = false;
                    论断 = "驿马强动。天刑黑道，天刑星，利于出师，战无不克，其他动作谋为皆不宜用，大忌词讼。";
                    break;
                case 神煞枚举.朱雀:
                    黄道吉日 = false;
                    论断 = "口舌。朱雀黑道，天讼星，利用公事，常人凶，诸事忌用，谨防争讼。";
                    break;
                case 神煞枚举.白虎:
                    黄道吉日 = false;
                    论断 = "口舌官非。白虎黑道，天杀星，宜出师畋猎祭祀，皆吉，其余都不利。";
                    break;
                case 神煞枚举.天牢:
                    黄道吉日 = false;
                    论断 = "凶星宜忌。天牢黑道，镇神星，阴人用事皆吉，其余都不利。";
                    break;
                case 神煞枚举.玄武:
                    黄道吉日 = false;
                    论断 = "内小人盗贼暗害。玄武黑道，天狱星，君子用之吉，小人用之凶，忌词讼博戏。";
                    break;
                case 神煞枚举.勾陈:
                    黄道吉日 = false;
                    论断 = "口舌牵连。勾陈黑道，地狱星，此时所作一切事，有始无终，先喜后悲，不利攸往；起造安葬，犯此不利。";
                    break;
                default:
                    throw new Exception($"输入的枚举不是神煞枚举,当前输入:{枚}");
            }
        }
        public 神煞(int 数)
        {
            var 枚 = 十二神煞表.获取神煞枚举(数);
            初始化(枚);
        }
        public 神煞(神煞枚举 枚)
        {
            初始化(枚);
        }

        #endregion

        #region 属性
        public string 名称 { get; private set; }
        public 神煞枚举 枚举 { get; private set; }
        public int 序数 { get; private set; }
        public bool 黄道吉日 { get; private set; }
        public string 论断 { get; private set; }

        #endregion

    }
}
