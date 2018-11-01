namespace 阴阳易演.计算类
{
    using 抽象类;

    public class 河图 : 河图洛书
    {
        public 河图(int 原数) : base(原数)
        {
            先天卦 = 河图八卦.Find(t => t.先天卦序 == 数字);
            地支组 = 地支.阴阳配五行(阴阳, 五行);
        }

        public 八卦 先天卦 { get; }
        public 地支[] 地支组 { get; }
    }
}
