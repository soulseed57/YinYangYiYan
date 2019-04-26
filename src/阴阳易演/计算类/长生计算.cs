namespace 阴阳易演.计算类
{
    using System;
    using 具象类.地支;
    using 具象类.天干;
    using 抽象类;
    using 枚举类;

    public static class 长生计算
    {
        #region 扩展
        public static 长生枚举 在地支的长生(this 天干 干, 地支 支) => 地支长生(干, 支);

        #endregion

        #region 计算
        public static 长生枚举 地支长生(天干 干, 地支 支)
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

        #endregion

    }
}