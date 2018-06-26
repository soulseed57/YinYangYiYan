using System;

namespace 阴阳易演.抽象类
{
    using 具象类.五行;
    using 具象类.季节;
    using 基类;
    using 计算类;

    public abstract class 季节 : 无极
    {
        #region 内部
        //静态
        static 季节()
        {
            春季 = new 春季();
            夏季 = new 夏季();
            秋季 = new 秋季();
            冬季 = new 冬季();
            四季 = new 四季();
        }
        //动态

        #endregion

        #region 公开
        //静态
        public static 春季 春季 { get; }
        public static 夏季 夏季 { get; }
        public static 秋季 秋季 { get; }
        public static 冬季 冬季 { get; }
        public static 四季 四季 { get; }
        //动态

        #endregion

        #region 运算
        public static string operator +(季节 季节, 五行 行属)
        {
            string 结果 = null;
            switch (季节)
            {
                case 春季 _ when 行属 is 木:
                case 夏季 _ when 行属 is 火:
                case 秋季 _ when 行属 is 金:
                case 冬季 _ when 行属 is 水:
                case 四季 _ when 行属 is 土:
                    结果 = "旺";
                    break;
                case 春季 _ when 行属 is 火:
                case 夏季 _ when 行属 is 土:
                case 秋季 _ when 行属 is 水:
                case 冬季 _ when 行属 is 木:
                case 四季 _ when 行属 is 金:
                    结果 = "相";
                    break;
                case 春季 _ when 行属 is 水:
                case 夏季 _ when 行属 is 木:
                case 秋季 _ when 行属 is 土:
                case 冬季 _ when 行属 is 金:
                case 四季 _ when 行属 is 火:
                    结果 = "休";
                    break;
                case 春季 _ when 行属 is 金:
                case 夏季 _ when 行属 is 水:
                case 秋季 _ when 行属 is 火:
                case 冬季 _ when 行属 is 土:
                case 四季 _ when 行属 is 木:
                    结果 = "囚";
                    break;
                case 春季 _ when 行属 is 土:
                case 夏季 _ when 行属 is 金:
                case 秋季 _ when 行属 is 木:
                case 冬季 _ when 行属 is 火:
                case 四季 _ when 行属 is 水:
                    结果 = "死";
                    break;
            }
            return 结果;
        }
        public static 季节 季节判断(DateTime 时间)
        {
            季节 结果 = null;
            var 年份 = 时间.Year;
            var 节气 = 二十四节气.节气枚举.冬至;
            for (var i = 0; i < 24; i++)
            {
                var 节 = (二十四节气.节气枚举)Enum.ToObject(typeof(二十四节气.节气枚举), i);
                var 时 = 二十四节气.节气查询(年份, 节);
                if (时.DayOfYear <= 时间.DayOfYear)
                    节气 = 节;
                else
                    break;
            }
            switch (节气)
            {
                case 二十四节气.节气枚举.小寒:
                case 二十四节气.节气枚举.大寒:
                case 二十四节气.节气枚举.清明:
                case 二十四节气.节气枚举.谷雨:
                case 二十四节气.节气枚举.小暑:
                case 二十四节气.节气枚举.大暑:
                case 二十四节气.节气枚举.寒露:
                case 二十四节气.节气枚举.霜降:
                    结果 = 四季;
                    break;
                case 二十四节气.节气枚举.立春:
                case 二十四节气.节气枚举.雨水:
                case 二十四节气.节气枚举.惊蛰:
                case 二十四节气.节气枚举.春分:
                    结果 = 春季;
                    break;
                case 二十四节气.节气枚举.立夏:
                case 二十四节气.节气枚举.小满:
                case 二十四节气.节气枚举.芒种:
                case 二十四节气.节气枚举.夏至:
                    结果 = 夏季;
                    break;
                case 二十四节气.节气枚举.立秋:
                case 二十四节气.节气枚举.处暑:
                case 二十四节气.节气枚举.白露:
                case 二十四节气.节气枚举.秋分:
                    结果 = 秋季;
                    break;
                case 二十四节气.节气枚举.立冬:
                case 二十四节气.节气枚举.小雪:
                case 二十四节气.节气枚举.大雪:
                case 二十四节气.节气枚举.冬至:
                    结果 = 冬季;
                    break;
                default:
                    break;
            }
            return 结果;
        }
        //动态
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
                    case 四季 _:
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
                    case 四季 _:
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
                    case 四季 _:
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
                    case 四季 _:
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
                    case 四季 _:
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
