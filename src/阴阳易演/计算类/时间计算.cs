namespace 阴阳易演.计算类
{
    using System;
    using 抽象类;
    using 查询类;

    public static class 时间计算
    {
        #region 参数
        public enum 早晚子
        {
            无, 早子时, 晚子时
        }

        #endregion

        #region 扩展
        public static 地支 时辰地支(this DateTime 时间, out 早晚子 选项)
        {
            选项 = 早晚子.无;
            var 时 = (时间 - 时间.Date).TotalHours;
            if (时 < 1)
            {
                选项 = 早晚子.早子时;
                return 地支.子;
            }
            else if (23 <= 时)
            {
                选项 = 早晚子.晚子时;
                return 地支.子;
            }
            else if (1 <= 时 && 时 < 3)
            {
                return 地支.丑;
            }
            else if (3 <= 时 && 时 < 5)
            {
                return 地支.寅;
            }
            else if (5 <= 时 && 时 < 7)
            {
                return 地支.卯;
            }
            else if (7 <= 时 && 时 < 9)
            {
                return 地支.辰;
            }
            else if (9 <= 时 && 时 < 11)
            {
                return 地支.巳;
            }
            else if (11 <= 时 && 时 < 13)
            {
                return 地支.午;
            }
            else if (13 <= 时 && 时 < 15)
            {
                return 地支.未;
            }
            else if (15 <= 时 && 时 < 17)
            {
                return 地支.申;
            }
            else if (17 <= 时 && 时 < 19)
            {
                return 地支.酉;
            }
            else if (19 <= 时 && 时 < 21)
            {
                return 地支.戌;
            }
            else if (21 <= 时 && 时 < 23)
            {
                return 地支.亥;
            }
            throw new Exception("未找到匹配的时辰");
        }
        public static int 时辰数字(this DateTime 时间)
        {
            var 辰 = 时辰地支(时间, out var _);
            var 序 = 干支表.获取地支序数(辰);
            return 序;
        }

        #endregion

    }
}