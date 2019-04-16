namespace 阴阳易演.抽象类
{
    using 具象类.四象;
    using 基类;

    public abstract class 四象 : 无极
    {
        #region 天清
        static 四象()
        {
            少阳 = new 少阳();
            太阳 = new 太阳();
            少阴 = new 少阴();
            太阴 = new 太阴();
        }

        #endregion

        #region 地浊
        // 阴静
        public static 少阳 少阳 { get; }
        public static 太阳 太阳 { get; }
        public static 少阴 少阴 { get; }
        public static 太阴 太阴 { get; }
        // 阳动
        public string 方位 { get; protected set; }
        public string 神兽 { get; protected set; }
        public 季节 四季 { get; protected set; }
        public string 颜色 { get; protected set; }
        public byte 卦值 { get; protected set; }

        #endregion

        #region 运算
        public static 四象 推演(四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 少阳 _:
                    象 = 太阳;
                    break;
                case 太阳 _:
                    象 = 少阴;
                    break;
                case 少阴 _:
                    象 = 太阴;
                    break;
                case 太阴 _:
                    象 = 少阳;
                    break;
            }
            return 象;
        }
        public static 四象 追溯(四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 太阴 _:
                    象 = 少阴;
                    break;
                case 少阴 _:
                    象 = 太阳;
                    break;
                case 太阳 _:
                    象 = 少阳;
                    break;
                case 少阳 _:
                    象 = 太阴;
                    break;
            }
            return 象;
        }

        #endregion

    }
}
