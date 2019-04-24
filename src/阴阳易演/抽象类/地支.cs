namespace 阴阳易演.抽象类
{
    using 具象类.地支;
    using 基类;

    public abstract class 地支 : 干支
    {
        #region 构造
        static 地支()
        {
            子 = new 子();
            丑 = new 丑();
            寅 = new 寅();
            卯 = new 卯();
            辰 = new 辰();
            巳 = new 巳();
            午 = new 午();
            未 = new 未();
            申 = new 申();
            酉 = new 酉();
            戌 = new 戌();
            亥 = new 亥();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 子 子 { get; }
        public static 丑 丑 { get; }
        public static 寅 寅 { get; }
        public static 卯 卯 { get; }
        public static 辰 辰 { get; }
        public static 巳 巳 { get; }
        public static 午 午 { get; }
        public static 未 未 { get; }
        public static 申 申 { get; }
        public static 酉 酉 { get; }
        public static 戌 戌 { get; }
        public static 亥 亥 { get; }
        // 动态属性
        public string 生肖 { get; protected set; }

        #endregion

    }
}
