namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 子 : 地支
    {
        public 子()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.水;
            生肖 = "鼠";
            方位 = 十六方位.正北;
        }
    }
}
