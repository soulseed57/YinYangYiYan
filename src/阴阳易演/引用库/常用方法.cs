namespace 阴阳易演.引用库
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class 常用方法
    {
        /// <summary>
        /// 序数取余,当为负数时以倒数计算
        /// </summary>
        /// <param name="原数"></param>
        /// <param name="进位数"></param>
        /// <returns></returns>
        public static int 序数取余(int 原数, int 进位数)
        {
            var 余数 = 原数 % 进位数;
            return 余数 < 0 ? 进位数 + 余数 : 余数;
        }
        /// <summary>
        /// 归零取余,取绝对值,余数除尽时归零
        /// </summary>
        /// <param name="原数"></param>
        /// <param name="进位数"></param>
        /// <returns></returns>
        public static int 归零取余(int 原数, int 进位数)
        {
            var 余数 = Math.Abs(原数) % 进位数;
            return 余数;
        }
        /// <summary>
        /// 进位取余,取绝对值,余数除尽时进位
        /// </summary>
        /// <param name="原数"></param>
        /// <param name="进位数"></param>
        /// <returns></returns>
        public static int 进位取余(int 原数, int 进位数)
        {
            var 余数 = Math.Abs(原数) % 进位数;
            return 余数 == 0 ? 进位数 : 余数;
        }
        /// <summary>
        /// 列表顺逆插入,按指定顺逆方向插入项,顺序时向后插入,逆序时向前插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isOrder"></param>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static void 列表顺逆插入<T>(bool isOrder, List<T> list, T item)
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
        /// <summary>
        /// 列表顺逆排序,按照指定方向排序,首位不变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isOrder"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] 列表顺逆排序<T>(bool isOrder, T[] array)
        {
            if (isOrder)
            {
                return array;
            }
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
        /// <summary>
        /// 列表指定首位,将指定位置的项提前至首位,其他项依次排在队尾
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T[] 列表指定首位<T>(T[] array, int index)
        {
            // 处理索引
            if (index == 0)
            {
                return array;
            }
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
        /// <summary>
        /// 同时包含所有给定元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool 同时包含<T>(T[] array, params T[] items)
        {
            return items.All(array.Contains);
        }
    }
}
