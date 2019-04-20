﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;
    using 枚举类;
    using 计算类;

    public class 坤 : 八卦
    {
        public 坤()
        {
            先天数 = 8;
            后天数 = 2;
            卦位 = 八方方位.正北;
            方位 = 八方方位.西南;
            卦值 = 八卦计算.生成卦值("000");
            四象 = 四象.太阴;
            人物 = "老女";
            类象 = "地";
        }
    }
}
