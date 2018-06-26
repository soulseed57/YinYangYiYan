using System.Drawing;

namespace 阴阳易演.具象类.四象
{
    using 抽象类;

    public class 少阳 : 四象
    {
        public new 太阳 推演 => 太阳;
        public new 太阴 追溯 => 太阴;

        public 少阳()
        {
            仪属.Add(两仪.阴);
            仪属.Insert(0, 两仪.阳);
            数字 = 3;
            方位 = "东";
            神兽 = "青龙";
            四季 = 季节.春季;
            颜色 = Color.Green;
        }
    }
}
