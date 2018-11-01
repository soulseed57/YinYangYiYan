namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 离 : 八卦
    {
        public 离()
        {
            生数 = 3;
            成数 = 9;
            先天位 = "正东";
            后天位 = "正南";
            卦值 = 生成卦值("101");
        }
    }
}
