namespace 阴阳易演.引用库
{
    using System.Collections.Generic;

    public static class 常用方法
    {
        public static string 获取类名(object obj)
        {
            return obj?.GetType().Name;
        }

        public static void 顺逆插入<T>(bool isOrder, List<T> list, T item)
        {
            if (isOrder)
            {
                list.Add(item);
            }
            else
            {
                list.Insert(0, item);
            }
        }

        public static T[] 顺逆排序<T>(bool isOrder, T[] array)
        {
            var list = new List<T>();
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                int index;
                if (isOrder)
                {
                    index = i;
                }
                else
                {
                    if (i == 0)
                    {
                        index = i;
                    }
                    else
                    {
                        index = len - i;
                    }
                }
                list.Add(array[index]);
            }
            return list.ToArray();
        }

    }
}
