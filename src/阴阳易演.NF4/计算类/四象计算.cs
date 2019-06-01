namespace 阴阳易演.计算类
{
    using System;
    using 具象类.四象;
    using 抽象类;

    public static class 四象计算
    {
        #region 扩展
        public static 四象 推演(this 四象 四象)
        {
            switch (四象)
            {
                case 少阳 _:
                    return 四象.太阳;

                case 太阳 _:
                    return 四象.少阴;

                case 少阴 _:
                    return 四象.太阴;

                case 太阴 _:
                    return 四象.少阳;

            }
            throw new Exception($"未找到正确的推演,当前输入:{四象}");
        }
        public static 四象 追溯(this 四象 四象)
        {
            switch (四象)
            {
                case 太阴 _:
                    return 四象.少阴;

                case 少阴 _:
                    return 四象.太阳;

                case 太阳 _:
                    return 四象.少阳;

                case 少阳 _:
                    return 四象.太阴;

            }
            throw new Exception($"未找到正确的追溯,当前输入:{四象}");
        }

        #endregion

    }
}