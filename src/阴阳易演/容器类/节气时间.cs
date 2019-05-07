namespace 阴阳易演.容器类
{
    using System;
    using System.Collections.Generic;
    using 引用库;
    using 枚举类;

    public class 节气时间
    {
        #region 构造
        public 节气时间(DateTime 日期)
        {
            var 年 = 日期.Year;
            var 末次时间 = DateTime.MinValue;
            var 末次索引 = -1;
            for (var i = -1; i <= 总节气数; i++)
            {
                var 节气时间 = 节气时间索引(年, i);
                if (节气时间 > 日期)
                {
                    break;
                }
                末次时间 = 节气时间;
                末次索引 = i;
            }
            时间 = 末次时间;
            节后日 = (int)(日期 - 末次时间).TotalDays;
            var 索引 = 常用方法.序数取余(末次索引, 总节气数);
            枚举 = 枚举字典[索引];
            名称 = 枚举转换类<节气枚举>.获取名称(枚举);
            上节时间 = 上一节气时间(日期);
            下节时间 = 下一节气时间(日期);
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public DateTime 时间 { get; }
        public 节气枚举 枚举 { get; }
        public int 节后日 { get; }
        public DateTime? 上节时间 { get; }
        public DateTime? 下节时间 { get; }

        #endregion

        #region 方法
        public static DateTime 节气时间查询(int 年份, 节气枚举 枚举)
        {
            var 索引 = 索引字典[枚举];
            return 节气时间索引(年份, 索引);
        }
        public static DateTime? 上一节气时间(DateTime 日期)
        {
            var 年 = 日期.Year;
            DateTime? 末次时间 = null;
            for (var i = -1; i <= 总节气数; i++)
            {
                var 节气时间 = 节气时间索引(年, i);
                if (节气时间 > 日期)
                {
                    break;
                }
                末次时间 = 节气时间;
            }
            return 末次时间;
        }
        public static DateTime? 下一节气时间(DateTime 日期)
        {
            var 年 = 日期.Year;
            DateTime? 末次时间 = null;
            for (var i = -1; i <= 总节气数; i++)
            {
                var 节气时间 = 节气时间索引(年, i);
                if (节气时间 > 日期)
                {
                    末次时间 = 节气时间;
                    break;
                }
            }
            return 末次时间;
        }

        #endregion

        #region 内部参数
        static readonly DateTime 基准时间 = new DateTime(1900, 1, 6, 2, 5, 0);
        static double 年份修正分钟(int year) => 525948.76 * (year - 基准时间.Year);
        static readonly int[] 节气修正分钟 =
        {
            0, 21208, 42467, 63836,
            85337,107014, 128867, 150921,
            173149, 195551,218072, 240693,
            263343, 285989, 308563,331033,
            353350, 375494, 397447, 419210,
            440795, 462224, 483532, 504758
        };
        static readonly int 总节气数 = 节气修正分钟.Length;
        static readonly Dictionary<节气枚举, int> 索引字典 = new Dictionary<节气枚举, int>
        {
            { 节气枚举.小寒, 0 }, { 节气枚举.大寒, 1 },
            { 节气枚举.立春, 2 }, { 节气枚举.雨水, 3 },
            { 节气枚举.惊蛰, 4 }, { 节气枚举.春分, 5 },
            { 节气枚举.清明, 6 }, { 节气枚举.谷雨, 7 },
            { 节气枚举.立夏, 8 }, { 节气枚举.小满, 9 },
            { 节气枚举.芒种, 10 }, { 节气枚举.夏至, 11 },
            { 节气枚举.小暑, 12 }, { 节气枚举.大暑, 13 },
            { 节气枚举.立秋, 14 }, { 节气枚举.处暑, 15 },
            { 节气枚举.白露, 16 }, { 节气枚举.秋分, 17 },
            { 节气枚举.寒露, 18 }, { 节气枚举.霜降, 19 },
            { 节气枚举.立冬, 20 }, { 节气枚举.小雪, 21 },
            { 节气枚举.大雪, 22 }, { 节气枚举.冬至, 23 }
        };
        static readonly Dictionary<int, 节气枚举> 枚举字典 = new Dictionary<int, 节气枚举>
        {
            { 0, 节气枚举.小寒 }, { 1, 节气枚举.大寒 },
            { 2, 节气枚举.立春 }, { 3, 节气枚举.雨水 },
            { 4, 节气枚举.惊蛰 }, { 5, 节气枚举.春分 },
            { 6, 节气枚举.清明 }, { 7, 节气枚举.谷雨 },
            { 8, 节气枚举.立夏 }, { 9, 节气枚举.小满 },
            { 10, 节气枚举.芒种 }, { 11, 节气枚举.夏至 },
            { 12, 节气枚举.小暑 }, { 13, 节气枚举.大暑 },
            { 14, 节气枚举.立秋 }, { 15, 节气枚举.处暑 },
            { 16, 节气枚举.白露 }, { 17, 节气枚举.秋分 },
            { 18, 节气枚举.寒露 }, { 19, 节气枚举.霜降 },
            { 20, 节气枚举.立冬 }, { 21, 节气枚举.小雪 },
            { 22, 节气枚举.大雪 }, { 23, 节气枚举.冬至 }
        };

        #endregion

        #region 内部方法
        static DateTime 节气时间索引(int 年份, int 索引)
        {
            var 余数 = 索引 % 总节气数;
            var 进位 = 索引 < 0 && 余数 == 0 ? 索引 / 总节气数 + 1 : 索引 / 总节气数;
            var 修正 = 索引 < 0 ? 进位 - 1 : 进位;
            var 查年 = 年份 + 修正;
            var 查节 = 常用方法.序数取余(索引, 总节气数);
            return 基准时间.AddMinutes(年份修正分钟(查年) + 节气修正分钟[查节]);
        }

        #endregion

    }
}