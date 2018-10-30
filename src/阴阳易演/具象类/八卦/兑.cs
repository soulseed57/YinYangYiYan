namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 兑 : 八卦
    {
        public 兑()
        {
            生数 = 2;
            成数 = 7;
            先天位 = "东南";
            后天位 = "西";
            卦值 = 生成卦值("110");
        }
    }
}
