﻿using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace 阴阳易演.抽象类
{
    using 具象类.两仪;
    using 具象类.四象;
    using 基类;

    public abstract class 四象 : 无极
    {
        #region 内部
        //静态
        static 四象()
        {
            少阳 = new 少阳();
            太阳 = new 太阳();
            少阴 = new 少阴();
            太阴 = new 太阴();
            临爻 = new StringBuilder();
        }

        static readonly StringBuilder 临爻;
        //动态
        protected 四象()
        {
            仪属 = new List<两仪>();
        }
        protected List<两仪> 仪属 { get; }

        #endregion

        #region 公开
        //静态
        public static 少阳 少阳 { get; }
        public static 太阳 太阳 { get; }
        public static 少阴 少阴 { get; }
        public static 太阴 太阴 { get; }
        //动态
        public int 数字 { get; protected set; }
        public string 方位 { get; protected set; }
        public string 神兽 { get; protected set; }
        public 季节 四季 { get; protected set; }
        public Color 颜色 { get; protected set; }
        public StringBuilder 爻
        {
            get
            {
                lock (临爻)
                {
                    临爻.Clear();
                    foreach (var 仪 in 仪属)
                    {
                        临爻.AppendLine(仪.爻);
                    }
                    return 临爻;
                }
            }
        }

        #endregion

        #region 运算
        //静态
        public static 四象 推演(四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 少阳 _:
                    象 = 太阳;
                    break;
                case 太阳 _:
                    象 = 少阴;
                    break;
                case 少阴 _:
                    象 = 太阴;
                    break;
                case 太阴 _:
                    象 = 少阳;
                    break;
            }
            return 象;
        }
        public static 四象 追溯(四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 太阴 _:
                    象 = 少阴;
                    break;
                case 少阴 _:
                    象 = 太阳;
                    break;
                case 太阳 _:
                    象 = 少阳;
                    break;
                case 少阳 _:
                    象 = 太阴;
                    break;
            }
            return 象;
        }
        public static 八卦 operator +(四象 象, 两仪 仪)
        {
            八卦 八卦 = null;
            switch (象)
            {
                case 太阴 _ when 仪 is 阴:
                    八卦 = 八卦.坤;
                    break;
                case 太阴 _ when 仪 is 阳:
                    八卦 = 八卦.艮;
                    break;
                case 少阳 _ when 仪 is 阴:
                    八卦 = 八卦.坎;
                    break;
                case 少阳 _ when 仪 is 阳:
                    八卦 = 八卦.巽;
                    break;
                case 少阴 _ when 仪 is 阴:
                    八卦 = 八卦.震;
                    break;
                case 少阴 _ when 仪 is 阳:
                    八卦 = 八卦.离;
                    break;
                case 太阳 _ when 仪 is 阴:
                    八卦 = 八卦.兑;
                    break;
                case 太阳 _ when 仪 is 阳:
                    八卦 = 八卦.乾;
                    break;
            }
            return 八卦;
        }

        #endregion

    }
}
