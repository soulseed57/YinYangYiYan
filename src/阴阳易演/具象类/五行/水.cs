namespace 阴阳易演.具象类.五行
{
    using 四象;
    using 抽象类;

    public class 水 : 五行
    {
        public new 金 父母 => 金;
        public new 木 子孙 => 木;
        public new 土 官鬼 => 土;
        public new 火 妻妾 => 火;
        public new 水 兄弟 => 水;

        public 水()
        {
            数字 = 象属.数字;
            方位 = 象属.方位;
            神兽 = 象属.神兽;
            四季 = 象属.四季;
            颜色 = 象属.颜色;
        }
        public 太阴 象属 => 四象.太阴;
    }
}
