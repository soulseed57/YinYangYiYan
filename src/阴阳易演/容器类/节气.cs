namespace 阴阳易演.容器类
{
    using System;
    using 引用库;
    using 枚举类;

    public class 节气
    {
        #region 构造
        public 节气(DateTime 时间)
        {
            var 枚 = 节气枚举查询(时间);
            名称 = 枚举转换类<节气枚举>.获取名称(枚);
            枚举 = 枚;
            交节 = 节气时间查询(时间.Year, 枚);
            上一节气时间 = 节气索引查询(时间.Year, (int)枚 - 1);
            下一节气时间 = 节气索引查询(时间.Year, (int)枚 + 1);
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public 节气枚举 枚举 { get; }
        public DateTime 交节 { get; }
        public DateTime 上一节气时间 { get; }
        public DateTime 下一节气时间 { get; }

        #endregion

        #region 方法
        public static 节气枚举 节气枚举查询(DateTime 时间, bool 精确到分钟 = false)
        {
            var 序数 = 枚举转换类<节气枚举>.获取序数(节气枚举.冬至);// 默认为上一年最后一个节气冬至
            for (var i = 0; i < 节气修正分钟.Length; i++)
            {
                var 枚 = 枚举转换类<节气枚举>.获取枚举(i);
                var 节气时间 = 节气时间查询(时间.Year, 枚);
                var 时间差 = 节气时间 - 时间;
                if (精确到分钟)
                {
                    if (时间差.TotalMinutes > 0)
                    {
                        break;
                    }
                }
                else
                {
                    if (时间差.TotalHours > 24)
                    {
                        break;
                    }
                }
                序数 = i;
            }
            return 枚举转换类<节气枚举>.获取枚举(序数);
        }
        public static DateTime 节气时间查询(int 年份, 节气枚举 枚)
        {
            var 序号 = 枚举转换类<节气枚举>.获取序数(枚);
            return 基准时间.AddMinutes(年份修正分钟(年份) + 节气修正分钟[序号]);
        }
        public static DateTime 节气索引查询(int 年份, int 索引)
        {
            var 进位数 = 节气修正分钟.Length;
            var 序号 = 常用方法.序数取余(索引, 进位数);
            var 余数 = 索引 % 进位数;
            var 进位 = 索引 < 0 && 余数 == 0 ? 索引 / 进位数 + 1 : 索引 / 进位数;
            var 修正 = 索引 < 0 ? 进位 - 1 : 进位;
            var 查年 = 年份 + 修正;
            return 基准时间.AddMinutes(年份修正分钟(查年) + 节气修正分钟[序号]);
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

        #region 重写
        public override string ToString() => 名称;

        #endregion

    }
}
