﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 震 : 八卦
    {
        public 震()
        {
            先天数 = 4;
            后天数 = 3;
            先天位 = "东北";
            后天位 = "正东";
            卦值 = 生成卦值("100");
        }
    }
}
