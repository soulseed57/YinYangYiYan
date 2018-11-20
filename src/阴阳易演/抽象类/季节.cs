namespace 阴阳易演.抽象类
{
    using 具象类.五行;
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
        //阴静
        public static string operator +(季节 季节, 五行 行属)
        {
            string 结果 = null;
            switch (季节)
            {
                case 春季 _ when 行属 is 木:
                case 夏季 _ when 行属 is 火:
                case 秋季 _ when 行属 is 金:
                case 冬季 _ when 行属 is 水:
                case 长夏 _ when 行属 is 土:
                    结果 = "旺";
                    break;
                case 春季 _ when 行属 is 火:
                case 夏季 _ when 行属 is 土:
                case 秋季 _ when 行属 is 水:
                case 冬季 _ when 行属 is 木:
                case 长夏 _ when 行属 is 金:
                    结果 = "相";
                    break;
                case 春季 _ when 行属 is 水:
                case 夏季 _ when 行属 is 木:
                case 秋季 _ when 行属 is 土:
                case 冬季 _ when 行属 is 金:
                case 长夏 _ when 行属 is 火:
                    结果 = "休";
                    break;
                case 春季 _ when 行属 is 金:
                case 夏季 _ when 行属 is 水:
                case 秋季 _ when 行属 is 火:
                case 冬季 _ when 行属 is 土:
                case 长夏 _ when 行属 is 木:
                    结果 = "囚";
                    break;
                case 春季 _ when 行属 is 土:
                case 夏季 _ when 行属 is 金:
                case 秋季 _ when 行属 is 木:
                case 冬季 _ when 行属 is 火:
                case 长夏 _ when 行属 is 水:
                    结果 = "死";
                    break;
            }
            return 结果;
        }
        //阳动
        public 五行 旺
        {
            get
            {
                五行 行属 = null;
                switch (this)
                {
                    case 春季 _:
                        行属 = 五行.木;
                        break;
                    case 夏季 _:
                        行属 = 五行.火;
                        break;
                    case 秋季 _:
                        行属 = 五行.金;
                        break;
                    case 冬季 _:
                        行属 = 五行.水;
                        break;
                    case 长夏 _:
                        行属 = 五行.土;
                        break;
                }
                return 行属;
            }
        }
        public 五行 相
        {
            get
            {
                五行 行属 = null;
                switch (this)
                {
                    case 春季 _:
                        行属 = 五行.火;
                        break;
                    case 夏季 _:
                        行属 = 五行.土;
                        break;
                    case 秋季 _:
                        行属 = 五行.水;
                        break;
                    case 冬季 _:
                        行属 = 五行.木;
                        break;
                    case 长夏 _:
                        行属 = 五行.金;
                        break;
                }
                return 行属;
            }
        }
        public 五行 休
        {
            get
            {
                五行 行属 = null;
                switch (this)
                {
                    case 春季 _:
                        行属 = 五行.水;
                        break;
                    case 夏季 _:
                        行属 = 五行.木;
                        break;
                    case 秋季 _:
                        行属 = 五行.土;
                        break;
                    case 冬季 _:
                        行属 = 五行.金;
                        break;
                    case 长夏 _:
                        行属 = 五行.火;
                        break;
                }
                return 行属;
            }
        }
        public 五行 囚
        {
            get
            {
                五行 行属 = null;
                switch (this)
                {
                    case 春季 _:
                        行属 = 五行.金;
                        break;
                    case 夏季 _:
                        行属 = 五行.水;
                        break;
                    case 秋季 _:
                        行属 = 五行.火;
                        break;
                    case 冬季 _:
                        行属 = 五行.土;
                        break;
                    case 长夏 _:
                        行属 = 五行.木;
                        break;
                }
                return 行属;
            }
        }
        public 五行 死
        {
            get
            {
                五行 行属 = null;
                switch (this)
                {
                    case 春季 _:
                        行属 = 五行.土;
                        break;
                    case 夏季 _:
                        行属 = 五行.金;
                        break;
                    case 秋季 _:
                        行属 = 五行.木;
                        break;
                    case 冬季 _:
                        行属 = 五行.火;
                        break;
                    case 长夏 _:
                        行属 = 五行.水;
                        break;
                }
                return 行属;
            }
        }
        public string 衰旺(五行 行属) => this + 行属;

        #endregion

    }
}
