using System.Drawing;

namespace 阴阳易演.具象类.五行
{
    using 抽象类;

    public class 土 : 五行
    {
        public new 火 父母 => 火;
        public new 金 子孙 => 金;
        public new 木 官鬼 => 木;
        public new 水 妻妾 => 水;
        public new 土 兄弟 => 土;

        public 土()
        {
            数字 = 5;
            方位 = "中";
            神兽 = "黄麟";
            四季 = 季节.四季;
            颜色 = Color.Yellow;
        }
    }
}
