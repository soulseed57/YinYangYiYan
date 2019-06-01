namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 寅 : 地支
    {
        public 寅()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.木;
            生肖 = "虎";
            方位 = 十六方位.东北;
        }
    }
}
