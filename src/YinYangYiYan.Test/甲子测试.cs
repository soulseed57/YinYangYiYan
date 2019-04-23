namespace 阴阳易演.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 枚举类;
    using 查询类;

    [TestClass]
    public class 甲子测试
    {
        #region 便捷测试
        static void 长生和配卦(甲子 甲, 长生枚举 长生, 八卦 上卦, 八卦 下卦)
        {
            Console.WriteLine($"名称:\t{甲.名称}");
            Console.WriteLine($"阴阳:\t{甲.阴阳.名称}");
            Console.WriteLine($"纳音:\t{甲.纳音.名称}");
            Console.WriteLine($"长生:\t{甲.十二长生}");
            Console.WriteLine($"配卦:\t{甲.天干配卦.名称}上{甲.地支配卦.名称}下");
            Console.WriteLine("------------------------------");
            Assert.IsTrue(甲.十二长生 == 长生);
            Assert.IsTrue(甲.天干配卦 == 上卦 && 甲.地支配卦 == 下卦);
        }

        #endregion

        [TestMethod]
        public void 甲子数()
        {
            var showMsg = new StringBuilder();
            var all = 枚举转换类<甲子枚举>.获取所有枚举();

            showMsg.AppendLine("枚举序数转换测试");
            foreach (var 枚举 in all)
            {
                var 序数 = 枚举转换类<甲子枚举>.获取序数(枚举);
                showMsg.Append($"{枚举}[{序数:D2}]\t");
                if (序数 % 10 == 0)
                {
                    showMsg.AppendLine();
                }
            }
            showMsg.AppendLine();

            showMsg.AppendLine("序数转甲子测试");
            foreach (var 枚举 in all)
            {
                var 序数 = 枚举转换类<甲子枚举>.获取序数(枚举);
                var 甲数 = new 甲子(序数);
                showMsg.Append($"{甲数.名称}[{甲数.序数:D2}]\t");
                if (序数 % 10 == 0)
                {
                    showMsg.AppendLine();
                }
            }
            showMsg.AppendLine();

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 甲子阴阳测试()
        {
            var cnt = 枚举转换类<甲子枚举>.获取枚举总数();
            for (var i = 0; i < cnt; i++)
            {
                var 枚 = 枚举转换类<甲子枚举>.获取名称(i);
                var 甲子 = new 甲子(枚);
                Assert.IsTrue(甲子.天干.阴阳 == 甲子.地支.阴阳);
            }
        }

        [TestMethod]
        public void 甲子枚举转换()
        {
            Assert.IsTrue(枚举转换类<甲子枚举>.获取名称(0) == "甲子");
            Assert.IsTrue(枚举转换类<甲子枚举>.获取名称(3) == "丁卯");

            Assert.IsTrue(枚举转换类<甲子枚举>.获取枚举("甲子") == 甲子枚举.甲子);
            Assert.IsTrue(枚举转换类<甲子枚举>.获取枚举("丁卯") == 甲子枚举.丁卯);
            Assert.IsFalse(枚举转换类<甲子枚举>.获取枚举("丁卯") == 甲子枚举.甲子);

            Assert.IsTrue(枚举转换类<甲子枚举>.获取枚举(0) == 甲子枚举.甲子);
            Assert.IsTrue(枚举转换类<甲子枚举>.获取枚举(3) == 甲子枚举.丁卯);
            Assert.IsFalse(枚举转换类<甲子枚举>.获取枚举(1) == 甲子枚举.甲子);
        }

        [TestMethod]
        public void 逆序甲子表()
        {
            var count = 0;
            for (var i = 0; i > -120; i--)
            {
                var 序数 = 常用方法.序数取余(i, 60);
                Console.Write(new 甲子(i).名称);
                Console.Write($"{序数}\t");
                if (++count % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        [TestMethod]
        public void 正序甲子表()
        {
            var count = 0;
            for (var i = 0; i < 120; i++)
            {
                var 序数 = 常用方法.序数取余(i, 60);
                Console.Write(new 甲子(i).名称);
                Console.Write($"{序数}\t");
                if (++count % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        [TestMethod]
        public void 长生查询()
        {
            Assert.IsTrue(十二长生表.长生查询(天干.甲, 地支.亥) == 长生枚举.长生);
            Assert.IsTrue(十二长生表.长生查询(天干.辛, 地支.寅) == 长生枚举.胎);
            Assert.IsTrue(十二长生表.长生查询(天干.丙, 地支.申) == 长生枚举.病);
            Assert.IsTrue(十二长生表.长生查询(天干.辛, 地支.酉) == 长生枚举.临官);
            Assert.IsTrue(十二长生表.长生查询(天干.壬, 地支.子) == 长生枚举.帝旺);
        }

        [TestMethod]
        public void 甲子配卦测试()
        {
            长生和配卦(new 甲子("甲午"), 长生枚举.死, 八卦.乾, 八卦.离);
            长生和配卦(new 甲子("辛卯"), 长生枚举.绝, 八卦.巽, 八卦.震);
            长生和配卦(new 甲子("癸巳"), 长生枚举.胎, 八卦.坤, 八卦.巽);
            长生和配卦(new 甲子("丁巳"), 长生枚举.帝旺, 八卦.兑, 八卦.巽);
        }

        [TestMethod]
        public void 六十甲子()
        {
            var showMsg = new StringBuilder();
            var 天干表 = new List<天干> { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
            var 地支表 = new List<地支> { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };
            for (var i = 0; i < 60; i++)
            {
                var 干 = 天干表[i % 天干表.Count];
                var 支 = 地支表[i % 地支表.Count];
                var 甲子 = new 甲子(干, 支);
                showMsg.Append($"{甲子.名称}{甲子.序数:D2}\t");
                if ((i + 1) % 10 == 0)
                {
                    showMsg.Append("\r\n");
                }
            }
            Console.Write(showMsg.ToString());
        }

    }
}
