namespace 阴阳易演.具象类.天干
{
    using 抽象类;

    public class 庚 : 天干
    {
        public 庚()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.金;
        }
    }

    public class 庚金 : 庚
    {
    }
}