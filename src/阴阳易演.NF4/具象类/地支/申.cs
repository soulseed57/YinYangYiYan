namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 申 : 地支
    {
        public 申()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.金;
            生肖 = "猴";
            方位 = 十六方位.西偏南;
        }
    }
}
