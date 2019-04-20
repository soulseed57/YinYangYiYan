namespace 阴阳易演.抽象类
{
    using 具象类.八卦;
    using 基类;
    using 枚举类;

    public abstract class 八卦 : 无极
    {
        #region 构造
        static 八卦()
        {
            乾 = new 乾();
            兑 = new 兑();
            离 = new 离();
            震 = new 震();
            巽 = new 巽();
            坎 = new 坎();
            艮 = new 艮();
            坤 = new 坤();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 乾 乾 { get; }
        public static 兑 兑 { get; }
        public static 离 离 { get; }
        public static 震 震 { get; }
        public static 巽 巽 { get; }
        public static 坎 坎 { get; }
        public static 艮 艮 { get; }
        public static 坤 坤 { get; }
        // 动态属性
        public int 先天数 { get; protected set; }
        public int 后天数 { get; protected set; }
        public 八方方位 卦位 { get; protected set; }
        public 八方方位 方位 { get; protected set; }
        public byte 卦值 { get; protected set; }
        public 四象 四象 { get; protected set; }
        public string 人物 { get; protected set; }
        public string 类象 { get; protected set; }

        #endregion

    }
}
