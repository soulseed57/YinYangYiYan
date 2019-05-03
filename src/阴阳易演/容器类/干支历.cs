namespace 阴阳易演.容器类
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using 具象类.天干;
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
            阴历 = 农历.ChineseDateString;
            // 甲子计算
            年柱 = new 甲子(农历.GanZhiYearString);
            月柱 = 月柱计算(时间, 年柱.天干);
            日柱 = 日柱计算(时间);
            时柱 = 时柱计算(时间);
            // 月破计算
            月破 = 月支查月破(月柱.地支);
            // 旬空计算
            旬空 = 日柱算旬空(日柱);
            // 神煞计算
            神煞 = 日支时辰算神煞(日柱.地支, 时柱.地支);
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
        public 神煞 神煞 { get; }

        #endregion

        #region 方法
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
        public static 神煞 日支时辰算神煞(地支 日支, 地支 时辰)
        {
            var 日序 = 干支表.获取地支序数(日支);
            var 时序 = 干支表.获取地支序数(时辰);
            var 起序表 = new int[] { 8, 10, 0, 2, 4, 6 };
            var 起序 = 起序表[日序 % 6];
            var 神煞序 = 干支表.地支数 - 起序 + 时序;
            return new 神煞(神煞序);
        }
        public static 地支 节气归支查询(节气枚举 枚)
        {
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
                default:
                    throw new Exception($"未找到匹配的枚举,当前输入:{枚}");
            }
        }
        public static int 节气归月查询(节气枚举 枚)
        {
            var 支 = 节气归支查询(枚);
            return 月支列表.IndexOf(支) + 1;
        }
        public static 甲子 月柱计算(DateTime 时间, 天干 年干)
        {
            var 月首 = 五虎遁(年干);
            var 节气 = 节气表.节气枚举查询(时间);
            var 月支 = 节气归支查询(节气);
            var 归月 = 节气归月查询(节气);
            var 首序 = 干支表.获取天干序数(月首);
            var 月干 = 干支表.天干查询(首序 + 归月 - 1);
            return new 甲子(月干, 月支);
        }
        public static 甲子 日柱计算(DateTime 时间)
        {
            var 公元年数 = 时间.Year;
            var 当年日数 = (int)(时间 - new DateTime(时间.Year, 1, 1)).TotalDays + 1;
            var 甲子余数 = ((公元年数 - 1) * 5 + (公元年数 - 1) / 4 + 当年日数) % 60;
            var 日干序 = 甲子余数 % 10 - 1;
            var 日支序 = 甲子余数 % 12 - 1;
            var 日干 = 干支表.天干查询(日干序);
            var 日支 = 干支表.地支查询(日支序);
            return new 甲子(日干, 日支);
        }
        public static 地支 换算时辰(DateTime 时间)
        {
            var 当天起始 = new DateTime(时间.Year, 时间.Month, 时间.Day);
            var 当前总时 = 时间 - 当天起始;
            var 时 = 当前总时.TotalHours;
            if (时 > 23 || 时 < 1)
            {
                return 地支.子;
            }
            if (1 < 时 && 时 < 3)
            {
                return 地支.丑;
            }
            if (3 < 时 && 时 < 5)
            {
                return 地支.寅;
            }
            if (5 < 时 && 时 < 7)
            {
                return 地支.卯;
            }
            if (7 < 时 && 时 < 9)
            {
                return 地支.辰;
            }
            if (9 < 时 && 时 < 11)
            {
                return 地支.巳;
            }
            if (11 < 时 && 时 < 13)
            {
                return 地支.午;
            }
            if (13 < 时 && 时 < 15)
            {
                return 地支.未;
            }
            if (15 < 时 && 时 < 17)
            {
                return 地支.申;
            }
            if (17 < 时 && 时 < 19)
            {
                return 地支.酉;
            }
            if (19 < 时 && 时 < 21)
            {
                return 地支.戌;
            }
            if (21 < 时 && 时 < 23)
            {
                return 地支.亥;
            }
            throw new Exception("未找到匹配的时辰");
        }
        public static 甲子 时柱计算(DateTime 时间)
        {
            var 时支 = 换算时辰(时间);
            var 支序 = 干支表.地支列表.IndexOf(时支);
            var 日干 = 日柱计算(时间).天干;
            var 首 = 五鼠遁(日干);
            var 序首 = 干支表.天干列表.IndexOf(首);
            var 干序 = 序首 + 支序;
            var 时干 = 干支表.天干查询(干序);
            var 时柱 = new 甲子(时干, 时支);
            return 时柱;
        }
        public static 天干 五鼠遁(天干 干)
        {
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    return 天干.甲;// 甲己还加甲
                case 乙 _:
                case 庚 _:
                    return 天干.丙;// 乙庚丙作初
                case 丙 _:
                case 辛 _:
                    return 天干.戊;// 丙辛寻戊起
                case 丁 _:
                case 壬 _:
                    return 天干.庚;// 丁壬庚子居
                case 戊 _:
                case 癸 _:
                    return 天干.壬;// 戊癸何方发，壬子是真途
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
        }
        public static 天干 五虎遁(天干 干)
        {
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    return 天干.丙;// 甲己之年丙作首
                case 乙 _:
                case 庚 _:
                    return 天干.戊;// 乙庚之岁戊为头
                case 丙 _:
                case 辛 _:
                    return 天干.庚;// 丙辛必定寻庚起
                case 丁 _:
                case 壬 _:
                    return 天干.壬;// 丁壬壬位顺水流
                case 戊 _:
                case 癸 _:
                    return 天干.甲;// 若问戊癸何处起，甲寅之上好追求
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
        }

        #endregion

        #region 内部参数
        static readonly List<地支> 月支列表 = new List<地支>
        {
            地支.寅, 地支.卯, 地支.辰, 地支.巳,
            地支.午, 地支.未, 地支.申, 地支.酉,
            地支.戌, 地支.亥, 地支.子, 地支.丑,
        };

        #endregion

    }
}
