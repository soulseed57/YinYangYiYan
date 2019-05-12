namespace 阴阳易演.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using 引用库;
    using 抽象类;
    using 抽象类.基类;
    using 枚举类;

    [TestClass]
    public class 常用方法测试
    {
        [TestMethod]
        public void 顺逆排序()
        {
            var arr = new[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            Console.WriteLine("顺序排列");
            var ord = 常用方法.列表顺逆排序(true, arr);
            var ans = 常用方法.列表顺逆排序(false, arr);
            for (var i = 0; i < ord.Length; i++)
            {
                var num = ord[i];
                Console.Write($"{num} ");
                if (i == arr.Length - 1)
                {
                    Assert.IsTrue(num == 4);
                }
            }
            Console.WriteLine();

            Console.WriteLine("逆序排列");
            for (var i = 0; i < ans.Length; i++)
            {
                var num = ans[i];
                Console.Write($"{num} ");
                if (i == arr.Length - 1)
                {
                    Assert.IsTrue(num == 6);
                }
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void 指定首位()
        {
            var arr1 = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int first;
            Console.WriteLine("原序列");
            foreach (var num in arr1)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine("首位:" + (first = 2));
            var arr2 = 常用方法.列表指定首位(arr1, first);
            for (var i = 0; i < arr2.Length; i++)
            {
                var num = arr2[i];
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine("首位:" + (first = 0));
            arr2 = 常用方法.列表指定首位(arr1, first);
            for (var i = 0; i < arr2.Length; i++)
            {
                var num = arr2[i];
                Console.Write($"{num} ");
                if (i == 2)
                {
                    Assert.IsTrue(num == 2);
                }
            }
            Console.WriteLine();

            Console.WriteLine("首位:" + (first = -1));
            arr2 = 常用方法.列表指定首位(arr1, first);
            for (var i = 0; i < arr2.Length; i++)
            {
                var num = arr2[i];
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine("首位:" + (first = -3));
            arr2 = 常用方法.列表指定首位(arr1, first);
            for (var i = 0; i < arr2.Length; i++)
            {
                var num = arr2[i];
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine($"首位:{first = -335}={first % arr1.Length}");
            arr2 = 常用方法.列表指定首位(arr1, first);
            for (var i = 0; i < arr2.Length; i++)
            {
                var num = arr2[i];
                Console.Write($"{num} ");
                if (i == 2)
                {
                    Assert.IsTrue(num == 7);
                }
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void 同时包含测试()
        {
            // 运算符测试
            var res = 天干.甲 == 地支.子;

            Assert.IsTrue(常用方法.同时包含(new 干支[] { 天干.甲, 天干.丙, 天干.丁, 地支.子, 地支.申 }, 天干.甲, 天干.丙));
            Assert.IsFalse(常用方法.同时包含(new 天干[] { 天干.甲, 天干.丙, 天干.丁 }, 天干.甲, 天干.乙, 天干.丁));
            Assert.IsTrue(常用方法.同时包含(new 天干[] { 天干.甲, 天干.丁 }, 天干.甲, 天干.丁));
            Assert.IsTrue(常用方法.同时包含(new 干支[] { 天干.甲, 地支.子 }, 天干.甲, 地支.子));
        }

        [TestMethod]
        public void 序数取余()
        {
            Assert.IsTrue(常用方法.序数取余(0, 24) == 0);
            Assert.IsTrue(常用方法.序数取余(-1, 24) == 23);
            Assert.IsTrue(常用方法.序数取余(-23, 24) == 1);
            Assert.IsTrue(常用方法.序数取余(-24, 24) == 0);
            Assert.IsTrue(常用方法.序数取余(-25, 24) == 23);
            Assert.IsTrue(常用方法.序数取余(47, 24) == 23);
            Assert.IsTrue(常用方法.序数取余(48, 24) == 0);
            Assert.IsTrue(常用方法.序数取余(49, 24) == 1);
        }

        [TestMethod]
        public void 枚举转换测试()
        {
            // 获取枚举总数
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举总数() == 8);
            Assert.IsTrue(枚举转换类<节气节令>.获取枚举总数() == 24);
            Assert.IsTrue(枚举转换类<甲子枚举>.获取枚举总数() == 60);

            // 获取所有枚举
            Assert.IsTrue(枚举转换类<八卦枚举>.获取所有枚举().Length == 8 && 枚举转换类<八卦枚举>.获取所有枚举()[0].GetType() == typeof(八卦枚举));

            // 获取所有名称
            Assert.IsTrue(枚举转换类<甲子枚举>.获取所有名称().Contains("庚子"));
            Assert.IsTrue(枚举转换类<八卦枚举>.获取所有名称().Contains("震"));
            Assert.IsFalse(枚举转换类<八卦枚举>.获取所有名称().Contains("庚子"));
            Assert.IsFalse(枚举转换类<甲子枚举>.获取所有名称().Contains("震"));

            // 获取名称
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(3) == "震");
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(9) == "兑");
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(-1) == "坤");
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(-9) == "坤");
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(八卦枚举.坎) == "坎");
            Assert.IsTrue(枚举转换类<八卦枚举>.获取名称(八卦枚举.离) == "离");

            // 获取序数
            Assert.IsTrue(枚举转换类<八卦枚举>.获取序数("坎") == 5);
            Assert.ThrowsException<Exception>(delegate
            {
                枚举转换类<八卦枚举>.获取序数("甲子");
            });
            Assert.IsTrue(枚举转换类<八卦枚举>.获取序数(八卦枚举.巽) == 4);

            // 获取枚举
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举("坎") == 八卦枚举.坎);
            Assert.ThrowsException<Exception>(delegate
            {
                枚举转换类<八卦枚举>.获取枚举("甲子");
            });
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举(2) == 八卦枚举.离);
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举(12) == 八卦枚举.巽);
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举(-1) == 八卦枚举.坤);
            Assert.IsTrue(枚举转换类<八卦枚举>.获取枚举(-16) == 八卦枚举.乾);

            // 尝试获取枚举
            Assert.IsTrue(枚举转换类<八卦枚举>.尝试获取枚举("坎", out var 枚) && 枚 == 八卦枚举.坎);
            Assert.IsFalse(枚举转换类<八卦枚举>.尝试获取枚举("甲子", out var _));

        }
    }
}
