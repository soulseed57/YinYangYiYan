namespace YinYangYiYan.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 阴阳易演.引用库;
    using 阴阳易演.抽象类;
    using 阴阳易演.查询类;
    using 阴阳易演.计算类;

    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void 河图数()
        {
            for (var i = 0; i < 50; i++)
            {
                var 河图 = new 河图(i);
                Console.Write($"河图数:{河图.河图数:D2}\t{常用方法.获取类名(河图.阴阳)}{常用方法.获取类名(河图.五行)}\t");
                foreach (var 地支 in 河图.地支)
                {
                    Console.Write($"{常用方法.获取类名(地支)}");
                }
                Console.WriteLine();
            }

        }

        [TestMethod]
        public void 时干时支()
        {
            var 干支纪年 = new 干支纪年(DateTime.Now);
            var 日干 = 干支表.天干查询(干支纪年.日柱.天干.名称);
            var 时支 = 干支纪年.时辰.名称;
            Console.WriteLine(干支纪年.日柱.天干.名称);
            Console.WriteLine(时支);
            //var 时干 = 日干 * 2 + 时支;
            Console.WriteLine();
        }

        [TestMethod]
        public void 名称测试()
        {
            Console.WriteLine(八卦.乾.名称);
            Console.WriteLine(地支.子.名称);
            Console.WriteLine(季节.冬季.名称);
            Console.WriteLine(两仪.阴.名称);
            Console.WriteLine(六神.青龙.名称);
            Console.WriteLine(四象.太阳.名称);
            Console.WriteLine(天干.丙.名称);
            Console.WriteLine(五行.水.名称);
        }
    }
}
