namespace 阴阳易演.容器类
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 查询类;
    using 计算类;

    public class 干支历
    {
        #region 构造
        public 干支历(DateTime 时间)
        {
            // 阴历计算
            阳历转阴历(时间, (年, 月, 日, 闰) =>
            {
                阴历年 = 年;
                阴历月 = 月;
                阴历日 = 日;
                是闰月 = 闰;
                阴历 = $"{年份名称(阴历年)}{(闰 ? "闰" : string.Empty)}{月份名称(阴历月)}{日期名称(阴历日, false)}";
            });
            // 甲子计算
            年柱 = 年柱计算(时间);
            月柱 = 月柱计算(时间, 年柱.天干);
            日时计算(时间, (日, 时) =>
            {
                日柱 = 日;
                时柱 = 时;
            });
            // 月破计算
            月破 = 月支查月破(月柱.地支);
            // 旬空计算
            旬空 = 日柱算旬空(日柱);
            // 神煞计算
            神煞 = 日支时辰算神煞(日柱.地支, 时柱.地支);
        }

        #endregion

        #region 属性
        public int 阴历年 { get; private set; }
        public int 阴历月 { get; private set; }
        public int 阴历日 { get; private set; }
        public bool 是闰月 { get; private set; }
        public string 阴历 { get; private set; }
        public 甲子 年柱 { get; }
        public 甲子 月柱 { get; }
        public 甲子 日柱 { get; private set; }
        public 甲子 时柱 { get; private set; }
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
        public static 甲子 春节后年柱计算(int 年份)
        {
            if (年份 >= 0)
            {
                var 天干配数 = new Dictionary<int, 天干>
                {
                    { 4, 天干.甲 },
                    { 5, 天干.乙 },
                    { 6, 天干.丙 },
                    { 7, 天干.丁 },
                    { 8, 天干.戊 },
                    { 9, 天干.己 },
                    { 0, 天干.庚 },
                    { 1, 天干.辛 },
                    { 2, 天干.壬 },
                    { 3, 天干.癸 }
                };
                var 地支配数 = new Dictionary<int, 地支>
                {
                    { 4, 地支.子 },
                    { 5, 地支.丑 },
                    { 6, 地支.寅 },
                    { 7, 地支.卯 },
                    { 8, 地支.辰 },
                    { 9, 地支.巳 },
                    { 10, 地支.午 },
                    { 11, 地支.未 },
                    { 0, 地支.申 },
                    { 1, 地支.酉 },
                    { 2, 地支.戌 },
                    { 3, 地支.亥 }
                };
                var 干数 = 年份 % 10;
                var 支数 = 年份 % 12;
                var 年干 = 天干配数[干数];
                var 年支 = 地支配数[支数];
                return new 甲子(年干, 年支);
            }
            else
            {
                var 天干配数 = new Dictionary<int, 天干>
                {
                    { 1, 天干.甲 },
                    { 2, 天干.乙 },
                    { 3, 天干.丙 },
                    { 4, 天干.丁 },
                    { 5, 天干.戊 },
                    { 6, 天干.己 },
                    { 7, 天干.庚 },
                    { 8, 天干.辛 },
                    { 9, 天干.壬 },
                    { 0, 天干.癸 }
                };
                var 地支配数 = new Dictionary<int, 地支>
                {
                    { 1, 地支.子 },
                    { 2, 地支.丑 },
                    { 3, 地支.寅 },
                    { 4, 地支.卯 },
                    { 5, 地支.辰 },
                    { 6, 地支.巳 },
                    { 7, 地支.午 },
                    { 8, 地支.未 },
                    { 9, 地支.申 },
                    { 10, 地支.酉 },
                    { 11, 地支.戌 },
                    { 0, 地支.亥 }
                };
                var 干数 = 常用方法.序数取余(8 - Math.Abs(年份) % 10, 10);
                var 支数 = 常用方法.序数取余(10 - Math.Abs(年份) % 12, 12);
                var 年干 = 天干配数[干数];
                var 年支 = 地支配数[支数];
                return new 甲子(年干, 年支);
            }
        }
        public static 甲子 年柱计算(DateTime 时间)
        {
            var 年份 = 时间.Year;
            var 春节 = new DateTime(年份, 1, 1, new ChineseLunisolarCalendar());
            var 年柱 = 春节后年柱计算(年份);
            return 时间 < 春节 ? new 甲子(年柱.序数 - 1) : 年柱;
        }
        public static 甲子 月柱计算(DateTime 时间, 天干 年干)
        {
            var 节气 = new 节气时间(时间);
            var 月首 = 年干.五虎遁();
            var 首序 = 干支表.获取天干序数(月首);
            var 月干 = 干支表.天干查询(首序 + 节气.阴历月 - 1);
            return new 甲子(月干, 节气.地支月);
        }
        public static void 日时计算(DateTime 时间, Action<甲子, 甲子> 返回结果)
        {
            // 计算日柱
            var 年份 = 时间.Year;
            var 当年日数 = (int)(时间 - new DateTime(年份, 1, 1)).TotalDays + 1;
            var 甲子余数 = ((年份 - 1) * 5 + (年份 - 1) / 4 + 当年日数) % 60;
            var 日干序 = 甲子余数 % 10 - 1;
            var 日支序 = 甲子余数 % 12 - 1;
            var 日干 = 干支表.天干查询(日干序);
            var 日支 = 干支表.地支查询(日支序);
            var 日柱 = new 甲子(日干, 日支);
            // 计算时柱
            var 时支 = 时间.时辰地支(out var 选项);
            // 晚子时算下一天
            if (选项 == 时间计算.早晚子.晚子时)
            {
                日柱 = new 甲子(日柱.序数 + 1);
            }
            var 时干 = 日柱.天干.五鼠遁(时支);
            var 时柱 = new 甲子(时干, 时支);
            返回结果.Invoke(日柱, 时柱);
        }
        public static DateTime 阴历转阳历(int 阴历年, int 阴历月, int 阴历日, bool 是闰月 = false)
        {
            var 阴历 = new ChineseLunisolarCalendar();
            var 闰月 = 阴历.GetLeapMonth(阴历年);
            if (闰月 > 0)
            {
                if (是闰月 && 闰月 - 1 == 阴历月)
                {
                    阴历月 = 闰月;
                }
                else if (阴历月 > 闰月)
                {
                    阴历月++;
                }
            }
            return new DateTime(阴历年, 阴历月, 阴历日, 阴历);
        }
        public static void 阳历转阴历(DateTime 时间, Action<int, int, int, bool> 返回结果)
        {
            var 阴历 = new ChineseLunisolarCalendar();
            var 阴历年 = 阴历.GetYear(时间);
            var 阴历月 = 阴历.GetMonth(时间);
            var 阴历日 = 阴历.GetDayOfMonth(时间);
            var 闰月 = 阴历.GetLeapMonth(阴历年);
            var 是闰月 = false;
            if (闰月 > 0)
            {
                if (闰月 == 阴历月)
                {
                    是闰月 = true;
                    阴历月--;
                }
                else if (阴历月 > 闰月)
                {
                    阴历月--;
                }
            }
            返回结果.Invoke(阴历年, 阴历月, 阴历日, 是闰月);
        }

        #endregion

    }
}
