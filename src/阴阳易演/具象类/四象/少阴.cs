﻿using System.Drawing;

namespace 阴阳易演.具象类.四象
{
    using 抽象类;

    public class 少阴 : 四象
    {
        public new 太阴 推演 => 太阴;
        public new 太阳 追溯 => 太阳;

        public 少阴()
        {
            仪属.Add(两仪.阳);
            仪属.Insert(0, 两仪.阴);
            数字 = 4;
            方位 = "西";
            神兽 = "白虎";
            四季 = 季节.秋季;
            颜色 = Color.White;
        }
    }
}
