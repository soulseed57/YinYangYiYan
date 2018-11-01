using System;

namespace 阴阳易演.抽象类
{
    using System.Collections.Generic;

    public abstract class 河图洛书
    {
        protected 河图洛书(int 原数)
        {
            数字 = 河洛数(原数);
            switch (数字)
            {
                case 1:
                    阴阳 = 两仪.阳;
                    五行 = 五行.水;
                    break;
                case 2:
                    阴阳 = 两仪.阴;
                    五行 = 五行.火;
                    break;
                case 3:
                    阴阳 = 两仪.阳;
                    五行 = 五行.木;
                    break;
                case 4:
                    阴阳 = 两仪.阴;
                    五行 = 五行.金;
                    break;
                case 5:
                    阴阳 = 两仪.阳;
                    五行 = 五行.土;
                    break;
                case 6:
                    阴阳 = 两仪.阴;
                    五行 = 五行.水;
                    break;
                case 7:
                    阴阳 = 两仪.阳;
                    五行 = 五行.火;
                    break;
                case 8:
                    阴阳 = 两仪.阴;
                    五行 = 五行.木;
                    break;
                case 9:
                    阴阳 = 两仪.阳;
                    五行 = 五行.金;
                    break;
                case 10:
                    阴阳 = 两仪.阴;
                    五行 = 五行.土;
                    break;
                default:
                    throw new Exception($"数值错误,当前给定数值{原数}不正确,算数{数字}未找到匹配值");
            }
        }

        #region 内部
        //动态
        protected readonly List<八卦> 河图八卦 = new List<八卦>
        {
            八卦.乾, 八卦.兑,
            八卦.离, 八卦.震,
            八卦.巽, 八卦.坎,
            八卦.艮, 八卦.坤
        };
        protected readonly int[][] 洛书九宫 =
        {
            new[] { 4, 9, 2 },
            new[] { 3, 5, 7 },
            new[] { 8, 1, 6 }
        };

        #endregion

        #region 公开
        //动态
        public int 数字 { get; protected set; }
        public 两仪 阴阳 { get; protected set; }
        public 五行 五行 { get; protected set; }

        #endregion

        #region 计算
        // 静态
        public static int 河洛数(int 原数)
        {
            var 算数 = Math.Abs(原数) % 10;
            return 算数 == 0 ? 10 : 算数;
        }
        // 动态

        #endregion

    }
}