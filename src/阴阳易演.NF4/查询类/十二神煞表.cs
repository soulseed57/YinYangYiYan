namespace 阴阳易演.查询类
{
    using 容器类;
    using 引用库;
    using 枚举类;

    public static class 十二神煞表
    {
        static 十二神煞表()
        {
            神煞数 = 枚举转换类<神煞枚举>.获取枚举总数();
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
        public static int 获取神煞序数(string 名)
        {
            return 枚举转换类<神煞枚举>.获取序数(名);
        }
        public static 神煞枚举 获取神煞枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 神煞数);
            return 枚举转换类<神煞枚举>.获取枚举(序);
        }
        public static 神煞枚举 获取神煞枚举(string 名)
        {
            return 枚举转换类<神煞枚举>.获取枚举(名);
        }
        public static string 获取神煞名称(神煞枚举 枚)
        {
            return 枚举转换类<神煞枚举>.获取名称(枚);
        }
        public static string 获取神煞名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 神煞数);
            return 枚举转换类<神煞枚举>.获取名称(序);
        }

        #endregion

    }
}
