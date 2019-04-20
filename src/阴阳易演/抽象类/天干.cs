namespace 阴阳易演.抽象类
{
    using 具象类.天干;
    using 基类;

    public abstract class 天干 : 干支
    {
        #region 构造
        static 天干()
        {
            甲 = new 甲();
            乙 = new 乙();
            丙 = new 丙();
            丁 = new 丁();
            戊 = new 戊();
            己 = new 己();
            庚 = new 庚();
            辛 = new 辛();
            壬 = new 壬();
            癸 = new 癸();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 甲 甲 { get; }
        public static 乙 乙 { get; }
        public static 丙 丙 { get; }
        public static 丁 丁 { get; }
        public static 戊 戊 { get; }
        public static 己 己 { get; }
        public static 庚 庚 { get; }
        public static 辛 辛 { get; }
        public static 壬 壬 { get; }
        public static 癸 癸 { get; }

        #endregion

    }
}
