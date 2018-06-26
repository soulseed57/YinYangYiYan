﻿using System;

namespace 阴阳易演.计算类
{
    public class 二十四节气
    {
        public enum 节气枚举
        {
            小寒, 大寒,
            立春, 雨水,
            惊蛰, 春分,
            清明, 谷雨,
            立夏, 小满,
            芒种, 夏至,
            小暑, 大暑,
            立秋, 处暑,
            白露, 秋分,
            寒露, 霜降,
            立冬, 小雪,
            大雪, 冬至
        }

        public 二十四节气(int 年份, 节气枚举 节气)
        {
            名称 = 节气.ToString();
            日期 = 节气查询(年份, 节气);
        }
        public string 名称 { get; protected set; }
        public DateTime 日期 { get; protected set; }

        #region 运算
        static readonly int[] 节气修正值 =
        {
            0, 21208, 42467, 63836,
            85337,107014, 128867, 150921,
            173149, 195551,218072, 240693,
            263343, 285989, 308563,331033,
            353350, 375494, 397447, 419210,
            440795, 462224, 483532, 504758
        };
        static readonly DateTime 基准时间 = new DateTime(1900, 1, 6, 2, 5, 0);
        static double 基准偏移分钟(int year, int st) => 525948.76 * (year - 1900) + 节气修正值[st];
        public static 节气枚举 节气查询(DateTime date)
        {
            var 当前节气 = 节气枚举.冬至;
            foreach (节气枚举 枚 in Enum.GetValues(typeof(节气枚举)))
            {
                var 查询节气时间 = 节气查询(date.Year, 枚);
                if (查询节气时间 > date)
                {
                    break;
                }
                当前节气 = 枚;
            }
            return 当前节气;
        }
        public static DateTime 节气查询(int year, 节气枚举 solarTerm)
        {
            var minutes = 基准偏移分钟(year, (int)solarTerm);
            var solarTermDate = 基准时间.AddMinutes(minutes);
            return solarTermDate;
        }
        public static int 节气月份查询(DateTime date)
        {
            var 节气 = 节气查询(date);
            switch (节气)
            {
                case 节气枚举.小寒:
                case 节气枚举.大寒:
                    return 12;
                case 节气枚举.立春:
                case 节气枚举.雨水:
                    return 1;
                case 节气枚举.惊蛰:
                case 节气枚举.春分:
                    return 2;
                case 节气枚举.清明:
                case 节气枚举.谷雨:
                    return 3;
                case 节气枚举.立夏:
                case 节气枚举.小满:
                    return 4;
                case 节气枚举.芒种:
                case 节气枚举.夏至:
                    return 5;
                case 节气枚举.小暑:
                case 节气枚举.大暑:
                    return 6;
                case 节气枚举.立秋:
                case 节气枚举.处暑:
                    return 7;
                case 节气枚举.白露:
                case 节气枚举.秋分:
                    return 8;
                case 节气枚举.寒露:
                case 节气枚举.霜降:
                    return 9;
                case 节气枚举.立冬:
                case 节气枚举.小雪:
                    return 10;
                case 节气枚举.大雪:
                case 节气枚举.冬至:
                    return 11;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
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
