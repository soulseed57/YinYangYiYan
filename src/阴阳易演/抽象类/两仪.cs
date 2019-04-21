namespace 阴阳易演.抽象类
{
    using 具象类.两仪;
    using 基类;
    using 查询类;
    using 计算类;

    public abstract class 两仪 : 太极
    {
        #region 构造
        static 两仪()
        {
            阴 = new 阴();
            阳 = new 阳();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 阴 阴 { get; }
        public static 阳 阳 { get; }
        // 动态属性
        public byte 值 { get; protected set; }
        public string 爻 { get; protected set; }

        #endregion

        #region 运算符
        public static 四象 operator +(两仪 一, 两仪 二)
        {
            四象 四象 = null;
            switch (一)
            {
                case 阳 _ when 二 is 阳:
                    四象 = 四象.太阳;
                    break;
                case 阳 _ when 二 is 阴:
                    四象 = 四象.少阴;
                    break;
                case 阴 _ when 二 is 阳:
                    四象 = 四象.少阳;
                    break;
                case 阴 _ when 二 is 阴:
                    四象 = 四象.太阴;
                    break;
            }
            return 四象;
        }
        public static 八卦 operator +(四象 象, 两仪 仪)
        {
            var 爻序 = 卦爻计算.还原爻序(象.爻值, 2) + 卦爻计算.还原爻序(仪.值, 1);
            var 爻值 = 卦爻计算.生成爻值(爻序);
            return 八卦表.八卦列表.Find(t => t.爻值 == 爻值);
        }
        public static 八卦 operator +(两仪 仪, 四象 象)
        {
            var 爻序 = 卦爻计算.还原爻序(象.爻值, 2) + 卦爻计算.还原爻序(仪.值, 1);
            var 爻值 = 卦爻计算.生成爻值(爻序);
            return 八卦表.八卦列表.Find(t => t.爻值 == 爻值);
        }
        public static bool operator ==(两仪 一, 两仪 二)
        {
            if (一 is null && 二 is null)
            {
                return true;
            }
            if (一 is null || 二 is null)
            {
                return false;
            }
            return 一.值 == 二.值;
        }
        public static bool operator !=(两仪 一, 两仪 二)
        {
            return !(一 == 二);
        }
        public override bool Equals(object obj)
        {
            return this == (两仪)obj;
        }

        #endregion

    }
}
