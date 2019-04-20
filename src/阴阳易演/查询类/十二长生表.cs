namespace 阴阳易演.查询类
{
    using System;
    using 引用库;
    using 抽象类;
    using 枚举类;

    public static class 十二长生表
    {
        static 十二长生表()
        {
            长生数 = 枚举转换类<长生枚举>.获取枚举总数();

        }
        public static readonly int 长生数;

        #region 长生枚举
        public static int 获取长生序数(长生枚举 枚)
        {
            return 枚举转换类<长生枚举>.获取序数(枚);
        }
        public static int 获取长生序数(string 名)
        {
            return 枚举转换类<长生枚举>.获取序数(名);
        }
        public static 长生枚举 获取长生枚举(int 数)
        {
            var 序 = 常用方法.序数取余(数, 长生数);
            return 枚举转换类<长生枚举>.获取枚举(序);
        }
        public static 长生枚举 获取长生枚举(string 名)
        {
            return 枚举转换类<长生枚举>.获取枚举(名);
        }
        public static string 获取长生名称(长生枚举 枚)
        {
            return 枚举转换类<长生枚举>.获取名称(枚);
        }
        public static string 获取长生名称(int 数)
        {
            var 序 = 常用方法.序数取余(数, 长生数);
            return 枚举转换类<长生枚举>.获取名称(序);
        }

        #endregion

        #region 长生查询
        public static 长生枚举 长生查询(天干 干, 地支 支)
        {
            var 干枚 = 干支表.获取天干枚举(干.名称);
            var 支枚 = 干支表.获取地支枚举(支.名称);
            return 长生查询(干枚, 支枚);
        }
        public static 长生枚举 长生查询(天干枚举 干, 地支枚举 支)
        {
            var 列 = 枚举转换类<长生枚举>.获取所有枚举();
            int 首;
            switch (干)
            {
                case 天干枚举.甲:
                    首 = 1;
                    break;
                case 天干枚举.乙:
                    首 = 6;
                    break;
                case 天干枚举.丙:
                    首 = 10;
                    break;
                case 天干枚举.丁:
                    首 = 9;
                    break;
                case 天干枚举.戊:
                    首 = 10;
                    break;
                case 天干枚举.己:
                    首 = 9;
                    break;
                case 天干枚举.庚:
                    首 = 8;
                    break;
                case 天干枚举.辛:
                    首 = 0;
                    break;
                case 天干枚举.壬:
                    首 = 4;
                    break;
                case 天干枚举.癸:
                    首 = 3;
                    break;
                default:
                    throw new Exception($"天干类型错误,当前输入不是天干{干}");
            }
            列 = 常用方法.列表指定首位(列, 首);
            var 顺排 = 干支表.天干查询(干).阴阳 == 两仪.阳;//阳顺阴逆
            列 = 常用方法.列表顺逆排序(顺排, 列);
            var 序 = 干支表.获取地支序数(支);
            return 列[序];
        }

        #endregion

    }
}