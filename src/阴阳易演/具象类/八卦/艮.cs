namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 艮 : 八卦
    {
        public 艮()
        {
            序数 = 7;
            本数 = 8;
            方位 = "东北";
            卦值 = 生成卦值("001");
            四象 = 四象.太阴;
        }
    }
}
