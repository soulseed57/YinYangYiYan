namespace 阴阳易演.具象类.天干
{
    using 抽象类;
    using 枚举类;

    public class 乙 : 天干
    {
        public 乙()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.木;
            方位 = 十六方位.正东;
        }
    }

    public class 乙木 : 乙
    {

    }
}