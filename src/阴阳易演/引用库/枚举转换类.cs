namespace 阴阳易演.引用库
{
    using System;

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
        public static string 获取名称(int 序数)
        {
            try
            {
                return Enum.GetName(typeof(T), 序数);
            }
            catch (Exception e)
            {
                throw new Exception($"[{typeof(T).Name}]使用序数[{序数}]获取名称失败:{e.Message}");
            }
        }
        public static string 获取名称(T 枚举)
        {
            try
            {
                return Enum.GetName(typeof(T), 枚举);
            }
            catch (Exception e)
            {
                throw new Exception($"[{typeof(T).Name}]使用枚举[{枚举}]获取名称失败:{e.Message}");
            }
        }
        public static int 获取序数(string 名称)
        {
            var 枚举 = 获取枚举(名称);
            return 获取序数(枚举);
        }
        public static int 获取序数(T 枚举)
        {
            try
            {
                var sum = Enum.GetValues(typeof(T)).Length;
                var obj = Enum.ToObject(typeof(T), 枚举);
                var num = (int)obj % sum;
                return num;
            }
            catch (Exception e)
            {
                throw new Exception($"[{typeof(T).Name}]使用枚举[{枚举}]获取序数失败:{e.Message}");
            }
        }
        public static T 获取枚举(string 名称)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), 名称, true);
            }
            catch (Exception e)
            {
                throw new Exception($"[{typeof(T).Name}]使用名称[{名称}]获取枚举失败:{e.Message}");
            }
        }
        public static T 获取枚举(int 序数)
        {
            try
            {
                return (T)Enum.ToObject(typeof(T), 序数);
            }
            catch (Exception e)
            {
                throw new Exception($"[{typeof(T).Name}]使用序数[{序数}]获取枚举失败:{e.Message}");
            }
        }
        public static bool 尝试获取枚举(string 名称, out T 枚举)
        {
            return Enum.TryParse(名称, out 枚举);
        }
    }
}
