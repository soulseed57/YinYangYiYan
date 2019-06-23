namespace 阴阳易演.计算类
{
    using System;
    using 具象类.地支;
    using 具象类.天干;
    using 容器类;
    using 抽象类;
    using 查询类;

    public static class 干支计算
    {
        #region 扩展

        #region 天干扩展
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
        public static 天干 五鼠遁(this 天干 干)
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
        public static 天干 五鼠遁(this 天干 干, 地支 支)
        {
            var 起遁 = 干.五鼠遁();
            var 遁序 = 干支表.获取天干序数(起遁);
            var 支序 = 干支表.获取地支序数(支);
            var 干序 = (遁序 + 支序) % 10;
            return 干支表.天干查询(干序);
        }
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
                    return 天干.甲;// 若问戊癸何处起，甲寅之上好追求
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
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
        public static 地支藏干 藏干(this 地支 支) => new 地支藏干(支);
        #endregion

        #endregion
    }
}