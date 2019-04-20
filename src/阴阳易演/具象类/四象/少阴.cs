namespace 阴阳易演.具象类.四象
{
    using 抽象类;
    using 计算类;

    public class 少阴 : 四象
    {
        public 少阴()
        {
            方位 = "西";
            神兽 = "白虎";
            四季 = 季节.秋季;
            颜色 = "#FFFFFF";
            卦值 = 八卦计算.生成卦值("10");
        }
        public 太阴 推演 => 太阴;
        public 太阳 追溯 => 太阳;
    }
}
