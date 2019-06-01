namespace 阴阳易演.计算类
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using 引用库;
    using 抽象类;
    using 枚举类;

    public static class 八卦计算
    {
        #region 内部参数
        static readonly Dictionary<节气节令, List<八卦>> 八卦八节旺衰字典 = new Dictionary<节气节令, List<八卦>>
        {
            { 节气节令.立冬, new List<八卦> { 八卦.乾, 八卦.坎, 八卦.艮, 八卦.震, 八卦.巽, 八卦.离, 八卦.坤, 八卦.兑 } },
            { 节气节令.立春, new List<八卦> { 八卦.艮, 八卦.震, 八卦.巽, 八卦.离, 八卦.坤, 八卦.兑, 八卦.乾, 八卦.坎 } },
            { 节气节令.立夏, new List<八卦> { 八卦.巽, 八卦.离, 八卦.坤, 八卦.兑, 八卦.乾, 八卦.坎, 八卦.艮, 八卦.震 } },
            { 节气节令.立秋, new List<八卦> { 八卦.坤, 八卦.兑, 八卦.乾, 八卦.坎, 八卦.艮, 八卦.震, 八卦.巽, 八卦.离 } },
            { 节气节令.冬至, new List<八卦> { 八卦.坎, 八卦.艮, 八卦.震, 八卦.巽, 八卦.离, 八卦.坤, 八卦.兑, 八卦.乾 } },
            { 节气节令.春分, new List<八卦> { 八卦.震, 八卦.巽, 八卦.离, 八卦.坤, 八卦.兑, 八卦.乾, 八卦.坎, 八卦.艮 } },
            { 节气节令.夏至, new List<八卦> { 八卦.离, 八卦.坤, 八卦.兑, 八卦.乾, 八卦.坎, 八卦.艮, 八卦.震, 八卦.巽 } },
            { 节气节令.秋分, new List<八卦> { 八卦.兑, 八卦.乾, 八卦.坎, 八卦.艮, 八卦.震, 八卦.巽, 八卦.离, 八卦.坤 } }
        };
        #endregion

        #region 扩展
        public static 八卦八节旺衰 八节旺衰(this 八卦 卦, 节气节令 八节)
        {
            if (!八卦八节旺衰字典.ContainsKey(八节))
            {
                throw new Exception($"当前节气[{八节}]不是八节,无法匹配旺衰");
            }
            var 序列 = 八卦八节旺衰字典[八节];
            var 序数 = 序列.IndexOf(卦);
            return 枚举转换类<八卦八节旺衰>.获取枚举(序数);
        }
        public static 节气节令 八节旺衰(this 八卦 卦, 八卦八节旺衰 旺衰)
        {
            var 旺衰序数 = 枚举转换类<八卦八节旺衰>.获取序数(旺衰);
            foreach (var 字典 in 八卦八节旺衰字典)
            {
                var 查卦 = 字典.Value[旺衰序数];
                if (查卦 == 卦)
                {
                    return 字典.Key;
                }
            }
            throw new Exception($"未找到匹配的节气枚举,当前输入:[{旺衰},{卦.名称}]");
        }
        #endregion

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