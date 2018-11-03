using System;

namespace 阴阳易演.容器类
{
    using 抽象类;
    using 查询类;

    public class 河洛数
    {
        #region 天清
        public 河洛数(int 原数)
        {
            数字 = 十进制取余(原数);
            switch (数字)
            {
                case 0:
                    阴阳 = 两仪.阴;
                    五行 = 五行.土;
                    break;
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
                default:
                    throw new Exception($"数值错误,当前给定数值{原数}不正确,算数{数字}未找到匹配值");
            }
            先天卦 = 八卦表.八卦列表.Find(t => t.先天卦序 == 数字);
            后天卦 = 八卦表.八卦列表.Find(t => t.后天卦序 == 数字);
        }

        #endregion

        #region 地浊
        //阴静
        public static readonly int[][] 洛书九宫 =
        {
            new[] { 4, 9, 2 },
            new[] { 3, 5, 7 },
            new[] { 8, 1, 6 }
        };
        //阳动
        public int 数字 { get; protected set; }
        public 两仪 阴阳 { get; protected set; }
        public 五行 五行 { get; protected set; }
        public 八卦 先天卦 { get; }
        public 八卦 后天卦 { get; }

        #endregion

        #region 运算
        public static int 十进制取余(int 原数)
        {
            return Math.Abs(原数) % 10;
        }

        #endregion

    }
}