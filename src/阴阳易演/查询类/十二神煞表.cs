namespace 阴阳易演.查询类
{
    using 抽象类;
    using 容器类;
    using 引用库;
    using 具象类.地支;
    using 枚举类;

    public static class 十二神煞表
    {
        static 十二神煞表()
        {
            神煞数 = 枚举转换类<神煞枚举>.获取枚举数();
        }
        public static readonly int 神煞数;

        #region 神煞枚举
        public static int 获取神煞序数(神煞 神)
        {
            return 枚举转换类<神煞枚举>.获取序数(神.名称);
        }
        public static int 获取神煞序数(神煞枚举 枚)
        {
            return 枚举转换类<神煞枚举>.获取序数(枚);
        }
        public static 神煞枚举 获取神煞枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 神煞数);
            return 枚举转换类<神煞枚举>.获取枚举(序);
        }
        public static string 获取神煞名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 神煞数);
            return 枚举转换类<神煞枚举>.获取名称(序);
        }

        #endregion

        #region 神煞查询
        public static 神煞 十二值日(地支 日支, 地支 时辰)
        {
            地支 起支 = null;
            switch (日支)
            {
                case 子 _:
                case 午 _:
                    起支 = 地支.申;
                    break;
                case 丑 _:
                case 未 _:
                    起支 = 地支.戌;
                    break;
                case 寅 _:
                case 申 _:
                    起支 = 地支.子;
                    break;
                case 卯 _:
                case 酉 _:
                    起支 = 地支.寅;
                    break;
                case 辰 _:
                case 戌 _:
                    起支 = 地支.辰;
                    break;
                case 巳 _:
                case 亥 _:
                    起支 = 地支.午;
                    break;
            }
            var 神煞序数 = (干支表.地支数 - 干支表.获取地支序数(起支)) + 干支表.获取地支序数(时辰);
            return new 神煞(神煞序数);
        }

        #endregion

    }
}
