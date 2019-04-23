namespace 阴阳易演.计算类
{
    using System;
    using 具象类.五行;
    using 抽象类;

    public static class 五行计算
    {
        #region 扩展
        /**
         * 五行关系
         */
        public static 五行 生我(this 五行 行)
        {
            switch (行)
            {
                case 金 _:
                    return 五行.土;
                case 水 _:
                    return 五行.金;
                case 木 _:
                    return 五行.水;
                case 火 _:
                    return 五行.木;
                case 土 _:
                    return 五行.火;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 我生(this 五行 行)
        {
            switch (行)
            {
                case 金 _:
                    return 五行.水;
                case 水 _:
                    return 五行.木;
                case 木 _:
                    return 五行.火;
                case 火 _:
                    return 五行.土;
                case 土 _:
                    return 五行.金;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 克我(this 五行 行)
        {
            switch (行)
            {
                case 金 _:
                    return 五行.火;
                case 水 _:
                    return 五行.土;
                case 木 _:
                    return 五行.金;
                case 火 _:
                    return 五行.水;
                case 土 _:
                    return 五行.木;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 我克(this 五行 行)
        {
            switch (行)
            {
                case 金 _:
                    return 五行.木;
                case 水 _:
                    return 五行.火;
                case 木 _:
                    return 五行.土;
                case 火 _:
                    return 五行.金;
                case 土 _:
                    return 五行.水;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        public static 五行 同我(this 五行 行)
        {
            switch (行)
            {
                case 金 _:
                    return 五行.金;
                case 水 _:
                    return 五行.水;
                case 木 _:
                    return 五行.木;
                case 火 _:
                    return 五行.火;
                case 土 _:
                    return 五行.土;
                default:
                    throw new Exception($"未找到任何匹配,当前输入[{行.名称}]");
            }
        }
        /**
         * 五行判定
         * 命名规则使用了中文语言习惯,方便调用时阅读
         * 例如: 
         * 五行.金.的父母是(五行.土)
         * 五行.木.的妻妾是(五行.土)
         */
        public static bool 的父母是(this 五行 主, 五行 客) => 主.生我() == 客;
        public static bool 的子孙是(this 五行 主, 五行 客) => 主.我生() == 客;
        public static bool 的官鬼是(this 五行 主, 五行 客) => 主.克我() == 客;
        public static bool 的妻妾是(this 五行 主, 五行 客) => 主.我克() == 客;
        public static bool 的兄弟是(this 五行 主, 五行 客) => 主.同我() == 客;

        #endregion

    }
}