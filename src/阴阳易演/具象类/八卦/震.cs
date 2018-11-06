namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 震 : 八卦
    {
        public 震()
        {
            序数 = 4;
            本数 = 3;
            方位 = "正东";
            卦值 = 生成卦值("100");
            四象 = 四象.少阴;
        }
    }
}
