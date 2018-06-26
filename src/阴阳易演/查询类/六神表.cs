using System;

namespace 阴阳易演.查询类
{
    using 引用库;
    using 抽象类;

    public class 六神表
    {
        public enum 六神枚举 { 青龙, 朱雀, 腾蛇, 勾陈, 白虎, 玄武 }

        public static 六神 六神查询(string 名)
        {
            var 枚 = 枚举转换类<六神枚举>.获取枚举(名);
            return 六神查询(枚);
        }

        public static 六神 六神查询(int 序)
        {
            序 = 枚举转换类<六神枚举>.序数取余(序, 6);// 序数取余
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
    }
}
