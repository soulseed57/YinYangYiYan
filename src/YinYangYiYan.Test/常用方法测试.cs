﻿namespace 阴阳易演.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using 引用库;
    using 抽象类;
    using 抽象类.基类;

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


    }
}
