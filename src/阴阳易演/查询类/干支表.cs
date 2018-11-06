using System;
using System.Text;

namespace 阴阳易演.查询类
{
    using System.Collections.Generic;
    using 具象类.地支;
    using 具象类.天干;
    using 容器类;
    using 引用库;
    using 抽象类;

    public static class 干支表
    {
        static 干支表()
        {
            天干数 = 枚举转换类<天干枚举>.获取所有枚举().Length;
            地支数 = 枚举转换类<地支枚举>.获取所有枚举().Length;
        }
        public static readonly int 天干数;
        public static readonly int 地支数;
        public enum 天干枚举 { 甲, 乙, 丙, 丁, 戊, 己, 庚, 辛, 壬, 癸 }
        public enum 地支枚举 { 子, 丑, 寅, 卯, 辰, 巳, 午, 未, 申, 酉, 戌, 亥 }
        public static List<天干> 天干列表 = new List<天干> { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
        public static List<地支> 地支列表 = new List<地支> { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };

        #region 天干枚举
        public static int 获取天干序数(天干 干)
        {
            return 枚举转换类<天干枚举>.获取序数(干.名称);
        }
        public static int 获取天干序数(天干枚举 枚)
        {
            return 枚举转换类<天干枚举>.获取序数(枚);
        }
        public static 天干枚举 获取天干枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取枚举(序);
        }
        public static string 获取天干名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取名称(序);
        }

        #endregion

        #region 地支枚举
        public static int 获取地支序数(地支 支)
        {
            return 枚举转换类<地支枚举>.获取序数(支.名称);
        }
        public static int 获取地支序数(地支枚举 枚)
        {
            return 枚举转换类<地支枚举>.获取序数(枚);
        }
        public static 地支枚举 获取地支枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取枚举(序);
        }
        public static string 获取地支名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取名称(序);
        }

        #endregion

        #region 天干查询
        public static 天干 天干查询(天干枚举 枚)
        {
            var 名 = 枚举转换类<天干枚举>.获取名称(枚);
            return 天干查询(名);
        }
        public static 天干 天干查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            var 名 = 枚举转换类<天干枚举>.获取名称(序);
            return 天干查询(名);
        }
        public static 天干 天干查询(string 名)
        {
            天干 结果;
            switch (名)
            {
                case "甲":
                    结果 = 天干.甲;
                    break;
                case "乙":
                    结果 = 天干.乙;
                    break;
                case "丙":
                    结果 = 天干.丙;
                    break;
                case "丁":
                    结果 = 天干.丁;
                    break;
                case "戊":
                    结果 = 天干.戊;
                    break;
                case "己":
                    结果 = 天干.己;
                    break;
                case "庚":
                    结果 = 天干.庚;
                    break;
                case "辛":
                    结果 = 天干.辛;
                    break;
                case "壬":
                    结果 = 天干.壬;
                    break;
                case "癸":
                    结果 = 天干.癸;
                    break;
                default:
                    throw new Exception($"输入的名称[{名}]不是天干");
            }
            return 结果;
        }

        #endregion

        #region 地支查询
        public static 地支 地支查询(地支枚举 枚)
        {
            var 名 = 枚举转换类<地支枚举>.获取名称(枚);
            return 地支查询(名);
        }
        public static 地支 地支查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            var 名 = 枚举转换类<地支枚举>.获取名称(序);
            return 地支查询(名);
        }
        public static 地支 地支查询(string 名)
        {
            地支 结果;
            switch (名)
            {
                case "子":
                    结果 = 地支.子;
                    break;
                case "丑":
                    结果 = 地支.丑;
                    break;
                case "寅":
                    结果 = 地支.寅;
                    break;
                case "卯":
                    结果 = 地支.卯;
                    break;
                case "辰":
                    结果 = 地支.辰;
                    break;
                case "巳":
                    结果 = 地支.巳;
                    break;
                case "午":
                    结果 = 地支.午;
                    break;
                case "未":
                    结果 = 地支.未;
                    break;
                case "申":
                    结果 = 地支.申;
                    break;
                case "酉":
                    结果 = 地支.酉;
                    break;
                case "戌":
                    结果 = 地支.戌;
                    break;
                case "亥":
                    结果 = 地支.亥;
                    break;
                default:
                    throw new Exception($"输入的名称[{名}]不是地支");
            }
            return 结果;
        }

        #endregion

        #region 运算
        public static string 十二长生(天干 干, 地支 支)
        {
            var 结果 = String.Empty;
            switch (干)
            {
                case 甲木 _ when 支 is 亥:
                case 丙火 _ when 支 is 寅:
                case 戊土 _ when 支 is 寅:
                case 庚金 _ when 支 is 巳:
                case 壬水 _ when 支 is 申:
                case 乙木 _ when 支 is 午:
                case 丁火 _ when 支 is 酉:
                case 己土 _ when 支 is 酉:
                case 辛金 _ when 支 is 子:
                case 癸水 _ when 支 is 卯:
                    结果 = "长生";
                    break;
                case 甲木 _ when 支 is 子:
                case 丙火 _ when 支 is 卯:
                case 戊土 _ when 支 is 卯:
                case 庚金 _ when 支 is 午:
                case 壬水 _ when 支 is 酉:
                case 乙木 _ when 支 is 巳:
                case 丁火 _ when 支 is 申:
                case 己土 _ when 支 is 申:
                case 辛金 _ when 支 is 亥:
                case 癸水 _ when 支 is 寅:
                    结果 = "沐浴";
                    break;
                case 甲木 _ when 支 is 丑:
                case 丙火 _ when 支 is 辰:
                case 戊土 _ when 支 is 辰:
                case 庚金 _ when 支 is 未:
                case 壬水 _ when 支 is 戌:
                case 乙木 _ when 支 is 辰:
                case 丁火 _ when 支 is 未:
                case 己土 _ when 支 is 未:
                case 辛金 _ when 支 is 戌:
                case 癸水 _ when 支 is 丑:
                    结果 = "冠带";
                    break;
                case 甲木 _ when 支 is 寅:
                case 丙火 _ when 支 is 巳:
                case 戊土 _ when 支 is 巳:
                case 庚金 _ when 支 is 申:
                case 壬水 _ when 支 is 亥:
                case 乙木 _ when 支 is 卯:
                case 丁火 _ when 支 is 午:
                case 己土 _ when 支 is 午:
                case 辛金 _ when 支 is 酉:
                case 癸水 _ when 支 is 子:
                    结果 = "临官";
                    break;
                case 甲木 _ when 支 is 卯:
                case 丙火 _ when 支 is 午:
                case 戊土 _ when 支 is 午:
                case 庚金 _ when 支 is 酉:
                case 壬水 _ when 支 is 子:
                case 乙木 _ when 支 is 寅:
                case 丁火 _ when 支 is 巳:
                case 己土 _ when 支 is 巳:
                case 辛金 _ when 支 is 申:
                case 癸水 _ when 支 is 亥:
                    结果 = "帝旺";
                    break;
                case 甲木 _ when 支 is 辰:
                case 丙火 _ when 支 is 未:
                case 戊土 _ when 支 is 未:
                case 庚金 _ when 支 is 戌:
                case 壬水 _ when 支 is 丑:
                case 乙木 _ when 支 is 丑:
                case 丁火 _ when 支 is 辰:
                case 己土 _ when 支 is 辰:
                case 辛金 _ when 支 is 未:
                case 癸水 _ when 支 is 戌:
                    结果 = "衰";
                    break;
                case 甲木 _ when 支 is 巳:
                case 丙火 _ when 支 is 申:
                case 戊土 _ when 支 is 申:
                case 庚金 _ when 支 is 亥:
                case 壬水 _ when 支 is 寅:
                case 乙木 _ when 支 is 子:
                case 丁火 _ when 支 is 卯:
                case 己土 _ when 支 is 卯:
                case 辛金 _ when 支 is 午:
                case 癸水 _ when 支 is 酉:
                    结果 = "病";
                    break;
                case 甲木 _ when 支 is 午:
                case 丙火 _ when 支 is 酉:
                case 戊土 _ when 支 is 酉:
                case 庚金 _ when 支 is 子:
                case 壬水 _ when 支 is 卯:
                case 乙木 _ when 支 is 亥:
                case 丁火 _ when 支 is 寅:
                case 己土 _ when 支 is 寅:
                case 辛金 _ when 支 is 巳:
                case 癸水 _ when 支 is 申:
                    结果 = "死";
                    break;
                case 甲木 _ when 支 is 未:
                case 丙火 _ when 支 is 戌:
                case 戊土 _ when 支 is 戌:
                case 庚金 _ when 支 is 丑:
                case 壬水 _ when 支 is 辰:
                case 乙木 _ when 支 is 戌:
                case 丁火 _ when 支 is 丑:
                case 己土 _ when 支 is 丑:
                case 辛金 _ when 支 is 辰:
                case 癸水 _ when 支 is 未:
                    结果 = "墓";
                    break;
                case 甲木 _ when 支 is 申:
                case 丙火 _ when 支 is 亥:
                case 戊土 _ when 支 is 亥:
                case 庚金 _ when 支 is 寅:
                case 壬水 _ when 支 is 巳:
                case 乙木 _ when 支 is 酉:
                case 丁火 _ when 支 is 子:
                case 己土 _ when 支 is 子:
                case 辛金 _ when 支 is 卯:
                case 癸水 _ when 支 is 午:
                    结果 = "绝";
                    break;
                case 甲木 _ when 支 is 酉:
                case 丙火 _ when 支 is 子:
                case 戊土 _ when 支 is 子:
                case 庚金 _ when 支 is 卯:
                case 壬水 _ when 支 is 午:
                case 乙木 _ when 支 is 申:
                case 丁火 _ when 支 is 亥:
                case 己土 _ when 支 is 亥:
                case 辛金 _ when 支 is 寅:
                case 癸水 _ when 支 is 巳:
                    结果 = "胎";
                    break;
                case 甲木 _ when 支 is 戌:
                case 丙火 _ when 支 is 丑:
                case 戊土 _ when 支 is 丑:
                case 庚金 _ when 支 is 辰:
                case 壬水 _ when 支 is 未:
                case 乙木 _ when 支 is 未:
                case 丁火 _ when 支 is 戌:
                case 己土 _ when 支 is 戌:
                case 辛金 _ when 支 is 丑:
                case 癸水 _ when 支 is 辰:
                    结果 = "养";
                    break;
            }
            return 结果;
        }
        public static 甲子 六十甲子(天干 干, 地支 支)
        {
            var 名称 = new StringBuilder();
            名称.Append(干.GetType().Name);
            名称.Append(支.GetType().Name);
            var 枚 = 枚举转换类<甲子表.甲子枚举>.获取枚举(名称.ToString());
            return new 甲子(枚);
        }

        #endregion

        #region 起遁
        public static 天干 五鼠遁(天干 干, 地支 支)
        {
            天干 起;
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    起 = 天干.甲;//甲己合化土，甲木克之
                    break;
                case 乙 _:
                case 庚 _:
                    起 = 天干.丙;//乙庚合化金，丙火克之
                    break;
                case 丙 _:
                case 辛 _:
                    起 = 天干.戊;//丙辛合化水，戊土克之
                    break;
                case 丁 _:
                case 壬 _:
                    起 = 天干.庚;//丁壬合化木，庚金克之
                    break;
                case 戊 _:
                case 癸 _:
                    起 = 天干.壬;//戊癸合化火，壬水克之
                    break;
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
            var 序首 = 获取天干序数(起);
            var 偏移 = 获取地支序数(支);
            var 干序 = (序首 + 偏移) % 10;
            return 天干查询(干序);
        }
        public static 天干 五虎遁(天干 干, 地支 支)
        {
            天干 起;
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    起 = 天干.丙;//甲己合化土，丙火生之
                    break;
                case 乙 _:
                case 庚 _:
                    起 = 天干.戊;//乙庚合化金，戊土生之
                    break;
                case 丙 _:
                case 辛 _:
                    起 = 天干.庚;//丙辛合化水，庚金生之
                    break;
                case 丁 _:
                case 壬 _:
                    起 = 天干.壬;//丁壬合化木，壬水生之
                    break;
                case 戊 _:
                case 癸 _:
                    起 = 天干.甲;//戊癸合化火，甲木生之
                    break;
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
            var 序首 = 获取天干序数(起);
            var 偏移 = 获取地支序数(支);
            var 干序 = (序首 + 偏移) % 10;
            return 天干查询(干序);
        }

        #endregion
    }
}
