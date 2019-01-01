namespace 阴阳易演.抽象类
{
    using 具象类.季节;
    using 基类;

    public abstract class 季节 : 无极
    {
        #region 天清
        static 季节()
        {
            春季 = new 春季();
            夏季 = new 夏季();
            秋季 = new 秋季();
            冬季 = new 冬季();
            长夏 = new 长夏();
        }

        #endregion

        #region 地浊
        public static 春季 春季 { get; }
        public static 夏季 夏季 { get; }
        public static 秋季 秋季 { get; }
        public static 冬季 冬季 { get; }
        public static 长夏 长夏 { get; }

        #endregion

        #region 运算
        public 五行 旺
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.旺;
                    case 夏季 _:
                        return 夏季.旺;
                    case 秋季 _:
                        return 秋季.旺;
                    case 冬季 _:
                        return 冬季.旺;
                    case 长夏 _:
                        return 长夏.旺;
                }
                return null;
            }
        }
        public 五行 相
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.相;
                    case 夏季 _:
                        return 夏季.相;
                    case 秋季 _:
                        return 秋季.相;
                    case 冬季 _:
                        return 冬季.相;
                    case 长夏 _:
                        return 长夏.相;
                }
                return null;
            }
        }
        public 五行 休
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.休;
                    case 夏季 _:
                        return 夏季.休;
                    case 秋季 _:
                        return 秋季.休;
                    case 冬季 _:
                        return 冬季.休;
                    case 长夏 _:
                        return 长夏.休;
                }
                return null;
            }
        }
        public 五行 囚
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.囚;
                    case 夏季 _:
                        return 夏季.囚;
                    case 秋季 _:
                        return 秋季.囚;
                    case 冬季 _:
                        return 冬季.囚;
                    case 长夏 _:
                        return 长夏.囚;
                }
                return null;
            }
        }
        public 五行 死
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.死;
                    case 夏季 _:
                        return 夏季.死;
                    case 秋季 _:
                        return 秋季.死;
                    case 冬季 _:
                        return 冬季.死;
                    case 长夏 _:
                        return 长夏.死;
                }
                return null;
            }
        }

        #endregion

    }
}
