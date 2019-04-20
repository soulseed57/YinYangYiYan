﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;
    using 枚举类;
    using 计算类;

    public class 离 : 八卦
    {
        public 离()
        {
            先天数 = 3;
            后天数 = 9;
            卦位 = 八方方位.正东;
            方位 = 八方方位.正南;
            爻值 = 卦爻计算.生成爻值("101");
            四象 = 四象.少阴;
            人象 = "中女";
            卦象 = "火";
        }
    }
}
