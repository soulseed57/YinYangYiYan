namespace 阴阳易演.具象类.天干
{
    using 抽象类;
    using 枚举类;

    public class 癸 : 天干
    {
        public 癸()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.水;
            方位 = 十六方位.正北;
        }
    }

    public class 癸水 : 癸
    {
    }
}