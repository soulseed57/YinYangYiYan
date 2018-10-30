namespace 阴阳易演.具象类.八卦
{
    using System;
    using 抽象类;

    public class 离 : 八卦
    {
        public 离()
        {
            生数 = 3;
            成数 = 9;
            先天位 = "东";
            后天位 = "南";
            先天卦值 = 生成卦值("101");
        }
    }
}
