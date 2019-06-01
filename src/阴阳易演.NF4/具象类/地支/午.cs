namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 午 : 地支
    {
        public 午()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.火;
            生肖 = "马";
            方位 = 十六方位.正南;
        }
    }
}
