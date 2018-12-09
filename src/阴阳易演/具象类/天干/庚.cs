namespace 阴阳易演.具象类.天干
{
    using 抽象类;
    using 枚举类;

    public class 庚 : 天干
    {
        public 庚()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.金;
            方位 = 十六方位.西偏南;
        }
    }

    public class 庚金 : 庚
    {
    }
}