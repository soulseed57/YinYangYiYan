﻿namespace 阴阳易演.具象类.五行
{
    using 四象;
    using 抽象类;

    public class 火 : 五行
    {
        public 火()
        {
            数字 = 2;
            方位 = 象属.方位;
            神兽 = 象属.神兽;
            四季 = 象属.四季;
            颜色 = 象属.颜色;
        }
        public 木 父母 => 木;
        public 土 子孙 => 土;
        public 水 官鬼 => 水;
        public 金 妻妾 => 金;
        public 火 兄弟 => 火;
        public 太阳 象属 => 四象.太阳;
    }
}
