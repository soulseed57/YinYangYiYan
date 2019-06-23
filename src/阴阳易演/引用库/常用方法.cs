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
        /// <param name="顺序插入"></param>
        /// <param name="列表"></param>
        /// <param name="项"></param>
        public static void 列表顺逆插入<T>(bool 顺序插入, List<T> 列表, T 项)
        {
            if (顺序插入)
            {
                列表.Add(项);
            }
            else
            {
                列表.Insert(0, 项);
            }
        }
        /// <summary>
        /// 列表顺逆排序,按照指定方向排序,首位不变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="顺序插入"></param>
        /// <param name="集合"></param>
        /// <returns></returns>
        public static T[] 列表顺逆排序<T>(bool 顺序插入, T[] 集合)
        {
            if (顺序插入)
            {
                return 集合;
            }
            var list = new List<T>();
            var len = 集合.Length;
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
                list.Add(集合[index]);
            }
            return list.ToArray();
        }
        /// <summary>
        /// 列表指定首位,将指定位置的项提前至首位,其他项依次排在队尾
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="集合"></param>
        /// <param name="索引"></param>
        /// <returns></returns>
        public static T[] 列表指定首位<T>(T[] 集合, int 索引)
        {
            // 处理索引
            if (索引 == 0)
            {
                return 集合;
            }
            索引 = 索引 % 集合.Length;
            索引 = 索引 < 0 ? 集合.Length + 索引 : 索引;
            // 出队入队
            var queue = new Queue<T>(集合);
            for (var i = 0; i < 索引; i++)
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
        /// <param name="集合"></param>
        /// <param name="包含项"></param>
        /// <returns></returns>
        public static bool 同时包含<T>(T[] 集合, params T[] 包含项)
        {
            return 包含项.All(集合.Contains);
        }
        /// <summary>
        /// 合并主组和客组为一个列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="主集合"></param>
        /// <param name="客集合"></param>
        /// <returns></returns>
        public static T[] 合并列表<T>(T[] 主集合, T[] 客集合)
        {
            var list = new List<T>();
            list.AddRange(主集合);
            list.AddRange(客集合);
            return list.ToArray();
        }

    }
}
