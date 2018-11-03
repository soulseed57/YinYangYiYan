using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using 引用库;
    using 抽象类;

    public static class 八卦表
    {
        static 八卦表()
        {
            八卦数 = 枚举转换类<八卦枚举>.获取所有枚举().Length;
        }
        public static readonly int 八卦数;
        public enum 八卦枚举 { 乾, 兑, 离, 震, 巽, 坎, 艮, 坤 }
        public static List<八卦> 八卦列表 = new List<八卦>
        {
            八卦.乾, 八卦.兑,
            八卦.离, 八卦.震,
            八卦.巽, 八卦.坎,
            八卦.艮, 八卦.坤
        };

        #region 八卦枚举
        public static int 获取八卦序数(八卦 卦)
        {
            return 枚举转换类<八卦枚举>.获取序数(卦.名称);
        }
        public static int 获取八卦序数(八卦枚举 枚)
        {
            return 枚举转换类<八卦枚举>.获取序数(枚);
        }
        public static 八卦枚举 获取八卦枚举(int 数)
        {
            var 序 = 枚举转换类<八卦枚举>.序数取余(数, 八卦数);
            return 枚举转换类<八卦枚举>.获取枚举(序);
        }
        public static string 获取八卦名称(int 数)
        {
            var 序 = 枚举转换类<八卦枚举>.序数取余(数, 八卦数);
            return 枚举转换类<八卦枚举>.获取名称(序);
        }
        public static 八卦 获取八卦实例(int 数)
        {
            var 名 = 获取八卦名称(数);
            return 八卦列表.Find(t => t.名称 == 名);
        }

        #endregion

    }
}