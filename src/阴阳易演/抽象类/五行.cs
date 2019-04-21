namespace 阴阳易演.抽象类
{
    using 具象类.五行;
    using 基类;

    public abstract class 五行 : 无极
    {
        #region 构造
        static 五行()
        {
            金 = new 金();
            水 = new 水();
            木 = new 木();
            火 = new 火();
            土 = new 土();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 金 金 { get; }
        public static 水 水 { get; }
        public static 木 木 { get; }
        public static 火 火 { get; }
        public static 土 土 { get; }
        // 动态属性
        public int 数字 { get; protected set; }
        public string 方位 { get; protected set; }
        public string 神兽 { get; protected set; }
        public 季节 四季 { get; protected set; }
        public string 颜色 { get; protected set; }

        #endregion

        #region 运算符
        public static bool operator ==(五行 一, 五行 二)
        {
            if (一 is null && 二 is null)
            {
                return true;
            }
            if (一 is null || 二 is null)
            {
                return false;
            }
            return 一.名称 == 二.名称;
        }
        public static bool operator !=(五行 一, 五行 二)
        {
            return !(一 == 二);
        }
        public override bool Equals(object obj)
        {
            return this == (五行)obj;
        }

        #endregion

    }
}
