namespace 阴阳易演.容器类
{
    public class 宫
    {
        public 宫(string 名, 甲子 位)
        {
            名称 = 名;
            宫位 = 位;
        }
        public string 名称 { get; }
        public 甲子 宫位 { get; }
    }
}