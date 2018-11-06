namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 离 : 八卦
    {
        public 离()
        {
            序数 = 3;
            本数 = 9;
            方位 = "正南";
            卦值 = 生成卦值("101");
            四象 = 四象.少阴;
        }
    }
}
