namespace 阴阳易演.抽象类
{
    using 具象类.六神;
    using 基类;

    public abstract class 六神 : 无极
    {
        #region 内部
        //静态
        static 六神()
        {
            青龙 = new 青龙();
            朱雀 = new 朱雀();
            白虎 = new 白虎();
            玄武 = new 玄武();
            勾陈 = new 勾陈();
            滕蛇 = new 滕蛇();
        }
        //动态

        #endregion

        #region 公开
        //静态
        public static 青龙 青龙 { get; }
        public static 朱雀 朱雀 { get; }
        public static 白虎 白虎 { get; }
        public static 玄武 玄武 { get; }
        public static 勾陈 勾陈 { get; }
        public static 滕蛇 滕蛇 { get; }
        //动态

        #endregion

    }
}