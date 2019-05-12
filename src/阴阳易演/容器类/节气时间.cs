namespace 阴阳易演.容器类
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 查询类;

    public class 节气时间
    {
        #region 构造
        public 节气时间(DateTime 日期)
        {
            节气时间查询(日期, (时, 节) =>
            {
                名称 = 枚举转换类<节气节令>.获取名称(节);
                时间 = 时;
                枚举 = 节;
                地支月 = 节气地支月查询(节);
                阴历月 = 节气阴历月查询(节);
                节后日 = (int)(日期 - 时).TotalDays;
            }, 文 => throw new Exception(文));
        }

        #endregion

        #region 属性
        public string 名称 { get; private set; }
        public DateTime 时间 { get; private set; }
        public 节气节令 枚举 { get; private set; }
        public 地支 地支月 { get; private set; }
        public int 阴历月 { get; private set; }
        public int 节后日 { get; private set; }

        #endregion

        #region 方法
        public static DateTime 节气时间查询(int 年份, 节气节令 枚举)
        {
            var 索引 = 索引字典[枚举];
            return 节气时间索引(年份, 索引);
        }
        public static void 节气时间查询(DateTime 日期, Action<DateTime, 节气节令> 返回成功, Action<string> 返回失败)
        {
            DateTime? 末次时间 = null;
            var 末次索引 = -1;
            for (var i = -1; i <= 总节气数; i++)
            {
                var 节气时间 = 节气时间索引(日期.Year, i);
                if (节气时间 > 日期)
                {
                    break;
                }
                末次时间 = 节气时间;
                末次索引 = i;
            }
            if (末次时间 != null)
            {
                var 索引 = 常用方法.序数取余(末次索引, 总节气数);
                var 枚举 = 枚举字典[索引];
                返回成功.Invoke(末次时间.Value, 枚举);
            }
            else
            {
                返回失败.Invoke($"日期[{日期:yyyy-MM-dd HH:mm:ss}]的节气时间未找到");
            }
        }
        public static DateTime 上一节令时间(DateTime 日期)
        {
            var 年 = 日期.Year;
            DateTime? 末次时间 = null;
            for (var i = -2; i <= 总节气数 + 1; i++)
            {
                var 查节序 = 常用方法.序数取余(i, 总节气数);
                var 查节枚 = 枚举转换类<节气节令>.获取枚举(查节序);
                if (!节令列表.Contains(查节枚))
                {
                    continue;
                }
                var 节气时间 = 节气时间索引(年, i);
                if (节气时间 > 日期)
                {
                    break;
                }
                末次时间 = 节气时间;
            }
            return 末次时间 ?? throw new Exception($"[{日期:yyyy-MM-dd HH:mm:ss}]的上一节令时间未找到");
        }
        public static DateTime 下一节令时间(DateTime 日期)
        {
            var 年 = 日期.Year;
            DateTime? 末次时间 = null;
            for (var i = -2; i <= 总节气数 + 1; i++)
            {
                var 查节序 = 常用方法.序数取余(i, 总节气数);
                var 查节枚 = 枚举转换类<节气节令>.获取枚举(查节序);
                if (!节令列表.Contains(查节枚))
                {
                    continue;
                }
                var 节气时间 = 节气时间索引(年, i);
                if (节气时间 > 日期)
                {
                    末次时间 = 节气时间;
                    break;
                }
            }
            return 末次时间 ?? throw new Exception($"[{日期:yyyy-MM-dd HH:mm:ss}]的下一节令时间未找到");
        }
        public static 地支 节气地支月查询(节气节令 枚举)
        {
            switch (枚举)
            {
                case 节气节令.立春:
                case 节气节令.雨水:
                    return 地支.寅;
                case 节气节令.惊蛰:
                case 节气节令.春分:
                    return 地支.卯;
                case 节气节令.清明:
                case 节气节令.谷雨:
                    return 地支.辰;
                case 节气节令.立夏:
                case 节气节令.小满:
                    return 地支.巳;
                case 节气节令.芒种:
                case 节气节令.夏至:
                    return 地支.午;
                case 节气节令.小暑:
                case 节气节令.大暑:
                    return 地支.未;
                case 节气节令.立秋:
                case 节气节令.处暑:
                    return 地支.申;
                case 节气节令.白露:
                case 节气节令.秋分:
                    return 地支.酉;
                case 节气节令.寒露:
                case 节气节令.霜降:
                    return 地支.戌;
                case 节气节令.立冬:
                case 节气节令.小雪:
                    return 地支.亥;
                case 节气节令.大雪:
                case 节气节令.冬至:
                    return 地支.子;
                case 节气节令.小寒:
                case 节气节令.大寒:
                    return 地支.丑;
                default:
                    throw new Exception($"未找到匹配的枚举,当前输入:{枚举}");
            }
        }
        public static int 节气阴历月查询(节气节令 枚举)
        {
            var 支 = 节气地支月查询(枚举);
            var 月支列表 = 常用方法.列表指定首位(干支表.地支列表.ToArray(), 2).ToList();
            return 月支列表.IndexOf(支) + 1;
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
        static readonly Dictionary<节气节令, int> 索引字典 = new Dictionary<节气节令, int>
        {
            { 节气节令.小寒, 0 }, { 节气节令.大寒, 1 },
            { 节气节令.立春, 2 }, { 节气节令.雨水, 3 },
            { 节气节令.惊蛰, 4 }, { 节气节令.春分, 5 },
            { 节气节令.清明, 6 }, { 节气节令.谷雨, 7 },
            { 节气节令.立夏, 8 }, { 节气节令.小满, 9 },
            { 节气节令.芒种, 10 }, { 节气节令.夏至, 11 },
            { 节气节令.小暑, 12 }, { 节气节令.大暑, 13 },
            { 节气节令.立秋, 14 }, { 节气节令.处暑, 15 },
            { 节气节令.白露, 16 }, { 节气节令.秋分, 17 },
            { 节气节令.寒露, 18 }, { 节气节令.霜降, 19 },
            { 节气节令.立冬, 20 }, { 节气节令.小雪, 21 },
            { 节气节令.大雪, 22 }, { 节气节令.冬至, 23 }
        };
        static readonly Dictionary<int, 节气节令> 枚举字典 = new Dictionary<int, 节气节令>
        {
            { 0, 节气节令.小寒 }, { 1, 节气节令.大寒 },
            { 2, 节气节令.立春 }, { 3, 节气节令.雨水 },
            { 4, 节气节令.惊蛰 }, { 5, 节气节令.春分 },
            { 6, 节气节令.清明 }, { 7, 节气节令.谷雨 },
            { 8, 节气节令.立夏 }, { 9, 节气节令.小满 },
            { 10, 节气节令.芒种 }, { 11, 节气节令.夏至 },
            { 12, 节气节令.小暑 }, { 13, 节气节令.大暑 },
            { 14, 节气节令.立秋 }, { 15, 节气节令.处暑 },
            { 16, 节气节令.白露 }, { 17, 节气节令.秋分 },
            { 18, 节气节令.寒露 }, { 19, 节气节令.霜降 },
            { 20, 节气节令.立冬 }, { 21, 节气节令.小雪 },
            { 22, 节气节令.大雪 }, { 23, 节气节令.冬至 }
        };
        static readonly List<节气节令> 节令列表 = new List<节气节令>
        {
            节气节令.小寒,
            节气节令.立春,
            节气节令.惊蛰,
            节气节令.清明,
            节气节令.立夏,
            节气节令.芒种,
            节气节令.小暑,
            节气节令.立秋,
            节气节令.白露,
            节气节令.寒露,
            节气节令.立冬,
            节气节令.大雪,
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