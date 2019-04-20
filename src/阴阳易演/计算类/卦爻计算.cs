namespace 阴阳易演.计算类
{
    using System;
    using System.Text.RegularExpressions;

    public static class 卦爻计算
    {
        #region 计算
        /// <summary>
        /// 生成爻值计算,仅允许输入由0和1组成的字符串,且位序从左至右依次升高
        /// </summary>
        /// <param name="爻序"></param>
        /// <returns></returns>
        public static byte 生成爻值(string 爻序)
        {
            var reg = new Regex("^[0,1]*$");
            if (!reg.IsMatch(爻序))
            {
                throw new Exception("爻序输入错误,仅可输入0和1,当前输入:[" + 爻序 + "]");
            }

            var charArray = 爻序.ToCharArray();
            Array.Reverse(charArray);
            var 位序 = new string(charArray);
            return Convert.ToByte(位序, 2);
        }
        /// <summary>
        /// 还原爻序计算,将二进制数还原为爻序,注意爻序的低位在左而二进制的低位在右所以爻序与二进制位序相反,默认爻数为3,可根据需要自行设置
        /// </summary>
        /// <param name="爻值"></param>
        /// <param name="爻数"></param>
        /// <returns></returns>
        public static string 还原爻序(byte 爻值, int 爻数)
        {
            var charArray = "".PadLeft(爻数, '0').ToCharArray();
            var convArray = Convert.ToString(爻值, 2).ToCharArray();
            for (var i = 0; i < convArray.Length; i++)
            {
                charArray[i] = convArray[convArray.Length - 1 - i];
            }
            return new string(charArray);
        }

        #endregion

    }
}