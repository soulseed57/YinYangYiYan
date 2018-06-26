namespace 阴阳易演.引用库
{
    public static class 常用方法
    {
        public static string 获取类名(object obj)
        {
            return obj?.GetType().Name;
        }
    }
}
