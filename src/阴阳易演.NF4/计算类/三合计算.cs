namespace 阴阳易演.计算类
{
    using System.Collections.Generic;
    using 具象类.地支;
    using 引用库;
    using 抽象类;

    public static class 三合计算
    {
        #region 扩展

        #region 水局
        public static bool 是三合水局(this 申 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.水);
        public static bool 是三合水局(this 子 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.水);
        public static bool 是三合水局(this 辰 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.水);
        #endregion

        #region 木局
        public static bool 是三合木局(this 亥 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.木);
        public static bool 是三合木局(this 卯 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.木);
        public static bool 是三合木局(this 未 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.木);
        #endregion

        #region 金局
        public static bool 是三合金局(this 巳 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.金);
        public static bool 是三合金局(this 酉 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.金);
        public static bool 是三合金局(this 丑 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.金);
        #endregion

        #region 火局
        public static bool 是三合火局(this 寅 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.火);
        public static bool 是三合火局(this 午 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.火);
        public static bool 是三合火局(this 戌 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).Contains(五行.火);
        #endregion

        public static 五行[] 三合局(this 地支 主, 地支 客一, 地支 客二) => 地支三合(new 地支[] { 主, 客一, 客二 }).ToArray();

        #endregion

        #region 计算
        public static List<五行> 地支三合(地支[] 地支组)
        {
            var 五行列 = new List<五行>();
            if (常用方法.同时包含(地支组, 地支.申, 地支.子, 地支.辰)) { 五行列.Add(五行.水); }
            if (常用方法.同时包含(地支组, 地支.亥, 地支.卯, 地支.未)) { 五行列.Add(五行.木); }
            if (常用方法.同时包含(地支组, 地支.巳, 地支.酉, 地支.丑)) { 五行列.Add(五行.金); }
            if (常用方法.同时包含(地支组, 地支.寅, 地支.午, 地支.戌)) { 五行列.Add(五行.火); }
            return 五行列;
        }

        #endregion

    }
}