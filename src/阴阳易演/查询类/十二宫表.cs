namespace 阴阳易演.查询类
{
    using 容器类;
    using 引用库;

    public static class 十二宫表
    {
        static 十二宫表()
        {
            十二宫数 = 枚举转换类<十二宫枚举>.获取所有枚举().Length;
        }
        public static readonly int 十二宫数;
        public enum 十二宫枚举 { 命寿, 兄弟, 夫妻, 子媳, 财帛, 疾病, 迁移, 奴婢, 官禄, 田宅, 福德, 父母 }

        #region 十二宫枚举
        public static int 获取十二宫序数(宫 宫)
        {
            return 枚举转换类<十二宫枚举>.获取序数(宫.名称); ;
        }
        public static int 获取十二宫序数(十二宫枚举 枚)
        {
            return 枚举转换类<十二宫枚举>.获取序数(枚);
        }
        public static 十二宫枚举 获取十二宫枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 十二宫数);
            return 枚举转换类<十二宫枚举>.获取枚举(序);
        }
        public static string 获取十二宫名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 十二宫数);
            return 枚举转换类<十二宫枚举>.获取名称(序);
        }

        #endregion

    }
}
