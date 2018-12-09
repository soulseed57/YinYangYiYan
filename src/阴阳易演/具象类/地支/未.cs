namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 未 : 地支
    {
        public 未()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.土;
            生肖 = "羊";
            方位 = 十六方位.南偏西;
        }
    }
}
