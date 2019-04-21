namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 水 : 五行
    {
        public 水()
        {
            数字 = 1;
            方位 = 四象.太阴.方位;
            神兽 = 四象.太阴.神兽;
            四季 = 四象.太阴.四季;
            颜色 = 四象.太阴.颜色;
        }
        public 金 生我 => 金;
        public 木 我生 => 木;
        public 土 克我 => 土;
        public 火 我克 => 火;
        public 水 同我 => 水;
    }
}
