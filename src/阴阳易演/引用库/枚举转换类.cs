using System;
using System.Linq;

namespace 阴阳易演.引用库
{
    public static class 枚举转换类<T> where T : struct
    {
        #region 内部处理

        static string[] GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        static TValue[] GetValues<TValue>()
        {
            return (TValue[])Enum.GetValues(typeof(T));
        }

        static int Count()
        {
            return GetNames().Length;
        }

        static bool Contains(string name)
        {
            return GetNames().Contains(name);
        }

        static bool Contains<TValue>(TValue value)
        {
            return GetValues<TValue>().Contains(value);
        }

        static TValue ToObject<TKey, TValue>(TKey key)
        {
            return (TValue)Enum.ToObject(typeof(T), key);
        }

        static TValue Parse<TValue>(string name)
        {
            if (Contains(name))
            {
                return (TValue)Enum.Parse(typeof(T), name, true);
            }
            throw new Exception($"枚举[{typeof(T).Name}]不包含名称{name}");
        }

        static int GetIndex(int num)
        {
            if (Contains(num)) return num;
            // 在取余后判断是否包含数值
            var count = Count();
            var mod = num % count;
            var index = mod < 0 ? count + mod : mod;
            if (Contains(index)) return index;
            // 取余后依然不存在直接报错
            throw new Exception($"枚举[{typeof(T).Name}]不包含数值{num}");
        }

        #endregion

        public static int 获取枚举总数()
        {
            return Count();
        }

        public static T[] 获取所有枚举()
        {
            return GetValues<T>();
        }

        public static string[] 获取所有名称()
        {
            return GetNames();
        }

        public static string 获取名称(int num)
        {
            var index = GetIndex(num);
            return Enum.GetName(typeof(T), index);
        }

        public static string 获取名称(T obj)
        {
            return Enum.GetName(typeof(T), obj);
        }

        public static int 获取序数(T obj)
        {
            return ToObject<T, int>(obj);
        }

        public static int 获取序数(string name)
        {
            return Parse<int>(name);
        }

        public static T 获取枚举(int num)
        {
            var index = GetIndex(num);
            return ToObject<int, T>(index);
        }

        public static T 获取枚举(string name)
        {
            return Parse<T>(name);
        }

        public static bool 尝试获取枚举(string name, out T obj)
        {
            return Enum.TryParse(name, out obj);
        }

        public static bool 包含(string name)
        {
            return Contains(name);
        }

    }
}