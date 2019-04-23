namespace 阴阳易演.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 容器类;
    using 抽象类;

    [TestClass]
    public class 六十四卦测试
    {
        #region 便捷测试
        static void 卦类测试(八卦 上, 八卦 下, string 测试卦名, string 测试卦象名)
        {
            var 卦 = new 六十四卦(上, 下);
            Console.WriteLine($"上{卦.客卦.名称}下{卦.主卦.名称}");
            Console.WriteLine($"卦名:\t{卦.卦名}");
            Console.WriteLine($"卦象名:\t{卦.卦象名}");
            Assert.IsTrue(卦.客卦.名称 == 上.名称);
            Assert.IsTrue(卦.主卦.名称 == 下.名称);
            Assert.IsTrue(卦.卦名 == 测试卦名);
            Assert.IsTrue(卦.卦象名 == 测试卦象名);
            Console.WriteLine($"-----------------------------");
        }

        static void 爻值测试(八卦 上, 八卦 下, string 测试卦名, string 测试爻序)
        {
            var 卦 = new 六十四卦(上, 下);
            var 爻序 = 六十四卦.还原爻序(卦.爻值);
            Assert.IsTrue(卦.卦名 == 测试卦名);
            Assert.IsTrue(爻序 == 测试爻序);
            Console.WriteLine($"卦名:{卦.卦象名}");
            foreach (var 爻 in 爻序.Reverse())
            {
                switch (爻)
                {
                    case '0':
                        Console.WriteLine("----   ----");
                        break;
                    case '1':
                        Console.WriteLine("----------");
                        break;
                }
            }
            Console.WriteLine();
        }

        #endregion

        [TestMethod]
        public void 卦名测试()
        {
            Assert.IsTrue(六十四卦.查询卦名(八卦.坤, 八卦.震) == "复");
            Assert.IsTrue(六十四卦.查询卦名(八卦.震, 八卦.巽) == "恒");
            Assert.IsTrue(六十四卦.查询卦名(八卦.离, 八卦.坤) == "晋");
            Assert.IsTrue(六十四卦.查询卦名(八卦.乾, 八卦.艮) == "遁");
        }

        [TestMethod]
        public void 类型测试()
        {
            Console.WriteLine("----------上下同卦----------");
            卦类测试(八卦.乾, 八卦.乾, "乾", "乾为天");
            卦类测试(八卦.坤, 八卦.坤, "坤", "坤为地");
            卦类测试(八卦.艮, 八卦.艮, "艮", "艮为山");
            卦类测试(八卦.兑, 八卦.兑, "兑", "兑为泽");
            Console.WriteLine();
            Console.WriteLine("----------上下不同----------");
            卦类测试(八卦.坤, 八卦.乾, "泰", "地天泰");
            卦类测试(八卦.离, 八卦.兑, "睽", "火泽睽");
            卦类测试(八卦.坤, 八卦.震, "复", "地雷复");
            卦类测试(八卦.艮, 八卦.乾, "大畜", "山天大畜");
        }

        [TestMethod]
        public void 卦值测试()
        {
            爻值测试(八卦.离, 八卦.乾, "大有", "111101");
            爻值测试(八卦.坎, 八卦.震, "屯", "100010");
            爻值测试(八卦.震, 八卦.兑, "归妹", "110100");
            爻值测试(八卦.震, 八卦.乾, "大壮", "111100");
        }
    }
}