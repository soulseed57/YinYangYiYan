namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坎 : 八卦
    {
        public 坎()
        {
            生数 = 6;
            成数 = 1;
            先天位 = "西";
            后天位 = "北";
            卦值 = 生成卦值("010");
        }
    }
}
