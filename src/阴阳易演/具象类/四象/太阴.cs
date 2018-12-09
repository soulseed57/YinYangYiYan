namespace 阴阳易演.具象类.四象
{
    using 抽象类;

    public class 太阴 : 四象
    {
        public new 少阳 推演 => 少阳;
        public new 少阴 追溯 => 少阴;

        public 太阴()
        {
            方位 = "北";
            神兽 = "玄武";
            四季 = 季节.冬季;
            颜色 = "#000000";
            卦值 = 八卦.生成卦值("00");
        }
    }
}
