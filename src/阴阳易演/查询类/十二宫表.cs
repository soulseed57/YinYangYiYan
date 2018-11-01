using System;
using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using 具象类.地支;
    using 容器类;
    using 引用库;
    using 抽象类;

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
        static bool 地支顺逆(地支 支)
        {
            switch (支)
            {
                case 子 _:
                case 丑 _:
                case 寅 _:
                case 午 _:
                case 未 _:
                case 申 _:
                    return true;
                case 卯 _:
                case 辰 _:
                case 巳 _:
                case 酉 _:
                case 戌 _:
                case 亥 _:
                    return false;
            }
            throw new Exception("未找到给定的地支");
        }
        static int 命寿起支(地支 支)
        {
            地支 起;
            switch (支)
            {
                case 未 _:
                    起 = 地支.丑;
                    break;
                case 午 _:
                case 巳 _:
                    起 = 地支.寅;
                    break;
                case 戌 _:
                    起 = 地支.辰;
                    break;
                case 申 _:
                case 酉 _:
                    起 = 地支.巳;
                    break;
                case 丑 _:
                    起 = 地支.未;
                    break;
                case 子 _:
                case 亥 _:
                    起 = 地支.申;
                    break;
                case 辰 _:
                    起 = 地支.戌;
                    break;
                case 寅 _:
                case 卯 _:
                    起 = 地支.亥;
                    break;
                default:
                    throw new Exception($"无法从给定的地支起宫序,当前地支:{支}");
            }
            return 干支表.获取地支序数(起);
        }
        static 地支[] 排宫支(地支 支)
        {
            var 宫列 = new List<地支>();
            var 是顺序 = 地支顺逆(支);
            var 起支 = 命寿起支(支);
            for (var i = 0; i < 干支表.地支数; i++)
            {
                var 宫 = 干支表.地支查询(起支);
                宫列.Add(宫);
                if (是顺序)
                {
                    起支++;
                }
                else
                {
                    起支--;
                }
            }
            return 宫列.ToArray();
        }
        // 公开
        public static 宫[] 起十二宫(天干 干, 地支 支)
        {
            var 宫集 = 排宫支(支);
            var 宫位 = new 宫[12];
            for (var i = 0; i < 宫集.Length; i++)
            {
                var 宫支 = 宫集[i];
                var 宫干 = 干支表.五鼠遁(干, 宫支);
                var 甲子 = new 甲子(宫干, 宫支);
                宫位[i] = new 宫(获取十二宫名称(i), 甲子);
            }
            return 宫位;
        }
        public static 宫[] 起十二宫(地支 支)
        {
            var 宫集 = 排宫支(支);
            var 宫位 = new 宫[12];
            for (var i = 0; i < 宫集.Length; i++)
            {
                var 宫支 = 宫集[i];
                宫位[i] = new 宫(获取十二宫名称(i), 宫支);
            }
            return 宫位;
        }

        #endregion

    }
}
