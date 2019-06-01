namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 酉 : 地支
    {
        public 酉()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.金;
            生肖 = "鸡";
            方位 = 十六方位.正西;
        }
    }
}
