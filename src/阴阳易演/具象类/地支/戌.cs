﻿namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 戌 : 地支
    {
        public 戌()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.土;
            生肖 = "狗";
            方位 = 十六方位.西偏北;
        }
    }
}
