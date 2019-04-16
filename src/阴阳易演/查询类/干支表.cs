using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using 引用库;
    using 抽象类;
    using 枚举类;

    public static class 干支表
    {
        static 干支表()
        {
            天干数 = 枚举转换类<天干枚举>.获取枚举数();
            地支数 = 枚举转换类<地支枚举>.获取枚举数();
        }
        public static readonly int 天干数;
        public static readonly int 地支数;
        public static List<天干> 天干列表 = new List<天干> { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
        public static List<地支> 地支列表 = new List<地支> { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };

        #region 天干枚举
        public static int 获取天干序数(天干 干)
        {
            return 枚举转换类<天干枚举>.获取序数(干.名称);
        }
        public static int 获取天干序数(天干枚举 枚)
        {
            return 枚举转换类<天干枚举>.获取序数(枚);
        }
        public static 天干枚举 获取天干枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取枚举(序);
        }
        public static string 获取天干名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            return 枚举转换类<天干枚举>.获取名称(序);
        }

        #endregion

        #region 地支枚举
        public static int 获取地支序数(地支 支)
        {
            return 枚举转换类<地支枚举>.获取序数(支.名称);
        }
        public static int 获取地支序数(地支枚举 枚)
        {
            return 枚举转换类<地支枚举>.获取序数(枚);
        }
        public static 地支枚举 获取地支枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取枚举(序);
        }
        public static string 获取地支名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            return 枚举转换类<地支枚举>.获取名称(序);
        }

        #endregion

        #region 天干查询
        public static 天干 天干查询(天干枚举 枚)
        {
            var 名 = 枚举转换类<天干枚举>.获取名称(枚);
            return 天干查询(名);
        }
        public static 天干 天干查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 天干数);
            var 名 = 枚举转换类<天干枚举>.获取名称(序);
            return 天干查询(名);
        }
        public static 天干 天干查询(string 名)
        {
            return 天干列表.Find(t => t.名称 == 名);
        }

        #endregion

        #region 地支查询
        public static 地支 地支查询(地支枚举 枚)
        {
            var 名 = 枚举转换类<地支枚举>.获取名称(枚);
            return 地支查询(名);
        }
        public static 地支 地支查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 地支数);
            var 名 = 枚举转换类<地支枚举>.获取名称(序);
            return 地支查询(名);
        }
        public static 地支 地支查询(string 名)
        {
            return 地支列表.Find(t => t.名称 == 名);
        }

        #endregion

    }
}
