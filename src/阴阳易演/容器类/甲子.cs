namespace 阴阳易演.容器类
{
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 查询类;
    using 计算类;

    public class 甲子
    {
        #region 构造
        void 初始化(甲子枚举 枚)
        {
            名称 = 枚举转换类<甲子枚举>.获取名称(枚);
            枚举 = 枚;
            序数 = 枚举转换类<甲子枚举>.获取序数(枚);
            天干 = 干支表.天干查询(名称.Substring(0, 1));
            地支 = 干支表.地支查询(名称.Substring(1, 1));
            阴阳 = 地支.阴阳;
            纳音 = new 纳音(枚);
            十二长生 = 十二长生表.长生查询(天干, 地支);
            天干配卦 = 天干.天干配卦();
            地支配卦 = 地支.地支配卦();
            六十四卦 = new 六十四卦(天干配卦, 地支配卦);
        }
        public 甲子(天干 干, 地支 支)
        {
            var 枚举名 = 干.名称 + 支.名称;
            var 枚 = 枚举转换类<甲子枚举>.获取枚举(枚举名);
            初始化(枚);
        }
        public 甲子(甲子枚举 枚)
        {
            初始化(枚);
        }
        public 甲子(string 名)
        {
            var 枚 = 枚举转换类<甲子枚举>.获取枚举(名);
            初始化(枚);
        }
        public 甲子(int 数)
        {
            var 甲子数 = 枚举转换类<甲子枚举>.获取枚举总数();
            var 序 = 常用方法.序数取余(数, 甲子数);
            var 枚 = 枚举转换类<甲子枚举>.获取枚举(序);
            初始化(枚);
        }

        #endregion

        #region 属性
        public string 名称 { get; private set; }
        public 甲子枚举 枚举 { get; private set; }
        public int 序数 { get; private set; }
        public 天干 天干 { get; private set; }
        public 地支 地支 { get; private set; }
        public 两仪 阴阳 { get; private set; }
        public 纳音 纳音 { get; private set; }
        public 长生枚举 十二长生 { get; private set; }
        public 八卦 天干配卦 { get; private set; }
        public 八卦 地支配卦 { get; private set; }
        public 六十四卦 六十四卦 { get; private set; }

        #endregion

    }
}
