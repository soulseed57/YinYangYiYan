namespace 阴阳易演.计算类
{
    using System;
    using 具象类.地支;
    using 具象类.天干;
    using 抽象类;
    using 枚举类;
    using 查询类;

    public static class 干支计算
    {
        #region 天干扩展
        public static 天干 五虎遁(this 天干 干)
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
                    return 天干.甲;// 若问戊癸何处起.甲寅之上好追求
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
        }
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
                    throw new Exception($"未找到正确的合化天干,当前天干[{干}]");
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
                    throw new Exception($"未找到正确的合化五行,当前天干[{干}],合[{合}]");
            }
        }
        public static 八卦 天干配卦(this 天干 干)
        {
            switch (干)
            {
                case 甲 _:
                    return 八卦.乾;
                case 乙 _:
                    return 八卦.坤;
                case 丙 _:
                    return 八卦.艮;
                case 丁 _:
                    return 八卦.兑;
                case 戊 _:
                    return 八卦.坎;
                case 己 _:
                    return 八卦.离;
                case 庚 _:
                    return 八卦.震;
                case 辛 _:
                    return 八卦.巽;
                case 壬 _:
                    return 八卦.乾;
                case 癸 _:
                    return 八卦.坤;
                default:
                    throw new Exception($"未找到匹配的天干,当前输入{干}");
            }
        }

        #endregion

        #region 地支扩展
        public static 地支 合(this 地支 支)
        {
            // 子丑合化土，寅亥合化木，卯戌合化火，辰酉合化金，巳申合化水，午未合化土。
            switch (支)
            {
                case 子 _:
                    return 地支.丑;
                case 寅 _:
                    return 地支.亥;
                case 卯 _:
                    return 地支.戌;
                case 辰 _:
                    return 地支.酉;
                case 巳 _:
                    return 地支.申;
                case 午 _:
                    return 地支.未;
                case 丑 _:
                    return 地支.子;
                case 亥 _:
                    return 地支.寅;
                case 戌 _:
                    return 地支.卯;
                case 酉 _:
                    return 地支.辰;
                case 申 _:
                    return 地支.巳;
                case 未 _:
                    return 地支.午;
                default:
                    throw new Exception($"未找到正确的合化地支,当前地支[{支}]");
            }
        }
        public static 五行 化(this 地支 支, 地支 合)
        {
            switch (支)
            {
                case 子 _ when 合 is 丑:
                    return 五行.土;// 子丑合化土
                case 寅 _ when 合 is 亥:
                    return 五行.木;// 寅亥合化木
                case 卯 _ when 合 is 戌:
                    return 五行.火;// 卯戌合化火
                case 辰 _ when 合 is 酉:
                    return 五行.金;// 辰酉合化金
                case 巳 _ when 合 is 申:
                    return 五行.水;// 巳申合化水
                case 午 _ when 合 is 未:
                    return 五行.土;// 午未合化土
                default:
                    throw new Exception($"未找到正确的合化五行,当前地支[{支}],合[{合}]");
            }
        }
        public static 八卦 地支配卦(this 地支 支)
        {
            switch (支)
            {
                case 子 _:
                    return 八卦.坎;
                case 丑 _:
                    return 八卦.艮;
                case 寅 _:
                    return 八卦.艮;
                case 卯 _:
                    return 八卦.震;
                case 辰 _:
                    return 八卦.巽;
                case 巳 _:
                    return 八卦.巽;
                case 午 _:
                    return 八卦.离;
                case 未 _:
                    return 八卦.坤;
                case 申 _:
                    return 八卦.坤;
                case 酉 _:
                    return 八卦.兑;
                case 戌 _:
                    return 八卦.乾;
                case 亥 _:
                    return 八卦.乾;
                default:
                    throw new Exception($"未找到匹配的地支,当前输入{支}");
            }
        }

        #endregion

        #region 计算
        public static 长生枚举 长生(天干 干, 地支 支)
        {
            switch (干)
            {
                case 甲 _ when 支 is 亥:
                case 丙 _ when 支 is 寅:
                case 戊 _ when 支 is 寅:
                case 庚 _ when 支 is 巳:
                case 壬 _ when 支 is 申:
                case 乙 _ when 支 is 午:
                case 丁 _ when 支 is 酉:
                case 己 _ when 支 is 酉:
                case 辛 _ when 支 is 子:
                case 癸 _ when 支 is 卯:
                    return 长生枚举.长生;
                case 甲 _ when 支 is 子:
                case 丙 _ when 支 is 卯:
                case 戊 _ when 支 is 卯:
                case 庚 _ when 支 is 午:
                case 壬 _ when 支 is 酉:
                case 乙 _ when 支 is 巳:
                case 丁 _ when 支 is 申:
                case 己 _ when 支 is 申:
                case 辛 _ when 支 is 亥:
                case 癸 _ when 支 is 寅:
                    return 长生枚举.沐浴;
                case 甲 _ when 支 is 丑:
                case 丙 _ when 支 is 辰:
                case 戊 _ when 支 is 辰:
                case 庚 _ when 支 is 未:
                case 壬 _ when 支 is 戌:
                case 乙 _ when 支 is 辰:
                case 丁 _ when 支 is 未:
                case 己 _ when 支 is 未:
                case 辛 _ when 支 is 戌:
                case 癸 _ when 支 is 丑:
                    return 长生枚举.冠带;
                case 甲 _ when 支 is 寅:
                case 丙 _ when 支 is 巳:
                case 戊 _ when 支 is 巳:
                case 庚 _ when 支 is 申:
                case 壬 _ when 支 is 亥:
                case 乙 _ when 支 is 卯:
                case 丁 _ when 支 is 午:
                case 己 _ when 支 is 午:
                case 辛 _ when 支 is 酉:
                case 癸 _ when 支 is 子:
                    return 长生枚举.临官;
                case 甲 _ when 支 is 卯:
                case 丙 _ when 支 is 午:
                case 戊 _ when 支 is 午:
                case 庚 _ when 支 is 酉:
                case 壬 _ when 支 is 子:
                case 乙 _ when 支 is 寅:
                case 丁 _ when 支 is 巳:
                case 己 _ when 支 is 巳:
                case 辛 _ when 支 is 申:
                case 癸 _ when 支 is 亥:
                    return 长生枚举.帝旺;
                case 甲 _ when 支 is 辰:
                case 丙 _ when 支 is 未:
                case 戊 _ when 支 is 未:
                case 庚 _ when 支 is 戌:
                case 壬 _ when 支 is 丑:
                case 乙 _ when 支 is 丑:
                case 丁 _ when 支 is 辰:
                case 己 _ when 支 is 辰:
                case 辛 _ when 支 is 未:
                case 癸 _ when 支 is 戌:
                    return 长生枚举.衰;
                case 甲 _ when 支 is 巳:
                case 丙 _ when 支 is 申:
                case 戊 _ when 支 is 申:
                case 庚 _ when 支 is 亥:
                case 壬 _ when 支 is 寅:
                case 乙 _ when 支 is 子:
                case 丁 _ when 支 is 卯:
                case 己 _ when 支 is 卯:
                case 辛 _ when 支 is 午:
                case 癸 _ when 支 is 酉:
                    return 长生枚举.病;
                case 甲 _ when 支 is 午:
                case 丙 _ when 支 is 酉:
                case 戊 _ when 支 is 酉:
                case 庚 _ when 支 is 子:
                case 壬 _ when 支 is 卯:
                case 乙 _ when 支 is 亥:
                case 丁 _ when 支 is 寅:
                case 己 _ when 支 is 寅:
                case 辛 _ when 支 is 巳:
                case 癸 _ when 支 is 申:
                    return 长生枚举.死;
                case 甲 _ when 支 is 未:
                case 丙 _ when 支 is 戌:
                case 戊 _ when 支 is 戌:
                case 庚 _ when 支 is 丑:
                case 壬 _ when 支 is 辰:
                case 乙 _ when 支 is 戌:
                case 丁 _ when 支 is 丑:
                case 己 _ when 支 is 丑:
                case 辛 _ when 支 is 辰:
                case 癸 _ when 支 is 未:
                    return 长生枚举.墓;
                case 甲 _ when 支 is 申:
                case 丙 _ when 支 is 亥:
                case 戊 _ when 支 is 亥:
                case 庚 _ when 支 is 寅:
                case 壬 _ when 支 is 巳:
                case 乙 _ when 支 is 酉:
                case 丁 _ when 支 is 子:
                case 己 _ when 支 is 子:
                case 辛 _ when 支 is 卯:
                case 癸 _ when 支 is 午:
                    return 长生枚举.绝;
                case 甲 _ when 支 is 酉:
                case 丙 _ when 支 is 子:
                case 戊 _ when 支 is 子:
                case 庚 _ when 支 is 卯:
                case 壬 _ when 支 is 午:
                case 乙 _ when 支 is 申:
                case 丁 _ when 支 is 亥:
                case 己 _ when 支 is 亥:
                case 辛 _ when 支 is 寅:
                case 癸 _ when 支 is 巳:
                    return 长生枚举.胎;
                case 甲 _ when 支 is 戌:
                case 丙 _ when 支 is 丑:
                case 戊 _ when 支 is 丑:
                case 庚 _ when 支 is 辰:
                case 壬 _ when 支 is 未:
                case 乙 _ when 支 is 未:
                case 丁 _ when 支 is 戌:
                case 己 _ when 支 is 戌:
                case 辛 _ when 支 is 丑:
                case 癸 _ when 支 is 辰:
                    return 长生枚举.养;
                default:
                    throw new Exception($"未找到地支匹配的长生,当前天干[{干}],当前地支[{支}]");
            }
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

    }
}