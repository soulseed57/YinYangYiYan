using System.Drawing;

namespace 阴阳易演.具象类.四象
{
    using 抽象类;

    public class 太阳 : 四象
    {
        public new 少阴 推演 => 少阴;
        public new 少阳 追溯 => 少阳;

        public 太阳()
        {
            仪属 = new 两仪[] { 两仪.阳, 两仪.阳 };
            数字 = 2;
            方位 = "南";
            神兽 = "朱雀";
            四季 = 季节.夏季;
            颜色 = Color.Red;
        }
    }
}
