namespace 阴阳易演.具象类.天干
{
    using 抽象类;

    public class 甲 : 天干
    {
        public 甲()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.木;
        }
    }

    public class 甲木 : 甲
    {
    }
}