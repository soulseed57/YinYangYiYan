using 阴阳易演.抽象类;

namespace 阴阳易演.容器类
{
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
        public string 名称 { get; }
        public string 干支 { get; }
        public string 纳音 { get; }
        public 天干 天干 { get; }
        public 地支 地支 { get; }
    }
}