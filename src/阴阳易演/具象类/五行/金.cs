namespace 阴阳易演.具象类.五行
{
    using 四象;
    using 抽象类;

    public class 金 : 五行
    {
        public new 土 父母 => 土;
        public new 水 子孙 => 水;
        public new 火 官鬼 => 火;
        public new 木 妻妾 => 木;
        public new 金 兄弟 => 金;

        public 金()
        {
            数字 = 象属.数字;
            方位 = 象属.方位;
            神兽 = 象属.神兽;
            四季 = 象属.四季;
            颜色 = 象属.颜色;
        }
        public 少阴 象属 => 四象.少阴;
    }
}
