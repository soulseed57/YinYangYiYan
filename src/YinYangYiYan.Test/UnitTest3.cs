namespace YinYangYiYan.Test
{
    using System;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 阴阳易演.引用库;
    using 阴阳易演.查询类;
    using 阴阳易演.计算类;

    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void 甲子枚举转换()
        {
            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取名称(0) == "甲子");
            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取名称(3) == "丁卯");

            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取枚举("甲子") == 甲子表.甲子枚举.甲子);
            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取枚举("丁卯") == 甲子表.甲子枚举.丁卯);
            Assert.IsFalse(枚举转换类<甲子表.甲子枚举>.获取枚举("丁卯") == 甲子表.甲子枚举.甲子);

            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取枚举(0) == 甲子表.甲子枚举.甲子);
            Assert.IsTrue(枚举转换类<甲子表.甲子枚举>.获取枚举(3) == 甲子表.甲子枚举.丁卯);
            Assert.IsFalse(枚举转换类<甲子表.甲子枚举>.获取枚举(1) == 甲子表.甲子枚举.甲子);
        }

        [TestMethod]
        public void 干支纪年()
        {
            var date = DateTime.Now;
            var 纪年 = new 干支纪年(date);
            Console.WriteLine($"时间:{date:yyyy年 MM月 dd日 HH时}");
            Console.WriteLine($"{纪年.年柱.名称}年 {纪年.月柱.名称}月 {纪年.日柱.名称}日 {纪年.时柱.名称}时");
            Console.WriteLine($"旬空:{纪年.旬空[0].名称}{纪年.旬空[1].名称}空");
            Console.WriteLine();

            date = new DateTime(1904, 1, 30);
            纪年 = new 干支纪年(date);
            Console.WriteLine($"时间:{date:yyyy年 MM月 dd日 HH时}");
            Console.WriteLine($"{纪年.年柱.名称}年 {纪年.月柱.名称}月 {纪年.日柱.名称}日 {纪年.时柱.名称}时");
            Console.WriteLine($"旬空:{纪年.旬空[0].名称}{纪年.旬空[1].名称}空");
            Console.WriteLine();

            date = new DateTime(1904, 1, 31);
            纪年 = new 干支纪年(date);
            Console.WriteLine($"时间:{date:yyyy年 MM月 dd日 HH时}");
            Console.WriteLine($"{纪年.年柱.名称}年 {纪年.月柱.名称}月 {纪年.日柱.名称}日 {纪年.时柱.名称}时");
            Console.WriteLine($"旬空:{纪年.旬空[0].名称}{纪年.旬空[1].名称}空");
            Console.WriteLine(二十四节气.节气查询(new DateTime(2000, 4, 3)));
            
        }

        [TestMethod]
        public void 逆序甲子表()
        {
            var count = 0;
            for (var i = 0; i > -120; i--)
            {
                var 序数 = 常用方法.序数取余(i, 60);
                Console.Write(甲子表.甲子查询(i).名称);
                Console.Write($"{序数}\t");
                if (++count % 10 == 0) Console.WriteLine();
            }
        }

        [TestMethod]
        public void 正序甲子表()
        {
            var count = 0;
            for (var i = 0; i < 120; i++)
            {
                var 序数 = 常用方法.序数取余(i, 60);
                Console.Write(甲子表.甲子查询(i).名称);
                Console.Write($"{序数}\t");
                if (++count % 10 == 0) Console.WriteLine();
            }
        }

    }
}
