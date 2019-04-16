using System;

namespace 阴阳易演.计算类
{
    using 具象类.地支;
    using 具象类.天干;
    using 抽象类;
    using 查询类;

    public static class 干支计算
    {
        #region 计算
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
        public static 天干 五鼠遁(天干 干, 地支 支)
        {
            天干 起;
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    起 = 天干.甲;// 甲己合化土，甲木克之
                    break;
                case 乙 _:
                case 庚 _:
                    起 = 天干.丙;// 乙庚合化金，丙火克之
                    break;
                case 丙 _:
                case 辛 _:
                    起 = 天干.戊;// 丙辛合化水，戊土克之
                    break;
                case 丁 _:
                case 壬 _:
                    起 = 天干.庚;// 丁壬合化木，庚金克之
                    break;
                case 戊 _:
                case 癸 _:
                    起 = 天干.壬;// 戊癸合化火，壬水克之
                    break;
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
            var 序首 = 干支表.获取天干序数(起);
            var 偏移 = 干支表.获取地支序数(支);
            var 干序 = (序首 + 偏移) % 10;
            return 干支表.天干查询(干序);
        }
        public static 天干 五虎遁(天干 干, 地支 支)
        {
            天干 起;
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    起 = 天干.丙;// 甲己合化土，丙火生之
                    break;
                case 乙 _:
                case 庚 _:
                    起 = 天干.戊;// 乙庚合化金，戊土生之
                    break;
                case 丙 _:
                case 辛 _:
                    起 = 天干.庚;// 丙辛合化水，庚金生之
                    break;
                case 丁 _:
                case 壬 _:
                    起 = 天干.壬;// 丁壬合化木，壬水生之
                    break;
                case 戊 _:
                case 癸 _:
                    起 = 天干.甲;// 戊癸合化火，甲木生之
                    break;
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
            var 序首 = 干支表.获取天干序数(起);
            var 偏移 = 干支表.获取地支序数(支);
            var 干序 = (序首 + 偏移) % 10;
            return 干支表.天干查询(干序);
        }

        #endregion

        #region 扩展
        public static 天干 合(this 天干 干)
        {
            // 甲己合化土，乙庚合化金，丙辛合化水，丁壬合化木，戊癸合化火
            switch (干)
            {
                case 甲 _:
                    return 天干.己;
                case 乙 _:
                    return 天干.庚;
                case 丙 _:
                    return 天干.辛;
                case 丁 _:
                    return 天干.壬;
                case 戊 _:
                    return 天干.癸;
                case 己 _:
                    return 天干.甲;
                case 庚 _:
                    return 天干.乙;
                case 辛 _:
                    return 天干.丙;
                case 壬 _:
                    return 天干.丁;
                case 癸 _:
                    return 天干.戊;
                default:
                    throw new Exception($"未找到正确的合化天干,当前输入:{干}");
            }
        }
        public static 五行 化(this 天干 干, 天干 合)
        {
            switch (干)
            {
                case 甲 _ when 合 is 己:
                    return 五行.土;// 甲己合化土

                case 乙 _ when 合 is 庚:
                    return 五行.金;// 乙庚合化金

                case 丙 _ when 合 is 辛:
                    return 五行.水;// 丙辛合化水

                case 丁 _ when 合 is 壬:
                    return 五行.木;// 丁壬合化木

                case 戊 _ when 合 is 癸:
                    return 五行.火;// 戊癸合化火
                default:
                    throw new Exception($"未找到正确的合化五行,当前输入:{干},{合}");
            }
        }

        #endregion

    }
}