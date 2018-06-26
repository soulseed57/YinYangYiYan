namespace 阴阳易演.具象类.天干
{
    using 抽象类;

    public class 丙 : 天干
    {
        public 丙()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.火;
        }
    }

    public class 丙火 : 丙
    {
    }
}