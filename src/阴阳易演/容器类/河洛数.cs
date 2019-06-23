namespace 阴阳易演.容器类
{
    using System;
    using 引用库;
    using 抽象类;
    using 查询类;

    public class 河洛数
    {
        #region 构造
        public 河洛数(int 数)
        {
            数字 = 常用方法.归零取余(数, 10);
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
                    throw new Exception($"数值错误,当前给定数值{数}不正确,算数{数字}未找到匹配值");
            }
            天干 = 干支表.天干列表.Find(t => t.阴阳 == 阴阳 && t.五行 == 五行);
            地支 = 干支表.地支列表.FindAll(t => t.阴阳 == 阴阳 && t.五行 == 五行).ToArray();
        }

        #endregion

        #region 属性
        public int 数字 { get; }
        public 两仪 阴阳 { get; }
        public 五行 五行 { get; }
        public 天干 天干 { get; }
        public 地支[] 地支 { get; }

        #endregion

    }
}