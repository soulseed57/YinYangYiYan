namespace 阴阳易演.计算类
{
    using System;
    using 抽象类;
    using 查询类;

    public static class 时间计算
    {
        #region 扩展
        public static 地支 时辰地支(this DateTime 时间)
        {
            var 当天起始 = new DateTime(时间.Year, 时间.Month, 时间.Day);
            var 当前总时 = 时间 - 当天起始;
            var 时 = 当前总时.TotalHours;
            if (时 < 1)
            {
                return 地支.子;
            }
            if (1 <= 时 && 时 < 3)
            {
                return 地支.丑;
            }
            if (3 <= 时 && 时 < 5)
            {
                return 地支.寅;
            }
            if (5 <= 时 && 时 < 7)
            {
                return 地支.卯;
            }
            if (7 <= 时 && 时 < 9)
            {
                return 地支.辰;
            }
            if (9 <= 时 && 时 < 11)
            {
                return 地支.巳;
            }
            if (11 <= 时 && 时 < 13)
            {
                return 地支.午;
            }
            if (13 <= 时 && 时 < 15)
            {
                return 地支.未;
            }
            if (15 <= 时 && 时 < 17)
            {
                return 地支.申;
            }
            if (17 <= 时 && 时 < 19)
            {
                return 地支.酉;
            }
            if (19 <= 时 && 时 < 21)
            {
                return 地支.戌;
            }
            if (21 <= 时 && 时 < 23)
            {
                return 地支.亥;
            }
            if (23 <= 时)
            {
                return 地支.子;
            }
            throw new Exception("未找到匹配的时辰");
        }
        public static int 时辰数字(this DateTime 时间)
        {
            var 辰 = 时辰地支(时间);
            var 序 = 干支表.获取地支序数(辰);
            return 序;
        }
        #endregion

    }
}