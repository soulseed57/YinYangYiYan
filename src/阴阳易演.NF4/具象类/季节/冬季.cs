namespace 阴阳易演.具象类.季节
{
    using 五行;
    using 抽象类;

    public class 冬季 : 季节
    {
        public new 水 旺 => 五行.水;
        public new 木 相 => 五行.木;
        public new 金 休 => 五行.金;
        public new 土 囚 => 五行.土;
        public new 火 死 => 五行.火;
    }
}
