﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;
    using 枚举类;

    public class 兑 : 八卦
    {
        public 兑()
        {
            先天数 = 2;
            后天数 = 7;
            卦位 = 八方方位.东南;
            方位 = 八方方位.正西;
            卦值 = 生成卦值("110");
            四象 = 四象.太阳;
            人物 = "少女";
            类象 = "泽";
        }
    }
}
