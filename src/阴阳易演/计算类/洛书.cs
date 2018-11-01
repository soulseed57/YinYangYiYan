namespace 阴阳易演.计算类
{
    using 抽象类;

    public class 洛书 : 河图洛书
    {
        public 洛书(int 原数) : base(原数)
        {
            后天卦 = 河图八卦.Find(t => t.后天卦序 == 数字);
        }

        public 八卦 后天卦 { get; }
    }
}