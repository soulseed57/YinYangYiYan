using System;
using System.Linq;

namespace 阴阳易演.引用库
{
    public static class 枚举转换类<T> where T : struct
    {
        public static int 获取枚举总数()
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static T[] 获取所有枚举()
        {
            return (T[])Enum.GetValues(typeof(T));
        }

        public static string[] 获取所有名称()
        {
            return Enum.GetNames(typeof(T));
        }

        public static string 获取名称(int 原数)
        {
            var 枚举 = 获取枚举(原数);
            return 获取名称(枚举);
        }

        public static string 获取名称(T 枚举)
        {
            return Enum.GetName(typeof(T), 枚举);
        }

        public static int 获取序数(string 名称)
        {
            var 枚举 = 获取枚举(名称);
            return 获取序数(枚举);
        }

        public static int 获取序数(T 枚举)
        {
            var 对象 = Enum.ToObject(typeof(T), 枚举);
            var 原数 = (int)对象;
            if (包含(枚举))
            {
                return 原数;
            }
            var 进位数 = 获取枚举总数();
            var 余数 = 原数 % 进位数;
            var 序数 = 余数 < 0 ? 进位数 + 余数 : 余数;
            return 序数;
        }

        public static T 获取枚举(string 名称)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), 名称, true);
            }
            catch
            {
                throw new Exception($"枚举[{typeof(T).Name}]不包含名称{名称}");
            }
        }

        public static T 获取枚举(int 原数)
        {
            var 序数 = 原数;
            if (!包含(原数))
            {
                var 进位数 = 获取枚举总数();
                var 余数 = 原数 % 进位数;
                序数 = 余数 < 0 ? 进位数 + 余数 : 余数;
            }
            return (T)Enum.ToObject(typeof(T), 序数);
        }

        public static bool 尝试获取枚举(string 名称, out T 枚举)
        {
            return Enum.TryParse(名称, out 枚举);
        }

        public static bool 包含(int 原数)
        {
            return 获取所有枚举().Any(t => (int)Enum.ToObject(typeof(T), t) == 原数);
        }

        public static bool 包含(T 枚举)
        {
            var 名称 = 获取名称(枚举);
            return 包含(名称);
        }

        public static bool 包含(string 名称)
        {
            return 获取所有名称().Contains(名称);
        }

    }
}