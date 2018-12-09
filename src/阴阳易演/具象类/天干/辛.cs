namespace 阴阳易演.具象类.天干
{
    using 抽象类;
    using 枚举类;

    public class 辛 : 天干
    {
        public 辛()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.金;
            方位 = 十六方位.正西;
        }
    }

    public class 辛金 : 辛
    {

    }
}