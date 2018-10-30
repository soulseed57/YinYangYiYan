namespace 阴阳易演.抽象类
{
    using 具象类.两仪;
    using 基类;

    public abstract class 两仪 : 无极
    {
        #region 内部
        //静态
        static 两仪()
        {
            阴 = new 阴();
            阳 = new 阳();
        }

        #endregion

        #region 公开
        //静态
        public static 阴 阴 { get; }
        public static 阳 阳 { get; }
        //动态
        public byte 值 { get; protected set; }
        public string 爻 { get; protected set; }

        #endregion

        #region 运算
        //静态
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(两仪 仪1, 两仪 仪2)
        {
            var 结果 = false;
            switch (仪1)
            {
                case 阴 _ when 仪2 is 阴:
                    结果 = true;
                    break;
                case 阳 _ when 仪2 is 阳:
                    结果 = true;
                    break;
            }
            return 结果;
        }
        public static bool operator !=(两仪 仪1, 两仪 仪2)
        {
            var 结果 = false;
            switch (仪1)
            {
                case 阴 _ when 仪2 is 阳:
                    结果 = true;
                    break;
                case 阳 _ when 仪2 is 阴:
                    结果 = true;
                    break;
            }
            return 结果;
        }
        public static 四象 operator +(两仪 仪1, 两仪 仪2)
        {
            四象 四象 = null;
            switch (仪1)
            {
                case 阳 _ when 仪2 is 阳:
                    四象 = 四象.太阳;
                    break;
                case 阳 _ when 仪2 is 阴:
                    四象 = 四象.少阴;
                    break;
                case 阴 _ when 仪2 is 阳:
                    四象 = 四象.少阳;
                    break;
                case 阴 _ when 仪2 is 阴:
                    四象 = 四象.太阴;
                    break;
            }
            return 四象;
        }
        //动态

        #endregion

    }
}
