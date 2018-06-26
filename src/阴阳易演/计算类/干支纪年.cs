using System;
using System.Text;

namespace 阴阳易演.计算类
{
    using System.Collections.Generic;
    using 具象类.天干;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 查询类;

    public class 干支纪年
    {
        public 干支纪年(DateTime 时间)
        {
            var 中国农历类 = new ChineseCalendar(时间);
            // 阴历计算
            阴历年 = 中国农历类.ChineseYear;
            阴历月 = 中国农历类.ChineseMonth;
            阴历日 = 中国农历类.ChineseDay;
            // 甲子计算
            年柱 = 计算年柱(时间);
            月柱 = 计算月柱(时间);
            日柱 = 计算日柱(时间);
            时辰 = 计算时辰(时间.Hour);
            // 旬空计算
            旬空 = 查询旬空(日柱);
        }
        public int 阴历年 { get; protected set; }
        public int 阴历月 { get; protected set; }
        public int 阴历日 { get; protected set; }

        public 甲子 年柱 { get; protected set; }
        public 甲子 月柱 { get; protected set; }
        public 甲子 日柱 { get; protected set; }
        public 地支 时辰 { get; protected set; }
        public 地支[] 旬空 { get; protected set; }

        #region 计算
        // 内部
        static int 获取正月序首(甲子 甲子年)
        {
            var 序首 = -1;
            switch (甲子年.天干)
            {
                case 甲 _:
                case 己 _:
                    序首 = 干支关系.天干转序数(天干.丙);
                    break;
                case 乙 _:
                case 庚 _:
                    序首 = 干支关系.天干转序数(天干.戊);
                    break;
                case 丙 _:
                case 辛 _:
                    序首 = 干支关系.天干转序数(天干.庚);
                    break;
                case 丁 _:
                case 壬 _:
                    序首 = 干支关系.天干转序数(天干.壬);
                    break;
                case 戊 _:
                case 癸 _:
                    序首 = 干支关系.天干转序数(天干.甲);
                    break;
            }
            return 序首;
        }
        static int 基准天数序数(DateTime 当前时间, DateTime 基准时间, int 求余数)
        {
            var span = (当前时间 - 基准时间).Days;
            return span < 0 ? 求余数 + span % 求余数 : span % 求余数;
        }
        // 公开
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
        public static 地支 计算时辰(int 时)
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
        public static 地支[] 查询旬空(甲子 日柱)
        {
            var 旬空 = new List<地支>();
            var 天干数 = 枚举转换类<干支关系.天干枚举>.获取序数(常用方法.获取类名(日柱.天干)) + 1;
            var 地支数 = 枚举转换类<干支关系.地支枚举>.获取序数(常用方法.获取类名(日柱.地支)) + 1;
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
        // 动态
        public 甲子 计算年柱(DateTime 时间)
        {
            return 计算年柱(阴历年);
        }
        public 甲子 计算月柱(DateTime 时间)
        {
            var 月份 = 阴历月;
            // 计算月干
            var 序首 = 获取正月序首(年柱);
            var 月干 = 干支关系.序数转天干(序首 + 月份 - 1);
            // 计算月支
            var 月支 = 干支关系.序数转地支(月份 + 2);
            // 计算月柱
            return 干支关系.六十甲子(月干, 月支);
        }
        public 甲子 计算日柱(DateTime 时间)
        {
            var 甲子日 = new DateTime(1904, 1, 31);
            var 序数 = 基准天数序数(时间, 甲子日, 60);
            try
            {
                return 甲子表.甲子查询(序数);
            }
            catch (Exception e)
            {
                throw new Exception($"计算日柱失败:{e.Message}\n当前输入[序数:{序数} 时间:{时间:yyyy-MM-dd HH}]");
            }
        }

        #endregion
    }
}
