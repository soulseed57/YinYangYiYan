namespace 阴阳易演.具象类.天干
{
    using 抽象类;
    using 枚举类;

    public class 丁 : 天干
    {
        public 丁()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.火;
            方位 = 十六方位.正南;
        }
    }

    public class 丁火 : 丁
    {
    }
}