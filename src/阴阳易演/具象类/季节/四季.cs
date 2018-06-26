namespace 阴阳易演.具象类.季节
{
    using 五行;
    using 抽象类;

    public class 四季 : 季节
    {
        public new 土 旺 => 五行.土;
        public new 金 相 => 五行.金;
        public new 火 休 => 五行.火;
        public new 木 囚 => 五行.木;
        public new 水 死 => 五行.水;
    }
}
