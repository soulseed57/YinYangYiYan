using System;
using System.Text.RegularExpressions;

namespace 阴阳易演.抽象类
{
    using 具象类.八卦;
    using 基类;

    public abstract class 八卦 : 无极
    {
        #region 天清
        static 八卦()
        {
            乾 = new 乾();
            兑 = new 兑();
            离 = new 离();
            震 = new 震();
            巽 = new 巽();
            坎 = new 坎();
            艮 = new 艮();
            坤 = new 坤();
        }

        #endregion

        #region 地浊
        //阴静
        public static 乾 乾 { get; }
        public static 兑 兑 { get; }
        public static 离 离 { get; }
        public static 震 震 { get; }
        public static 巽 巽 { get; }
        public static 坎 坎 { get; }
        public static 艮 艮 { get; }
        public static 坤 坤 { get; }
        //阳动
        public int 先天卦序 { get; protected set; }
        public int 后天卦序 { get; protected set; }
        public string 先天卦位 { get; protected set; }
        public string 后天卦位 { get; protected set; }
        public byte 卦值 { get; protected set; }

        #endregion

        #region 运算
        ///<summary>
        ///生成卦值计算,仅允许输入由0和1组成的字符串,且位序从左至右依次升高
        ///</summary>
        ///<param name="卦序"></param>
        ///<returns></returns>
        public static byte 生成卦值(string 卦序)
        {
            var reg = new Regex("^[0,1]*$");
            if (!reg.IsMatch(卦序)) throw new Exception("卦序输入错误,仅可输入0和1,当前输入:[" + 卦序 + "]");
            var charArray = 卦序.ToCharArray();
            Array.Reverse(charArray);
            var 位序 = new string(charArray);
            return Convert.ToByte(位序, 2);
        }
        ///<summary>
        ///还原卦值计算,将二进制数还原为卦序,注意卦序的低位在左而二进制的低位在右所以卦序与二进制位序相反,默认爻数为3,可根据需要自行设置
        ///</summary>
        ///<param name="卦值"></param>
        ///<param name="爻数"></param>
        ///<returns></returns>
        public static string 还原卦值(byte 卦值, int 爻数 = 3)
        {
            var charArray = "".PadLeft(爻数, '0').ToCharArray();
            var convArray = Convert.ToString(卦值, 2).ToCharArray();
            for (var i = 0; i < convArray.Length; i++)
            {
                charArray[i] = convArray[convArray.Length - 1 - i];
            }
            return new string(charArray);
        }

        #endregion

    }
}
