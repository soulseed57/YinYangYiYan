namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坤 : 八卦
    {
        public 坤()
        {
            生数 = 8;
            成数 = 2;
            先天位 = "北";
            后天位 = "西南";
            卦值 = 生成卦值("000");
        }
    }
}
