namespace 阴阳易演.计算类
{
    using 具象类.五行;
    using 抽象类;

    public static class 五行计算
    {
        #region 扩展
        public static 五行 父母(this 五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 五行.土;
                    break;
                case 水 _:
                    结果 = 五行.金;
                    break;
                case 木 _:
                    结果 = 五行.水;
                    break;
                case 火 _:
                    结果 = 五行.木;
                    break;
                case 土 _:
                    结果 = 五行.火;
                    break;
            }
            return 结果;
        }
        public static 五行 子孙(this 五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 五行.水;
                    break;
                case 水 _:
                    结果 = 五行.木;
                    break;
                case 木 _:
                    结果 = 五行.火;
                    break;
                case 火 _:
                    结果 = 五行.土;
                    break;
                case 土 _:
                    结果 = 五行.金;
                    break;
            }
            return 结果;
        }
        public static 五行 官鬼(this 五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 五行.火;
                    break;
                case 水 _:
                    结果 = 五行.土;
                    break;
                case 木 _:
                    结果 = 五行.金;
                    break;
                case 火 _:
                    结果 = 五行.水;
                    break;
                case 土 _:
                    结果 = 五行.木;
                    break;
            }
            return 结果;
        }
        public static 五行 妻妾(this 五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 五行.木;
                    break;
                case 水 _:
                    结果 = 五行.火;
                    break;
                case 木 _:
                    结果 = 五行.土;
                    break;
                case 火 _:
                    结果 = 五行.金;
                    break;
                case 土 _:
                    结果 = 五行.水;
                    break;
            }
            return 结果;
        }
        public static 五行 兄弟(this 五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 五行.金;
                    break;
                case 水 _:
                    结果 = 五行.水;
                    break;
                case 木 _:
                    结果 = 五行.木;
                    break;
                case 火 _:
                    结果 = 五行.火;
                    break;
                case 土 _:
                    结果 = 五行.土;
                    break;
            }
            return 结果;
        }

        #endregion

        #region 计算
        public static bool 比和(五行 一, 五行 二) => 一.Equals(二);

        #endregion

    }
}