namespace 阴阳易演.具象类.季节
{
    using 五行;
    using 抽象类;

    public class 夏季 : 季节
    {
        public new 火 旺 => 五行.火;
        public new 土 相 => 五行.土;
        public new 木 休 => 五行.木;
        public new 水 囚 => 五行.水;
        public new 金 死 => 五行.金;
    }
}
