namespace 阴阳易演.计算类
{
    using 具象类.四象;
    using 抽象类;

    public static class 四象计算
    {
        #region 扩展
        public static 四象 推演(this 四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 少阳 _:
                    象 = 四象.太阳;
                    break;
                case 太阳 _:
                    象 = 四象.少阴;
                    break;
                case 少阴 _:
                    象 = 四象.太阴;
                    break;
                case 太阴 _:
                    象 = 四象.少阳;
                    break;
            }
            return 象;
        }
        public static 四象 追溯(this 四象 象属)
        {
            四象 象 = null;
            switch (象属)
            {
                case 太阴 _:
                    象 = 四象.少阴;
                    break;
                case 少阴 _:
                    象 = 四象.太阳;
                    break;
                case 太阳 _:
                    象 = 四象.少阳;
                    break;
                case 少阳 _:
                    象 = 四象.太阴;
                    break;
            }
            return 象;
        }

        #endregion

    }
}