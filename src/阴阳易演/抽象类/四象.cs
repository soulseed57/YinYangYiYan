namespace 阴阳易演.抽象类
{
    using 具象类.四象;
    using 基类;

    public abstract class 四象 : 无极
    {
        #region 构造
        static 四象()
        {
            少阳 = new 少阳();
            太阳 = new 太阳();
            少阴 = new 少阴();
            太阴 = new 太阴();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 少阳 少阳 { get; }
        public static 太阳 太阳 { get; }
        public static 少阴 少阴 { get; }
        public static 太阴 太阴 { get; }
        // 动态属性
        public string 方位 { get; protected set; }
        public string 神兽 { get; protected set; }
        public 季节 四季 { get; protected set; }
        public string 颜色 { get; protected set; }
        public byte 爻值 { get; protected set; }

        #endregion

    }
}
