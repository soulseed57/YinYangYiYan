namespace 阴阳易演.计算类
{
    using System;
    using 具象类.五行;
    using 抽象类;

    public static class 五行计算
    {
        #region 扩展

        #region 六亲五行
        public static 五行 生我(this 五行 行)
        {
            switch (行)
            {
                case 金 我:
                    return 我.生我;
                case 水 我:
                    return 我.生我;
                case 木 我:
                    return 我.生我;
                case 火 我:
                    return 我.生我;
                case 土 我:
                    return 我.生我;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 我生(this 五行 行)
        {
            switch (行)
            {
                case 金 我:
                    return 我.我生;
                case 水 我:
                    return 我.我生;
                case 木 我:
                    return 我.我生;
                case 火 我:
                    return 我.我生;
                case 土 我:
                    return 我.我生;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 克我(this 五行 行)
        {
            switch (行)
            {
                case 金 我:
                    return 我.克我;
                case 水 我:
                    return 我.克我;
                case 木 我:
                    return 我.克我;
                case 火 我:
                    return 我.克我;
                case 土 我:
                    return 我.克我;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 我克(this 五行 行)
        {
            switch (行)
            {
                case 金 我:
                    return 我.我克;
                case 水 我:
                    return 我.我克;
                case 木 我:
                    return 我.我克;
                case 火 我:
                    return 我.我克;
                case 土 我:
                    return 我.我克;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 同我(this 五行 行)
        {
            switch (行)
            {
                case 金 我:
                    return 我.同我;
                case 水 我:
                    return 我.同我;
                case 木 我:
                    return 我.同我;
                case 火 我:
                    return 我.同我;
                case 土 我:
                    return 我.同我;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        #endregion

        #region 六亲判定
        public static bool 的父母是(this 五行 主, 五行 客) => 主.生我() == 客;
        public static bool 的子孙是(this 五行 主, 五行 客) => 主.我生() == 客;
        public static bool 的官鬼是(this 五行 主, 五行 客) => 主.克我() == 客;
        public static bool 的妻妾是(this 五行 主, 五行 客) => 主.我克() == 客;
        public static bool 的兄弟是(this 五行 主, 五行 客) => 主.同我() == 客;
        #endregion

        #endregion

    }
}