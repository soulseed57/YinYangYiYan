namespace 阴阳易演.引用库
{
    using System.Collections.Generic;

    public static class 常用方法
    {
        public static string 获取类名(object obj)
        {
            return obj?.GetType().Name;
        }

        public static int 序数取余(int 序数, int 除余数)
        {
            var 算数 = 序数 % 除余数;
            return 算数 < 0 ? 除余数 + 算数 : 算数;
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
            if (isOrder) return array;
            var list = new List<T>();
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                int index;
                if (i == 0)
                {
                    index = i;
                }
                else
                {
                    index = len - i;
                }
                list.Add(array[index]);
            }
            return list.ToArray();
        }

        public static T[] 指定首位<T>(T[] array, int index)
        {
            // 处理索引
            if (index == 0) return array;
            index = index % array.Length;
            index = index < 0 ? array.Length + index : index;
            // 出队入队
            var queue = new Queue<T>(array);
            for (var i = 0; i < index; i++)
            {
                var item = queue.Dequeue();
                queue.Enqueue(item);
            }
            return queue.ToArray();
        }
    }
}
