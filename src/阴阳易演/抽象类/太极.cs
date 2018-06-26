using System;

namespace 阴阳易演.抽象类
{
    using 基类;

    public abstract class 太极 : 无极
    {
        #region 内部
        //静态
        static 太极()
        {
            阴爻 = "--";
            阳爻 = "—";
            阴值 = '阴';
            阳值 = '阳';
        }

        #endregion

        #region 公开
        //静态
        public static string 阴爻 { get; }
        public static string 阳爻 { get; }
        public static char 阴值 { get; }
        public static char 阳值 { get; }
        //动态

        #endregion

        #region 运算
        public static int 河洛数(int 原数)
        {
            var 算数 = Math.Abs(原数) % 10;
            return 算数 == 0 ? 10 : 算数;
        }

        #endregion

    }
}
