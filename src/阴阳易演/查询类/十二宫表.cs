using System;
using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using 具象类.地支;
    using 具象类.天干;
    using 容器类;
    using 引用库;
    using 抽象类;

    public class 十二宫表
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
            var 序 = 枚举转换类<十二宫枚举>.序数取余(数, 十二宫数);
            return 枚举转换类<十二宫枚举>.获取枚举(序);
        }
        public static string 获取十二宫名称(int 数)
        {
            var 序 = 枚举转换类<十二宫枚举>.序数取余(数, 十二宫数);
            return 枚举转换类<十二宫枚举>.获取名称(序);
        }

        #endregion

        #region 运算
        // 内部
        static int 起宫序数(地支 支)
        {
            switch (支)
            {
                case 未 _:
                    return 1;
                case 午 _:
                case 巳 _:
                    return 2;
                case 戌 _:
                    return 4;
                case 申 _:
                case 酉 _:
                    return 5;
                case 丑 _:
                    return 7;
                case 子 _:
                case 亥 _:
                    return 8;
                case 辰 _:
                    return 10;
                case 寅 _:
                case 卯 _:
                    return 11;
                default:
                    throw new Exception($"无法从给定的地支起宫序,当前地支:{支}");
            }
        }
        static 地支[] 排宫支(地支 支)
        {
            var 顺序 = 支.阴阳 == 两仪.阳;// 阳顺阴逆
            var 宫列 = new List<地支>();
            var 宫序 = 起宫序数(支);
            for (var i = 0; i < 干支表.地支数; i++)
            {
                var 宫 = 干支表.地支查询(宫序);
                宫列.Add(宫);
                if (顺序)
                {
                    宫序++;
                }
                else
                {
                    宫序--;
                }
            }
            return 宫列.ToArray();
        }
        // 公开
        public static 宫[] 起十二宫(天干 干, 地支 支)
        {
            var 排宫 = 排宫支(支);
            var 宫位 = new 宫[12];
            for (var i = 0; i < 排宫.Length; i++)
            {
                宫位[i] = new 宫(获取十二宫名称(i), 五子遁(干, 排宫[i]));
            }
            return 宫位;
        }
        public static 甲子 五子遁(天干 干, 地支 支)
        {
            int 偏移;
            switch (干)
            {
                case 甲 _:
                case 己 _:
                    偏移 = 0;
                    break;
                case 乙 _:
                case 庚 _:
                    偏移 = 2;
                    break;
                case 丙 _:
                case 辛 _:
                    偏移 = 4;
                    break;
                case 丁 _:
                case 壬 _:
                    偏移 = 6;
                    break;
                case 戊 _:
                case 癸 _:
                    偏移 = 8;
                    break;
                default:
                    throw new Exception($"起遁失败,当前给定天干错误[{干}]");
            }
            var 地支名 = 常用方法.获取类名(支);
            var 地支数 = 枚举转换类<干支表.地支枚举>.获取序数(地支名);
            var 天干数 = (偏移 + 地支数) % 10;
            var 天干名 = 枚举转换类<干支表.天干枚举>.获取名称(天干数);
            var 天干 = 干支表.天干查询(天干名);
            return new 甲子(天干, 支);
        }

        #endregion

    }
}
