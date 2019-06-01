namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 金 : 五行
    {
        public 金()
        {
            数字 = 4;
            方位 = 四象.少阴.方位;
            神兽 = 四象.少阴.神兽;
            四季 = 四象.少阴.四季;
            颜色 = 四象.少阴.颜色;
        }
        public 土 生我 => 土;
        public 水 我生 => 水;
        public 火 克我 => 火;
        public 木 我克 => 木;
        public 金 同我 => 金;
    }
}
