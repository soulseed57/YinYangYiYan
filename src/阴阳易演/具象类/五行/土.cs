namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 土 : 五行
    {
        public 土()
        {
            数字 = 5;
            方位 = "中";
            神兽 = "黄麟";
            四季 = 季节.长夏;
            颜色 = "#FFFF00";
        }
        public 火 父母 => 火;
        public 金 子孙 => 金;
        public 木 官鬼 => 木;
        public 水 妻妾 => 水;
        public 土 兄弟 => 土;
    }
}
