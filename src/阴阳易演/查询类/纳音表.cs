﻿using System.Collections.Generic;

namespace 阴阳易演.查询类
{
    using System;

    public static class 纳音表
    {
        /* ----- 纳音 ----- */
        static readonly Dictionary<string, string> 六十甲子纳音表 = new Dictionary<string, string>
        {
            {"甲子", "海中金"}, {"乙丑", "海中金"},
            {"丙寅", "炉中火"}, {"丁卯", "炉中火"},
            {"戊辰", "大林木"}, {"己巳", "大林木"},
            {"庚午", "路旁土"}, {"辛未", "路旁土"},
            {"壬申", "剑锋金"}, {"癸酉", "剑锋金"},

            {"甲戌", "山头火"}, {"乙亥", "山头火"},
            {"丙子", "涧下水"}, {"丁丑", "涧下水"},
            {"戊寅", "城头土"}, {"己卯", "城头土"},
            {"庚辰", "白蜡金"}, {"辛巳", "白蜡金"},
            {"壬午", "杨柳木"}, {"癸未", "杨柳木"},

            {"甲申", "井泉水"}, {"乙酉", "井泉水"},
            {"丙戌", "屋上土"}, {"丁亥", "屋上土"},
            {"戊子", "霹雳火"}, {"己丑", "霹雳火"},
            {"庚寅", "松柏木"}, {"辛卯", "松柏木"},
            {"壬辰", "长流水"}, {"癸巳", "长流水"},

            {"甲午", "砂中金"}, {"乙未", "砂中金"},
            {"丙申", "山下火"}, {"丁酉", "山下火"},
            {"戊戌", "平地木"}, {"己亥", "平地木"},
            {"庚子", "壁上土"}, {"辛丑", "壁上土"},
            {"壬寅", "金箔金"}, {"癸卯", "金箔金"},

            {"甲辰", "覆灯火"}, {"乙巳", "覆灯火"},
            {"丙午", "天河水"}, {"丁未", "天河水"},
            {"戊申", "大驿土"}, {"己酉", "大驿土"},
            {"庚戌", "钗钏金"}, {"辛亥", "钗钏金"},
            {"壬子", "桑柘木"}, {"癸丑", "桑柘木"},

            {"甲寅", "大溪水"}, {"乙卯", "大溪水"},
            {"丙辰", "砂中土"}, {"丁巳", "砂中土"},
            {"戊午", "天上火"}, {"己未", "天上火"},
            {"庚申", "石榴木"}, {"辛酉", "石榴木"},
            {"壬戌", "大海水"}, {"癸亥", "大海水"}
        };
        public static string 甲子纳音查询(string 甲子名称)
        {
            六十甲子纳音表.TryGetValue(甲子名称, out var 结果);
            if (string.IsNullOrEmpty(结果))
            {
                throw new Exception($"纳音查询失败,未找到名称为[{甲子名称}]的纳音");
            }
            return 结果;
        }
    }
}
