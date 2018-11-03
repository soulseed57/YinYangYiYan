namespace 阴阳易演.引用库
{
    using System.Collections.Generic;

    public static class 常用方法
    {
        public static string 获取类名(object obj)
        {
            return obj?.GetType().Name;
        }

        public static void 顺逆插入<T>(bool isOrder, List<T> list, T obj)
        {
            if (isOrder)
            {
                list.Add(obj);
            }
            else
            {
                list.Insert(0, obj);
            }
        }
    }
}
