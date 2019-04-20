namespace 阴阳易演.具象类.四象
{
    using 抽象类;
    using 计算类;

    public class 少阳 : 四象
    {
        public 少阳()
        {
            方位 = "东";
            神兽 = "青龙";
            四季 = 季节.春季;
            颜色 = "#00FF00";
            卦值 = 八卦计算.生成卦值("01");
        }
        public 太阳 推演 => 太阳;
        public 太阴 追溯 => 太阴;
    }
}
