namespace 阴阳易演.容器类
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 查询类;

    public class 干支历
    {
        #region 构造
        public 干支历(DateTime 时间)
        {
            var 农历 = new ChineseCalendar(时间);
            // 阴历计算
            阴历年 = 农历.ChineseYear;
            阴历月 = 农历.ChineseMonth;
            阴历日 = 农历.ChineseDay;
            阴历 = $"{年份名称(阴历年)}{月份名称(阴历月)}{日期名称(阴历日)}";
            // 甲子计算
            年柱 = new 甲子(农历.GanZhiYearString);
            月柱 = new 甲子(农历.GanZhiMonthString);
            日柱 = new 甲子(农历.GanZhiDayString);
            时柱 = new 甲子(农历.GanZhiHourString);
            // 月破计算
            月破 = 月支查月破(月柱.地支);
            // 旬空计算
            旬空 = 日柱算旬空(日柱);
        }

        #endregion

        #region 属性
        public int 阴历年 { get; }
        public int 阴历月 { get; }
        public int 阴历日 { get; }
        public string 阴历 { get; }
        public 甲子 年柱 { get; }
        public 甲子 月柱 { get; }
        public 甲子 日柱 { get; }
        public 甲子 时柱 { get; }
        public 地支 月破 { get; }
        public 地支[] 旬空 { get; }

        #endregion

        #region 方法
        public static 地支 月支查月破(地支 月支)
        {
            var 序数 = 干支表.获取地支序数(月支);
            return 干支表.地支查询(序数 + 6);
        }
        public static 地支[] 日柱算旬空(甲子 日柱)
        {
            var 旬空 = new List<地支>();
            var 天干数 = 枚举转换类<天干枚举>.获取序数(日柱.天干.名称) + 1;
            var 地支数 = 枚举转换类<地支枚举>.获取序数(日柱.地支.名称) + 1;
            var 旬空数 = 地支数 - 天干数;
            旬空数 = 旬空数 < 0 ? 12 + 旬空数 : 旬空数;// 为负数时补足一个循环
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
            if (加后缀)
            {
                名称.Append("年");
            }

            return 名称.ToString();
        }
        public static string 月份名称(int 月, bool 加后缀 = true)
        {
            if (月 < 1 || 月 > 12)
            {
                throw new Exception($"输入月份错误,当前输入{月}");
            }

            var 月名 = new[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };
            var 索引 = 月 - 1;
            var 名称 = new StringBuilder();
            名称.Append(月名[索引 % 月名.Length]);
            if (加后缀)
            {
                名称.Append("月");
            }

            return 名称.ToString();
        }
        public static string 日期名称(int 日, bool 加后缀 = true)
        {
            if (日 < 1 || 日 > 31)
            {
                throw new Exception($"输入日期错误,当前输入{日}");
            }

            var 日十 = new[] { "初", "十", "廿", "卅" };
            var 日个 = new[] { "十", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            var 名称 = new StringBuilder();
            var 十 = 日 == 10 ? 0 : 日 / 10;
            var 个 = 日 % 10;
            名称.Append(日十[十 % 日十.Length]);
            名称.Append(日个[个 % 日个.Length]);
            if (加后缀)
            {
                名称.Append("日");
            }

            return 名称.ToString();
        }

        #endregion

    }
}
