#pragma warning disable 660,661
namespace 阴阳易演.抽象类
{
    using 具象类.两仪;
    using 基类;
    using 查询类;

    public abstract class 两仪 : 无极
    {
        #region 天清
        static 两仪()
        {
            阴 = new 阴();
            阳 = new 阳();
        }

        #endregion

        #region 地浊
        //阴静
        public static 阴 阴 { get; }
        public static 阳 阳 { get; }
        //阳动
        public byte 值 { get; protected set; }
        public string 爻 { get; protected set; }

        #endregion

        #region 运算
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
        public static 八卦 operator +(四象 象, 两仪 仪)
        {
            var 卦序 = 八卦.还原卦值(象.卦值, 2) + 八卦.还原卦值(仪.值, 1);
            var 卦值 = 八卦.生成卦值(卦序);
            return 八卦表.八卦列表.Find(t => t.卦值 == 卦值);
        }
        public static 八卦 operator +(两仪 仪, 四象 象)
        {
            var 卦序 = 八卦.还原卦值(象.卦值, 2) + 八卦.还原卦值(仪.值, 1);
            var 卦值 = 八卦.生成卦值(卦序);
            return 八卦表.八卦列表.Find(t => t.卦值 == 卦值);
        }

        #endregion

    }
}
