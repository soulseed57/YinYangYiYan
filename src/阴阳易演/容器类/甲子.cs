namespace 阴阳易演.容器类
{
    using 引用库;
    using 抽象类;
    using 查询类;

    public class 甲子
    {
        void 初始化(甲子表.甲子枚举 枚)
        {
            var 枚举名 = 枚.ToString();
            名称 = 枚举名;
            枚举 = 枚;
            序数 = 枚举转换类<甲子表.甲子枚举>.获取序数(枚);
            天干 = 干支表.天干查询(枚举名.Substring(0, 1));
            地支 = 干支表.地支查询(枚举名.Substring(1, 1));
            纳音 = 纳音表.甲子纳音查询(枚举名);
        }
        public 甲子(天干 干, 地支 支)
        {
            var 枚举名 = 常用方法.获取类名(干) + 常用方法.获取类名(支);
            var 枚 = 枚举转换类<甲子表.甲子枚举>.获取枚举(枚举名);
            初始化(枚);
        }
        public 甲子(甲子表.甲子枚举 枚)
        {
            初始化(枚);
        }

        public string 名称 { get; private set; }
        public 甲子表.甲子枚举 枚举 { get; private set; }
        public int 序数 { get; private set; }
        public 天干 天干 { get; private set; }
        public 地支 地支 { get; private set; }
        public string 纳音 { get; private set; }
    }
}
