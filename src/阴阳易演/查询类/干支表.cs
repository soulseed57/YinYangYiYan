using System;

namespace 阴阳易演.查询类
{
    using 具象类.天干;
    using 抽象类;

    public static class 干支表
    {
        /* ----- 天干 ----- */
        public static 天干[] 天干表 => new 天干[] { 阳干.甲木, 阳干.丙火, 阳干.戊土, 阳干.庚金, 阳干.壬水, 阴干.乙木, 阴干.丁火, 阴干.己土, 阴干.辛金, 阴干.癸水 };
        public static 天干[] 阳干表 => new 天干[] { 阳干.甲木, 阳干.丙火, 阳干.戊土, 阳干.庚金, 阳干.壬水 };
        public static 天干[] 阴干表 => new 天干[] { 阴干.乙木, 阴干.丁火, 阴干.己土, 阴干.辛金, 阴干.癸水 };
        /* ----- 地支 ----- */
        public static 地支[] 地支表 => new 地支[] { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };

        #region 方法
        public static 天干 天干查询(string 名称)
        {
            天干 结果;
            switch (名称)
            {
                case "甲":
                    结果 = 天干.甲;
                    break;
                case "乙":
                    结果 = 天干.乙;
                    break;
                case "丙":
                    结果 = 天干.丙;
                    break;
                case "丁":
                    结果 = 天干.丁;
                    break;
                case "戊":
                    结果 = 天干.戊;
                    break;
                case "己":
                    结果 = 天干.己;
                    break;
                case "庚":
                    结果 = 天干.庚;
                    break;
                case "辛":
                    结果 = 天干.辛;
                    break;
                case "壬":
                    结果 = 天干.壬;
                    break;
                case "癸":
                    结果 = 天干.癸;
                    break;
                default:
                    throw new Exception($"输入的名称[{名称}]不是天干");
            }
            return 结果;
        }
        public static 地支 地支查询(string 名称)
        {
            地支 结果;
            switch (名称)
            {
                case "子":
                    结果 = 地支.子;
                    break;
                case "丑":
                    结果 = 地支.丑;
                    break;
                case "寅":
                    结果 = 地支.寅;
                    break;
                case "卯":
                    结果 = 地支.卯;
                    break;
                case "辰":
                    结果 = 地支.辰;
                    break;
                case "巳":
                    结果 = 地支.巳;
                    break;
                case "午":
                    结果 = 地支.午;
                    break;
                case "未":
                    结果 = 地支.未;
                    break;
                case "申":
                    结果 = 地支.申;
                    break;
                case "酉":
                    结果 = 地支.酉;
                    break;
                case "戌":
                    结果 = 地支.戌;
                    break;
                case "亥":
                    结果 = 地支.亥;
                    break;
                default:
                    throw new Exception($"输入的名称[{名称}]不是地支");
            }
            return 结果;
        }

        #endregion

        #region 静态类
        public static class 阳干
        {
            static 阳干()
            {
                甲木 = new 甲木();
                丙火 = new 丙火();
                戊土 = new 戊土();
                庚金 = new 庚金();
                壬水 = new 壬水();
            }
            public static 甲木 甲木 { get; }
            public static 丙火 丙火 { get; }
            public static 戊土 戊土 { get; }
            public static 庚金 庚金 { get; }
            public static 壬水 壬水 { get; }
        }

        public static class 阴干
        {
            static 阴干()
            {
                乙木 = new 乙木();
                丁火 = new 丁火();
                己土 = new 己土();
                辛金 = new 辛金();
                癸水 = new 癸水();
            }
            public static 乙木 乙木 { get; }
            public static 丁火 丁火 { get; }
            public static 己土 己土 { get; }
            public static 辛金 辛金 { get; }
            public static 癸水 癸水 { get; }
        }

        #endregion
    }
}
