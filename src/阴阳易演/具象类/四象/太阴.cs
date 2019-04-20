namespace 阴阳易演.具象类.四象
{
    using 抽象类;
    using 计算类;

    public class 太阴 : 四象
    {
        public 太阴()
        {
            方位 = "北";
            神兽 = "玄武";
            四季 = 季节.冬季;
            颜色 = "#000000";
            卦值 = 八卦计算.生成卦值("00");
        }
        public 少阳 推演 => 少阳;
        public 少阴 追溯 => 少阴;
    }
}
