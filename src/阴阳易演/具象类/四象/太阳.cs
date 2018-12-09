
namespace 阴阳易演.具象类.四象
{
    using 抽象类;

    public class 太阳 : 四象
    {
        public new 少阴 推演 => 少阴;
        public new 少阳 追溯 => 少阳;

        public 太阳()
        {
            方位 = "南";
            神兽 = "朱雀";
            四季 = 季节.夏季;
            颜色 = "#FF0000";
            卦值 = 八卦.生成卦值("11");
        }
    }
}
