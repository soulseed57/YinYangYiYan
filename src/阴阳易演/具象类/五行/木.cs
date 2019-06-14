namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 木 : 五行
    {
        public 木()
        {
            生数 = 3;
            成数 = 8;
            方位 = 四象.少阳.方位;
            神兽 = 四象.少阳.神兽;
            四季 = 四象.少阳.四季;
            颜色 = 四象.少阳.颜色;
        }
        public 水 生我 => 水;
        public 火 我生 => 火;
        public 金 克我 => 金;
        public 土 我克 => 土;
        public 木 同我 => 木;
    }
}
