namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 火 : 五行
    {
        public 火()
        {
            生数 = 2;
            成数 = 7;
            方位 = 四象.太阳.方位;
            神兽 = 四象.太阳.神兽;
            四季 = 四象.太阳.四季;
            颜色 = 四象.太阳.颜色;
        }
        public 木 生我 => 木;
        public 土 我生 => 土;
        public 水 克我 => 水;
        public 金 我克 => 金;
        public 火 同我 => 火;
    }
}
