namespace 阴阳易演.具象类.天干
{
    using 抽象类;

    public class 己 : 天干
    {
        public 己()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.土;
        }
    }

    public class 己土 : 己
    {
    }
}