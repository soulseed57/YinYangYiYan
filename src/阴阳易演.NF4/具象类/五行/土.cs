namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 土 : 五行
    {
        public 土()
        {
            生数 = 5;
            成数 = 10;
            方位 = "中";
            神兽 = "黄麟";
            四季 = 季节.长夏;
            颜色 = "#FFFF00";
        }
        public 火 生我 => 火;
        public 金 我生 => 金;
        public 木 克我 => 木;
        public 水 我克 => 水;
        public 土 同我 => 土;
    }
}
