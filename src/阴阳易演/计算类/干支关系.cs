using System.Text;

namespace 阴阳易演.计算类
{
    using 具象类.地支;
    using 具象类.天干;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 查询类;

    public static class 干支关系
    {
        static 干支关系()
        {
            天干数 = 枚举转换类<天干枚举>.获取所有枚举().Length;
            地支数 = 枚举转换类<地支枚举>.获取所有枚举().Length;
        }
        static readonly int 天干数;
        static readonly int 地支数;
        public enum 天干枚举 { 甲, 乙, 丙, 丁, 戊, 己, 庚, 辛, 壬, 癸 }
        public enum 地支枚举 { 子, 丑, 寅, 卯, 辰, 巳, 午, 未, 申, 酉, 戌, 亥 }

        #region 天干
        public static 天干 获取天干(int 数)
        {
            var 序 = 枚举转换类<天干枚举>.序数取余(数, 天干数);
            return 干支表.天干查询(获取天干枚举(序).ToString());
        }
        public static int 获取天干序数(天干 干)
        {
            var 枚 = 枚举转换类<天干枚举>.获取枚举(干.名称);
            return 获取天干序数(枚);
        }
        public static int 获取天干序数(天干枚举 枚)
        {
            return 枚举转换类<天干枚举>.获取序数(枚);
        }
        public static 天干枚举 获取天干枚举(int 数)
        {
            var 序 = 枚举转换类<天干枚举>.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取枚举(序);
        }
        public static string 获取天干名称(int 数)
        {
            var 序 = 枚举转换类<天干枚举>.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取名称(序);
        }

        #endregion

        #region 地支
        public static 地支 获取地支(int 数)
        {
            var 序 = 枚举转换类<地支枚举>.序数取余(数, 地支数);
            return 干支表.地支查询(获取地支枚举(序).ToString());
        }
        public static int 获取地支序数(地支 支)
        {
            var 枚 = 枚举转换类<地支枚举>.获取枚举(支.名称);
            return 获取地支序数(枚);
        }
        public static int 获取地支序数(地支枚举 枚)
        {
            return 枚举转换类<地支枚举>.获取序数(枚);
        }
        public static 地支枚举 获取地支枚举(int 数)
        {
            var 序 = 枚举转换类<地支枚举>.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取枚举(序);
        }
        public static string 获取地支名称(int 数)
        {
            var 序 = 枚举转换类<地支枚举>.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取名称(序);
        }

        #endregion

        #region 运算
        public static string 十二长生(天干 干, 地支 支)
        {
            var 结果 = string.Empty;
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

    }
}
