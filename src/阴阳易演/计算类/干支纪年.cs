using System;
using System.Text;
using System.Collections.Generic;

namespace 阴阳易演.计算类
{
    using 容器类;
    using 引用库;
    using 抽象类;
    using 查询类;
    using static 查询类.二十四节气;

    public class 干支纪年
    {
        #region 天清
        public 干支纪年(DateTime 时间)
        {
            var 中国农历类 = new ChineseCalendar(时间);
            //阴历计算
            阴历年 = 中国农历类.ChineseYear;
            阴历月 = 中国农历类.ChineseMonth;
            阴历日 = 中国农历类.ChineseDay;
            阴历 = $"{年份名称(阴历年)}年{月份名称(阴历月)}月{日期名称(阴历日)}";
            //甲子计算
            年柱 = 计算年柱(阴历年);
            月柱 = 计算月柱(时间);
            日柱 = 计算日柱(时间);
            var 时支 = 计算时支(时间.Hour);
            时柱 = 计算时柱(日柱.天干, 时支);
            //旬空计算
            旬空 = 查询旬空(日柱);
        }

        #endregion

        #region 地浊
        public int 阴历年 { get; protected set; }
        public int 阴历月 { get; protected set; }
        public int 阴历日 { get; protected set; }
        public string 阴历 { get; protected set; }
        public 甲子 年柱 { get; protected set; }
        public 甲子 月柱 { get; protected set; }
        public 甲子 日柱 { get; protected set; }
        public 甲子 时柱 { get; protected set; }
        public 地支[] 旬空 { get; protected set; }

        #endregion

        #region 运算
        public static 地支 月支查询(DateTime 时间)
        {
            var 枚 = 节气查询(时间);
            switch (枚)
            {
                case 节气枚举.立春:
                case 节气枚举.雨水:
                    return 地支.寅;
                case 节气枚举.惊蛰:
                case 节气枚举.春分:
                    return 地支.卯;
                case 节气枚举.清明:
                case 节气枚举.谷雨:
                    return 地支.辰;
                case 节气枚举.立夏:
                case 节气枚举.小满:
                    return 地支.巳;
                case 节气枚举.芒种:
                case 节气枚举.夏至:
                    return 地支.午;
                case 节气枚举.小暑:
                case 节气枚举.大暑:
                    return 地支.未;
                case 节气枚举.立秋:
                case 节气枚举.处暑:
                    return 地支.申;
                case 节气枚举.白露:
                case 节气枚举.秋分:
                    return 地支.酉;
                case 节气枚举.寒露:
                case 节气枚举.霜降:
                    return 地支.戌;
                case 节气枚举.立冬:
                case 节气枚举.小雪:
                    return 地支.亥;
                case 节气枚举.大雪:
                case 节气枚举.冬至:
                    return 地支.子;
                case 节气枚举.小寒:
                case 节气枚举.大寒:
                    return 地支.丑;
            }
            throw new Exception($"节气枚举[{枚}]输入错误");
        }
        public static 天干 月干查询(天干 干, 地支 支)
        {
            return 干支表.五鼠遁(干, 支);
        }
        public static 甲子 计算年柱(int 年)
        {
            int 序数;
            if (年 > 0)
            {
                var 年数 = 年;
                序数 = 年数 % 60 - 3;
            }
            else
            {
                var 年数 = Math.Abs(年);
                序数 = 年数 % 60 >= 58 ? 118 - 年数 % 60 : 58 - 年数 % 60;
            }
            try
            {
                return 甲子表.甲子查询(序数 - 1);
            }
            catch (Exception e)
            {
                throw new Exception($"计算年柱失败:{e.Message}\n当前输入[序数:{序数} 年:{年}]");
            }
        }
        public static 甲子 计算月柱(DateTime 时间)
        {
            var 年干 = 计算年柱(时间.Year).天干;
            var 月支 = 月支查询(时间);
            var 月干 = 月干查询(年干, 月支);
            return 干支表.六十甲子(月干, 月支);
        }
        public static 甲子 计算日柱(DateTime 时间)
        {
            var 甲子日 = new DateTime(1904, 1, 31);
            var 天数 = (时间 - 甲子日).Days;
            var 序数 = 天数 < 0 ? 60 + 天数 % 60 : 天数 % 60;
            try
            {
                return 甲子表.甲子查询(序数);
            }
            catch (Exception e)
            {
                throw new Exception($"计算日柱失败:{e.Message}\n当前输入[序数:{序数} 时间:{时间:yyyy-MM-dd HH}]");
            }
        }
        public static 地支 计算时支(int 时)
        {
            地支 时辰 = null;
            switch (时)
            {
                case 23:
                case 0:
                    时辰 = 地支.子;
                    break;
                case 1:
                case 2:
                    时辰 = 地支.丑;
                    break;
                case 3:
                case 4:
                    时辰 = 地支.寅;
                    break;
                case 5:
                case 6:
                    时辰 = 地支.卯;
                    break;
                case 7:
                case 8:
                    时辰 = 地支.辰;
                    break;
                case 9:
                case 10:
                    时辰 = 地支.巳;
                    break;
                case 11:
                case 12:
                    时辰 = 地支.午;
                    break;
                case 13:
                case 14:
                    时辰 = 地支.未;
                    break;
                case 15:
                case 16:
                    时辰 = 地支.申;
                    break;
                case 17:
                case 18:
                    时辰 = 地支.酉;
                    break;
                case 19:
                case 20:
                    时辰 = 地支.戌;
                    break;
                case 21:
                case 22:
                    时辰 = 地支.亥;
                    break;
                default:
                    break;
            }
            return 时辰;
        }
        public static 甲子 计算时柱(天干 日干, 地支 时支)
        {
            var 日干序 = 干支表.获取天干序数(日干);
            var 时支序 = 干支表.获取地支序数(时支);
            var 时干序 = (日干序 * 2 + 时支序) % 10;
            var 时干名 = 干支表.获取天干名称(时干序);
            var 时干 = 干支表.天干查询(时干名);
            return new 甲子(时干, 时支);
        }
        public static 地支[] 查询旬空(甲子 日柱)
        {
            var 旬空 = new List<地支>();
            var 天干数 = 枚举转换类<干支表.天干枚举>.获取序数(日柱.天干.名称) + 1;
            var 地支数 = 枚举转换类<干支表.地支枚举>.获取序数(日柱.地支.名称) + 1;
            var 旬空数 = 地支数 - 天干数;
            旬空数 = 旬空数 < 0 ? 12 + 旬空数 : 旬空数;//为负数时补足一个循环
            switch (旬空数)
            {
                case 0:
                case 12:
                    旬空.Add(地支.戌);
                    旬空.Add(地支.亥);
                    break;
                case 2:
                    旬空.Add(地支.子);
                    旬空.Add(地支.丑);
                    break;
                case 4:
                    旬空.Add(地支.寅);
                    旬空.Add(地支.卯);
                    break;
                case 6:
                    旬空.Add(地支.辰);
                    旬空.Add(地支.巳);
                    break;
                case 8:
                    旬空.Add(地支.午);
                    旬空.Add(地支.未);
                    break;
                case 10:
                    旬空.Add(地支.申);
                    旬空.Add(地支.酉);
                    break;
                default:
                    throw new Exception($"旬空数计算错误,当前参数:[天干数:{天干数} 地支数:{地支数} 旬空数:{旬空数} 日柱天干:{日柱.天干} 日柱地支:{日柱.地支}]");
            }
            return 旬空.ToArray();
        }
        public static string 年份名称(int 年, bool 加后缀 = true)
        {
            var capital = new[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            var 名称 = new StringBuilder();
            var y = Math.Abs(年);
            var count = capital.Length;
            do
            {
                名称.Insert(0, capital[y % count]);
                y = y / count;
            } while (y > 0);
            if (加后缀) 名称.Append("年");
            return 名称.ToString();
        }
        public static string 月份名称(int 月, bool 加后缀 = true)
        {
            if (月 < 1 || 月 > 12) throw new Exception($"输入月份错误,当前输入{月}");
            var 月名 = new[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };
            var 索引 = 月 - 1;
            var 名称 = new StringBuilder();
            名称.Append(月名[索引 % 月名.Length]);
            if (加后缀) 名称.Append("月");
            return 名称.ToString();
        }
        public static string 日期名称(int 日, bool 加后缀 = true)
        {
            if (日 < 1 || 日 > 31) throw new Exception($"输入日期错误,当前输入{日}");
            var 日十 = new[] { "初", "十", "廿", "卅" };
            var 日个 = new[] { "十", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            var 名称 = new StringBuilder();
            var 十 = 日 == 10 ? 0 : 日 / 10;
            var 个 = 日 % 10;
            名称.Append(日十[十 % 日十.Length]);
            名称.Append(日个[个 % 日个.Length]);
            if (加后缀) 名称.Append("日");
            return 名称.ToString();
        }

        #endregion

    }
}
