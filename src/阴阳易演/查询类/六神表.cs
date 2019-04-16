namespace 阴阳易演.查询类
{
    using System.Collections.Generic;
    using 引用库;
    using 抽象类;
    using 枚举类;

    public static class 六神表
    {
        static 六神表()
        {
            六神数 = 枚举转换类<六神枚举>.获取枚举数();
        }
        public static readonly int 六神数;
        public static List<六神> 六神列表 = new List<六神> { 六神.青龙, 六神.朱雀, 六神.腾蛇, 六神.勾陈, 六神.白虎, 六神.玄武 };

        #region 六神枚举
        public static int 获取六神序数(六神 神)
        {
            return 枚举转换类<六神枚举>.获取序数(神.名称);
        }
        public static int 获取六神序数(六神枚举 枚)
        {
            return 枚举转换类<六神枚举>.获取序数(枚);
        }
        public static 六神枚举 获取六神枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 六神数);
            return 枚举转换类<六神枚举>.获取枚举(序);
        }
        public static string 获取六神名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 六神数);
            return 枚举转换类<六神枚举>.获取名称(序);
        }

        #endregion

        #region 查询
        public static 六神 六神查询(string 名)
        {
            var 枚 = 枚举转换类<六神枚举>.获取枚举(名);
            return 六神查询(枚);
        }
        public static 六神 六神查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 六神数);
            var 枚 = 枚举转换类<六神枚举>.获取枚举(序);
            return 六神查询(枚);
        }
        public static 六神 六神查询(六神枚举 枚)
        {
            var 名 = 枚举转换类<六神枚举>.获取名称(枚);
            return 六神列表.Find(t => t.名称 == 名);
        }

        #endregion

    }
}
