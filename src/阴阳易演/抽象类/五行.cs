namespace 阴阳易演.抽象类
{
    using 具象类.五行;
    using 基类;
    using 枚举类;

    public abstract class 五行 : 无极
    {
        #region 天清
        static 五行()
        {
            金 = new 金();
            水 = new 水();
            木 = new 木();
            火 = new 火();
            土 = new 土();
        }

        #endregion

        #region 地浊
        // 阴静
        public static 金 金 { get; }
        public static 水 水 { get; }
        public static 木 木 { get; }
        public static 火 火 { get; }
        public static 土 土 { get; }
        // 阳动
        public int 数字 { get; protected set; }
        public string 方位 { get; protected set; }
        public string 神兽 { get; protected set; }
        public 季节 四季 { get; protected set; }
        public string 颜色 { get; protected set; }

        #endregion

        #region 运算
        // 阴静
        public static 五行 父母(五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 土;
                    break;
                case 水 _:
                    结果 = 金;
                    break;
                case 木 _:
                    结果 = 水;
                    break;
                case 火 _:
                    结果 = 木;
                    break;
                case 土 _:
                    结果 = 火;
                    break;
            }
            return 结果;
        }
        public static 五行 子孙(五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 水;
                    break;
                case 水 _:
                    结果 = 木;
                    break;
                case 木 _:
                    结果 = 火;
                    break;
                case 火 _:
                    结果 = 土;
                    break;
                case 土 _:
                    结果 = 金;
                    break;
            }
            return 结果;
        }
        public static 五行 官鬼(五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 火;
                    break;
                case 水 _:
                    结果 = 土;
                    break;
                case 木 _:
                    结果 = 金;
                    break;
                case 火 _:
                    结果 = 水;
                    break;
                case 土 _:
                    结果 = 木;
                    break;
            }
            return 结果;
        }
        public static 五行 妻妾(五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 木;
                    break;
                case 水 _:
                    结果 = 火;
                    break;
                case 木 _:
                    结果 = 土;
                    break;
                case 火 _:
                    结果 = 金;
                    break;
                case 土 _:
                    结果 = 水;
                    break;
            }
            return 结果;
        }
        public static 五行 兄弟(五行 行属)
        {
            五行 结果 = null;
            switch (行属)
            {
                case 金 _:
                    结果 = 金;
                    break;
                case 水 _:
                    结果 = 水;
                    break;
                case 木 _:
                    结果 = 木;
                    break;
                case 火 _:
                    结果 = 火;
                    break;
                case 土 _:
                    结果 = 土;
                    break;
            }
            return 结果;
        }
        public static bool 比和(五行 行1, 五行 行2) => 行1.Equals(行2);
        // 阳动
        public bool 比和(五行 行属) => 行属.Equals(this);

        #endregion

    }
}
