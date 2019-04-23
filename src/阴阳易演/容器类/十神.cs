namespace 阴阳易演.容器类
{
    using System;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 计算类;

    public class 十神
    {
        #region 构造
        public 十神(天干 主, 天干 客)
        {
            var 同性 = 主.阴阳 == 客.阴阳;
            var 主五行 = 主.五行;
            var 客五行 = 客.五行;
            if (主五行.生我() == 客五行)
            {
                枚举 = 同性 ? 十神枚举.偏印 : 十神枚举.正印;
            }
            if (主五行.我生() == 客五行)
            {
                枚举 = 同性 ? 十神枚举.食神 : 十神枚举.伤官;
            }
            if (主五行.克我() == 客五行)
            {
                枚举 = 同性 ? 十神枚举.偏官 : 十神枚举.正官;
            }
            if (主五行.我克() == 客五行)
            {
                枚举 = 同性 ? 十神枚举.偏财 : 十神枚举.正财;
            }
            if (主五行.同我() == 客五行)
            {
                枚举 = 同性 ? 十神枚举.比肩 : 十神枚举.劫财;
            }
            名称 = 枚举转换类<十神枚举>.获取名称(枚举);
            简称 = 查询简称(枚举);
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public string 简称 { get; }
        public 十神枚举 枚举 { get; }

        #endregion

        #region 方法
        public static string 查询简称(十神枚举 枚)
        {
            switch (枚)
            {
                case 十神枚举.正官:
                    return "官";
                case 十神枚举.偏官:
                    return "杀";
                case 十神枚举.正印:
                    return "印";
                case 十神枚举.偏印:
                    return "枭";
                case 十神枚举.劫财:
                    return "劫";
                case 十神枚举.比肩:
                    return "比";
                case 十神枚举.伤官:
                    return "伤";
                case 十神枚举.食神:
                    return "食";
                case 十神枚举.正财:
                    return "财";
                case 十神枚举.偏财:
                    return "才";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

    }
}