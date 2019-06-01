namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 亥 : 地支
    {
        public 亥()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.水;
            生肖 = "猪";
            方位 = 十六方位.北偏西;
        }
    }
}
