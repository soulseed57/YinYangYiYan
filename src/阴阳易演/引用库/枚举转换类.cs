using System;

namespace 阴阳易演.引用库
{
    public static class 枚举转换类<T>
    {
        public static T[] 获取所有枚举()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
        public static string 获取名称(int 序数)
        {
            try
            {
                return Enum.GetName(typeof(T), 序数);
            }
            catch (Exception e)
            {
                throw new Exception($"使用序数[{序数}]获取名称{typeof(T)}失败:{e.Message}");
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
                throw new Exception($"使用枚举[{枚举}]获取名称{typeof(T)}失败:{e.Message}");
            }
        }
        public static int 获取序数(string 名称)
        {
            try
            {
                var 枚举 = 获取枚举(名称);
                return (int)Enum.ToObject(typeof(T), 枚举);
            }
            catch (Exception e)
            {
                throw new Exception($"使用名称[{名称}]获取序数{typeof(T)}失败:{e.Message}");
            }
        }
        public static int 获取序数(T 枚举)
        {
            try
            {
                return (int)Enum.ToObject(typeof(T), 枚举);
            }
            catch (Exception e)
            {
                throw new Exception($"使用枚举[{枚举}]获取序数{typeof(T)}失败:{e.Message}");
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
                throw new Exception($"使用名称[{名称}]获取枚举{typeof(T)}失败:{e.Message}");
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
                throw new Exception($"使用序数[{序数}]获取枚举{typeof(T)}失败:{e.Message}");
            }
        }
        public static int 序数取余(int 序数, int 除余数)
        {
            var 算数 = 序数 % 除余数;
            return 算数 < 0 ? 除余数 + 算数 : 算数;
        }
    }
}
