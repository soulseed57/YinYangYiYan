namespace 阴阳易演.测试
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 抽象类;
    using 枚举类;
    using 计算类;

    [TestClass]
    public class 八卦测试
    {
        [TestMethod]
        public void 爻值测试()
        {
            Assert.IsTrue(两仪.阳.值 == 1);
            Assert.IsTrue(两仪.阴.值 == 0);

            Assert.IsTrue(四象.太阳.爻值 == 3);
            Assert.IsTrue(四象.少阳.爻值 == 2);
            Assert.IsTrue(四象.少阴.爻值 == 1);
            Assert.IsTrue(四象.太阴.爻值 == 0);

            Assert.IsTrue(八卦计算.还原爻序(八卦.兑.爻值, 3) == "110");
            Assert.IsTrue(八卦计算.还原爻序(八卦.巽.爻值, 3) == "011");
            Assert.IsTrue(八卦计算.还原爻序(八卦.艮.爻值, 3) == "001");
            Assert.IsTrue(八卦计算.还原爻序(八卦.震.爻值, 3) == "100");

            Console.WriteLine($"{两仪.阳.名称}\t{八卦计算.还原爻序(两仪.阳.值, 1)}");
            Console.WriteLine($"{四象.太阳.名称}\t{八卦计算.还原爻序(四象.太阳.爻值, 2)}");
            Console.WriteLine($"{八卦.乾.名称}\t{八卦计算.还原爻序(八卦.乾.爻值, 3)}");
            Console.WriteLine($"{八卦.兑.名称}\t{八卦计算.还原爻序(八卦.兑.爻值, 3)}");
            Console.WriteLine();
            Console.WriteLine($"{两仪.阳.名称}\t{八卦计算.还原爻序(两仪.阳.值, 1)}");
            Console.WriteLine($"{四象.少阴.名称}\t{八卦计算.还原爻序(四象.少阴.爻值, 2)}");
            Console.WriteLine($"{八卦.离.名称}\t{八卦计算.还原爻序(八卦.离.爻值, 3)}");
            Console.WriteLine($"{八卦.震.名称}\t{八卦计算.还原爻序(八卦.震.爻值, 3)}");
            Console.WriteLine();
            Console.WriteLine($"{两仪.阴.名称}\t{八卦计算.还原爻序(两仪.阴.值, 1)}");
            Console.WriteLine($"{四象.少阳.名称}\t{八卦计算.还原爻序(四象.少阳.爻值, 2)}");
            Console.WriteLine($"{八卦.巽.名称}\t{八卦计算.还原爻序(八卦.巽.爻值, 3)}");
            Console.WriteLine($"{八卦.坎.名称}\t{八卦计算.还原爻序(八卦.坎.爻值, 3)}");
            Console.WriteLine();
            Console.WriteLine($"{两仪.阴.名称}\t{八卦计算.还原爻序(两仪.阴.值, 1)}");
            Console.WriteLine($"{四象.太阴.名称}\t{八卦计算.还原爻序(四象.太阴.爻值, 2)}");
            Console.WriteLine($"{八卦.艮.名称}\t{八卦计算.还原爻序(八卦.艮.爻值, 3)}");
            Console.WriteLine($"{八卦.坤.名称}\t{八卦计算.还原爻序(八卦.坤.爻值, 3)}");
            Console.WriteLine();
        }

        [TestMethod]
        public void 方位测试()
        {
            var 卦列 = new 八卦[] { 八卦.乾, 八卦.兑, 八卦.离, 八卦.震, 八卦.巽, 八卦.坎, 八卦.艮, 八卦.坤 };

            Assert.IsTrue(八卦.巽.方位 == 八方方位.东南);
            Assert.IsTrue(八卦.坎.方位 == 八方方位.正北);

            Console.WriteLine();

            foreach (var 卦 in 卦列)
            {
                Console.Write(卦.方位 + " ");
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void 卦数测试()
        {
            Assert.IsTrue(八卦.震.先天数 == 4);
            Assert.IsTrue(八卦.震.后天数 == 3);
            Assert.IsTrue(八卦.巽.先天数 == 5);
            Assert.IsTrue(八卦.巽.后天数 == 4);

            Assert.IsTrue(八卦.兑.先天数 == 2);
            Assert.IsTrue(八卦.坎.先天数 == 6);

            Assert.IsTrue(八卦.乾.后天数 == 6);
            Assert.IsTrue(八卦.艮.后天数 == 8);
        }

        [TestMethod]
        public void 卦序测试()
        {
            八卦[] 卦列 = { 八卦.乾, 八卦.兑, 八卦.离, 八卦.震, 八卦.巽, 八卦.坎, 八卦.艮, 八卦.坤 };

            foreach (var 卦 in 卦列.OrderBy(t => t.先天数))
            {
                Console.Write(卦.名称 + " ");
            }
            Console.WriteLine();

            foreach (var 卦 in 卦列.OrderBy(t => t.后天数))
            {
                Console.Write(卦.名称 + " ");
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void 八卦计算测试()
        {
            八卦 卦;

            卦 = 两仪.阳 + 四象.太阳;
            Assert.IsTrue(卦.名称 == "乾");
            卦 = 四象.太阳 + 两仪.阴;
            Assert.IsTrue(卦.名称 == "兑");

            卦 = 两仪.阳 + 四象.少阴;
            Assert.IsTrue(卦.名称 == "离");
            卦 = 四象.少阴 + 两仪.阴;
            Assert.IsTrue(卦.名称 == "震");

            卦 = 两仪.阳 + 四象.少阳;
            Assert.IsTrue(卦.名称 == "巽");
            卦 = 四象.少阳 + 两仪.阴;
            Assert.IsTrue(卦.名称 == "坎");

            卦 = 两仪.阳 + 四象.太阴;
            Assert.IsTrue(卦.名称 == "艮");
            卦 = 四象.太阴 + 两仪.阴;
            Assert.IsTrue(卦.名称 == "坤");
        }

        [TestMethod]
        public void 八节旺衰测试()
        {
            Assert.IsTrue(八卦.巽.八节旺衰(节气节令.立夏) == 八卦八节旺衰.旺);
            Assert.IsTrue(八卦.坤.八节旺衰(八卦八节旺衰.囚) == 节气节令.冬至);
            Assert.IsTrue(八卦.兑.八节旺衰(节气节令.立夏) == 八卦八节旺衰.没);
            Assert.IsTrue(八卦.震.八节旺衰(节气节令.立春) == 八卦八节旺衰.相);
            Assert.IsTrue(八卦.坎.八节旺衰(八卦八节旺衰.胎) == 节气节令.秋分);
        }
    }
}
