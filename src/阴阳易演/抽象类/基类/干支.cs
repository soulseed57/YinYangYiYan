namespace 阴阳易演.抽象类.基类
{
    using 枚举类;

    public abstract class 干支 : 无极
    {
        public 两仪 阴阳 { get; protected set; }
        public 五行 五行 { get; protected set; }
        public 十六方位 方位 { get; protected set; }
    }
}
