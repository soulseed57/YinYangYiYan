using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using System;
    using 具象类.地支;
    using 具象类.天干;
    using 引用库;
    using 抽象类;
    using 枚举类;

    public static class 八卦表
    {
        static 八卦表()
        {
            八卦数 = 枚举转换类<八卦枚举>.获取枚举总数();
        }
        public static readonly int 八卦数;
        public static List<八卦> 八卦列表 = new List<八卦> { 八卦.乾, 八卦.兑, 八卦.离, 八卦.震, 八卦.巽, 八卦.坎, 八卦.艮, 八卦.坤 };

        #region 八卦枚举
        public static int 获取八卦序数(八卦 卦)
        {
            return 枚举转换类<八卦枚举>.获取序数(卦.名称);
        }
        public static int 获取八卦序数(八卦枚举 枚)
        {
            return 枚举转换类<八卦枚举>.获取序数(枚);
        }
        public static int 获取八卦序数(string 名)
        {
            return 枚举转换类<八卦枚举>.获取序数(名);
        }
        public static 八卦枚举 获取八卦枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 八卦数);
            return 枚举转换类<八卦枚举>.获取枚举(序);
        }
        public static 八卦枚举 获取八卦枚举(string 名)
        {
            return 枚举转换类<八卦枚举>.获取枚举(名);
        }
        public static string 获取八卦名称(八卦枚举 枚)
        {
            return 枚举转换类<八卦枚举>.获取名称(枚);
        }
        public static string 获取八卦名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 八卦数);
            return 枚举转换类<八卦枚举>.获取名称(序);
        }

        #endregion

        #region 八卦查询
        public static 八卦 八卦查询(八卦枚举 枚)
        {
            var 名 = 枚举转换类<八卦枚举>.获取名称(枚);
            return 八卦查询(名);
        }
        public static 八卦 八卦查询(int 数)
        {
            var 序 = 常用方法.序数取余(数, 八卦数);
            var 名 = 枚举转换类<八卦枚举>.获取名称(序);
            return 八卦查询(名);
        }
        public static 八卦 八卦查询(string 名)
        {
            return 八卦列表.Find(t => t.名称 == 名);
        }
        public static 八卦 天干配卦(天干 干)
        {
            switch (干)
            {
                case 甲 _:
                    return 八卦.乾;
                case 乙 _:
                    return 八卦.坤;
                case 丙 _:
                    return 八卦.艮;
                case 丁 _:
                    return 八卦.兑;
                case 戊 _:
                    return 八卦.坎;
                case 己 _:
                    return 八卦.离;
                case 庚 _:
                    return 八卦.震;
                case 辛 _:
                    return 八卦.巽;
                case 壬 _:
                    return 八卦.乾;
                case 癸 _:
                    return 八卦.坤;
                default:
                    throw new Exception($"未找到匹配的天干,当前输入{干}");
            }
        }
        public static 八卦 地支配卦(地支 支)
        {
            switch (支)
            {
                case 子 _:
                    return 八卦.坎;
                case 丑 _:
                    return 八卦.艮;
                case 寅 _:
                    return 八卦.艮;
                case 卯 _:
                    return 八卦.震;
                case 辰 _:
                    return 八卦.巽;
                case 巳 _:
                    return 八卦.巽;
                case 午 _:
                    return 八卦.离;
                case 未 _:
                    return 八卦.坤;
                case 申 _:
                    return 八卦.坤;
                case 酉 _:
                    return 八卦.兑;
                case 戌 _:
                    return 八卦.乾;
                case 亥 _:
                    return 八卦.乾;
                default:
                    throw new Exception($"未找到匹配的地支,当前输入{支}");
            }
        }

        #endregion

    }
}