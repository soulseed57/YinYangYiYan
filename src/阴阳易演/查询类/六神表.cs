using System;
using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using 具象类.天干;
    using 抽象类;
    using 引用库;

    public static class 六神表
    {
        static 六神表()
        {
            六神数 = 枚举转换类<六神枚举>.获取所有枚举().Length;
        }
        public static readonly int 六神数;
        public enum 六神枚举 { 青龙, 朱雀, 勾陈, 腾蛇, 白虎, 玄武 }

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
            var 序 = 枚举转换类<六神枚举>.序数取余(数, 六神数);
            return 枚举转换类<六神枚举>.获取枚举(序);
        }
        public static string 获取六神名称(int 数)
        {
            var 序 = 枚举转换类<六神枚举>.序数取余(数, 六神数);
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
            var 序 = 枚举转换类<六神枚举>.序数取余(数, 六神数);
            var 枚 = 枚举转换类<六神枚举>.获取枚举(序);
            return 六神查询(枚);
        }
        public static 六神 六神查询(六神枚举 枚)
        {
            switch (枚)
            {
                case 六神枚举.青龙:
                    return 六神.青龙;
                case 六神枚举.朱雀:
                    return 六神.朱雀;
                case 六神枚举.腾蛇:
                    return 六神.滕蛇;
                case 六神枚举.勾陈:
                    return 六神.勾陈;
                case 六神枚举.白虎:
                    return 六神.白虎;
                case 六神枚举.玄武:
                    return 六神.玄武;
                default:
                    throw new Exception($"输入的枚举不是六神枚举,当前输入:{枚}");
            }
        }

        #endregion

        #region 运算
        // 内部
        static int 六神序数(天干 时干)
        {
            switch (时干)
            {
                case 甲 _:
                case 乙 _:
                    return 获取六神序数(六神枚举.青龙);
                case 丙 _:
                case 丁 _:
                    return 获取六神序数(六神枚举.朱雀);
                case 戊 _:
                    return 获取六神序数(六神枚举.勾陈);
                case 己 _:
                    return 获取六神序数(六神枚举.腾蛇);
                case 庚 _:
                case 辛 _:
                    return 获取六神序数(六神枚举.白虎);
                case 壬 _:
                case 癸 _:
                    return 获取六神序数(六神枚举.玄武);
                default:
                    throw new Exception($"无法从给定的时干起六神,当前时干:{时干}");
            }
        }
        // 公开
        public static 六神[] 配六神(天干 时干)
        {
            var 顺排 = 时干.阴阳 == 两仪.阳;// 阳顺阴逆
            var 神列 = new List<六神>();
            var 神序 = 六神序数(时干);
            for (var i = 0; i < 六神数; i++)
            {
                var 神 = 六神查询(神序++);
                if (顺排)
                {
                    神列.Add(神);
                }
                else
                {
                    神列.Insert(0, 神);
                }
            }
            return 神列.ToArray();
        }

        #endregion

    }
}
