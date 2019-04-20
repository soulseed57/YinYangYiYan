namespace 阴阳易演.查询类
{
    using System;
    using 容器类;
    using 引用库;
    using 枚举类;

    public static class 节气表
    {
        static 节气表()
        {
            节气数 = 枚举转换类<节气枚举>.获取枚举总数();
        }
        public static readonly int 节气数;

        #region 节气枚举
        public static int 获取节气序数(节气 节)
        {
            return 枚举转换类<节气枚举>.获取序数(节.名称);
        }
        public static int 获取节气序数(节气枚举 枚)
        {
            return 枚举转换类<节气枚举>.获取序数(枚);
        }
        public static int 获取节气序数(string 名)
        {
            return 枚举转换类<节气枚举>.获取序数(名);
        }
        public static 节气枚举 获取节气枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 节气数);
            return 枚举转换类<节气枚举>.获取枚举(序);
        }
        public static 节气枚举 获取节气枚举(string 名)
        {
            return 枚举转换类<节气枚举>.获取枚举(名);
        }
        public static string 获取节气名称(节气枚举 枚)
        {
            return 枚举转换类<节气枚举>.获取名称(枚);
        }
        public static string 获取节气名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 节气数);
            return 枚举转换类<节气枚举>.获取名称(序);
        }

        #endregion

        #region 节气查询
        public static 节气枚举 节气枚举查询(DateTime 时间)
        {
            var 索引 = -1;
            for (var i = 0; i < 节气修正分钟.Length; i++)
            {
                if ((节气时间查询(时间.Year, i) - 时间).Days > 0)
                {
                    break;
                }
                索引 = i;
            }
            if (索引 == -1)
            {
                throw new Exception($"未找到日期[{时间}]的节气");
            }
            return 获取节气枚举(索引);
        }
        public static DateTime 节气时间查询(int 年份, 节气枚举 枚)
        {
            return 节气时间查询(年份, 枚举转换类<节气枚举>.获取序数(枚));
        }
        public static DateTime 节气时间查询(int 年份, int 序数)
        {
            return 基准时间.AddMinutes(年份修正分钟(年份) + 节气修正分钟[序数]);
        }

        #endregion

        #region 内部参数
        static readonly DateTime 基准时间 = new DateTime(1900, 1, 6, 2, 5, 0);
        static double 年份修正分钟(int year) => 525948.76 * (year - 基准时间.Year);
        static readonly int[] 节气修正分钟 =
        {
            0, 21208, 42467, 63836,
            85337,107014, 128867, 150921,
            173149, 195551,218072, 240693,
            263343, 285989, 308563,331033,
            353350, 375494, 397447, 419210,
            440795, 462224, 483532, 504758
        };

        #endregion

    }
}
