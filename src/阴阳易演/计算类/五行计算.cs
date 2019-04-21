namespace 阴阳易演.计算类
{
    using System;
    using 具象类.五行;
    using 抽象类;

    public static class 五行计算
    {
        #region 扩展
        public static 五行 父母(this 五行 行)
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
        public static 五行 子孙(this 五行 行)
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
        public static 五行 官鬼(this 五行 行)
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
        public static 五行 妻妾(this 五行 行)
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
        public static 五行 兄弟(this 五行 行)
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

        #endregion

        #region 计算
        public static bool 生我(五行 主, 五行 客) => 主.父母() == 客;
        public static bool 我生(五行 主, 五行 客) => 主.子孙() == 客;
        public static bool 克我(五行 主, 五行 客) => 主.官鬼() == 客;
        public static bool 我克(五行 主, 五行 客) => 主.妻妾() == 客;
        public static bool 同我(五行 主, 五行 客) => 主.兄弟() == 客;

        #endregion

    }
}