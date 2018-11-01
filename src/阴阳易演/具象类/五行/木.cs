namespace 阴阳易演.具象类.五行
{
    using 四象;
    using 抽象类;

    public class 木 : 五行
    {
        public new 水 父母 => 水;
        public new 火 子孙 => 火;
        public new 金 官鬼 => 金;
        public new 土 妻妾 => 土;
        public new 木 兄弟 => 木;

        public 木()
        {
            数字 = 象属.数字;
            方位 = 象属.方位;
            神兽 = 象属.神兽;
            四季 = 象属.四季;
            颜色 = 象属.颜色;
        }
        public 少阳 象属 => 四象.少阳;
    }
}
