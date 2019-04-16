using System;

namespace 阴阳易演.查询类
{
    using 容器类;
    using 引用库;
    using 抽象类;
    using 枚举类;
    
    public static class 二十四节气
    {
        static 二十四节气()
        {
            节气数 = 枚举转换类<节气枚举>.获取枚举数();
        }
        public static readonly int 节气数;

        #region 节气枚举
        public static int 获取节气序数(节气 节)
        {
            return 枚举转换类<节气枚举>.获取序数(节.名称);
        }
        public static int 获取节气序数(节气枚举 枚)
        {
            return 枚举转换类<节气枚举>.获取序数(枚);
        }
        public static 节气枚举 获取节气枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 节气数);
            return 枚举转换类<节气枚举>.获取枚举(序);
        }
        public static 节气枚举 获取节气枚举(string 名)
        {
            return 枚举转换类<节气枚举>.获取枚举(名);
        }
        public static string 获取节气名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 节气数);
            return 枚举转换类<节气枚举>.获取名称(序);
        }

        #endregion

        #region 查询
        public static 节气枚举 节气查询(DateTime 时间)
        {
            var 年份 = 时间.Year;
            var offset = DiffMinutes(年份);
            var found = -1;
            for (var i = 0; i < _sTermInfo.Length; i++)
            {
                var minutes = offset + _sTermInfo[i];
                var solarTermDate = _baseTime.AddMinutes(minutes);
                var span = solarTermDate - 时间;
                if (span.Days > 0)
                {
                    break;
                }
                found = i;
            }
            if (found == -1)
            {
                throw new Exception($"未找到日期[{时间}]的节气");
            }
            else
            {
                return 获取节气枚举(found);
            }
        }
        public static DateTime 节气查询(int 年份, 节气枚举 枚)
        {
            var i = (int)枚;
            var offset = DiffMinutes(年份);
            var minutes = offset + _sTermInfo[i];
            var solarTermDate = _baseTime.AddMinutes(minutes);
            return solarTermDate;
        }
        public static 季节 季节查询(DateTime 时间)
        {
            var 年份 = 时间.Year;
            var 节气 = 节气枚举.冬至;
            for (var i = 0; i < 24; i++)
            {
                var 节 = (节气枚举)Enum.ToObject(typeof(节气枚举), i);
                var 时 = 节气查询(年份, 节);
                if (时.DayOfYear <= 时间.DayOfYear)
                {
                    节气 = 节;
                }
                else
                {
                    break;
                }
            }
            switch (节气)
            {
                case 节气枚举.立春:
                case 节气枚举.雨水:
                case 节气枚举.惊蛰:
                case 节气枚举.春分:
                case 节气枚举.清明:
                case 节气枚举.谷雨:
                    return 季节.春季;
                case 节气枚举.立夏:
                case 节气枚举.小满:
                case 节气枚举.芒种:
                case 节气枚举.夏至:
                case 节气枚举.小暑:
                case 节气枚举.大暑:
                    return 季节.夏季;
                case 节气枚举.立秋:
                case 节气枚举.处暑:
                case 节气枚举.白露:
                case 节气枚举.秋分:
                case 节气枚举.寒露:
                case 节气枚举.霜降:
                    return 季节.秋季;
                case 节气枚举.立冬:
                case 节气枚举.小雪:
                case 节气枚举.大雪:
                case 节气枚举.冬至:
                case 节气枚举.小寒:
                case 节气枚举.大寒:
                    return 季节.冬季;
            }
            throw new Exception($"当前日期[{时间}]未查询到匹配季节");
        }

        #endregion

        #region 运算
        // 内部
        static readonly int[] _sTermInfo =
        {
            0, 21208, 42467, 63836,
            85337,107014, 128867, 150921,
            173149, 195551,218072, 240693,
            263343, 285989, 308563,331033,
            353350, 375494, 397447, 419210,
            440795, 462224, 483532, 504758
        };
        static readonly DateTime _baseTime = new DateTime(1900, 1, 6, 2, 5, 0);
        static double DiffMinutes(int year) => 525948.76 * (year - _baseTime.Year);
        // 公开
        public static double? 日期转修正儒略日(DateTime date)
        {
            double? res = null;
            try
            {
                var y = date.Year;
                var m = date.Month;
                var d = date.Day;
                var l = m == 1 || m == 2 ? 1 : 0;
                res = 14956 + d + (int)((y - l) * 365.25) + (int)((m + 1 + l * 12) * 30.6001);
            }
            catch
            {
                // ignored
            }
            return res;
        }
        public static DateTime? 修正儒略日转日期(double mjd)
        {
            DateTime? res = null;
            try
            {
                var y = (int)((mjd - 15078.2) / 365.25);
                var m = (int)((int)(mjd - 14956.1 - (int)(y * 365.25)) / 30.6001);
                var d = (int)(mjd - 14956 - (int)(y * 365.25) - (int)(m * 30.6001));
                var k = m == 14 || m == 15 ? 1 : 0;
                y = y + k;
                m = m - 1 - k * 12;
                res = new DateTime(y, m, d);
            }
            catch
            {
                // ignored
            }
            return res;
        }

        #endregion

    }
}
