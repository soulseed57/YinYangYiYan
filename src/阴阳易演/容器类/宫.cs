namespace 阴阳易演.容器类
{
    using 抽象类;

    public class 宫
    {
        public 宫(string 名, 甲子 甲)
        {
            名称 = 名;
            干支 = 甲.名称;
            纳音 = 甲.纳音;
            天干 = 甲.天干;
            地支 = 甲.地支;
        }
        public 宫(string 名, 地支 支)
        {
            名称 = 名;
            干支 = null;
            纳音 = null;
            天干 = null;
            地支 = 支;
        }

        public string 名称 { get; }
        public string 干支 { get; }
        public 纳音 纳音 { get; }
        public 天干 天干 { get; }
        public 地支 地支 { get; }

    }
}