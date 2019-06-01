#pragma warning disable 660,659,661
namespace 阴阳易演.抽象类.基类
{
    public abstract class 无极
    {
        public string 名称 => GetType().Name;

        #region 运算符
        public static bool operator ==(无极 一, 无极 二)
        {
            if (一 is null && 二 is null)
            {
                return true;
            }
            if (一 is null || 二 is null)
            {
                return false;
            }
            return 一.名称 == 二.名称;
        }
        public static bool operator !=(无极 一, 无极 二)
        {
            return !(一 == 二);
        }
        #endregion

        #region 重写
        public override bool Equals(object obj) => 名称 == ((无极)obj)?.名称;
        public override string ToString() => 名称;
        #endregion

    }
}
