namespace 阴阳易演.模型测试
{
    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 容器类;
    using 抽象类;
    using 枚举类;
    using 计算类;

    [TestClass]
    public class 干支测试
    {
        [TestMethod]
        public void 天干阴阳()
        {
            var showMsg = new StringBuilder();
            var 天干表 = new 天干[] { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
            foreach (var 干 in 天干表)
            {
                showMsg.Append($"{干.五行.名称} ");
                showMsg.Append($"{干.阴阳.名称}\t");
            }
            showMsg.AppendLine();

            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 十二长生()
        {
            var showMsg = new StringBuilder();
            天干 g = 天干.甲;
            地支 z = 地支.子;
            Console.WriteLine($"{g.名称}在{z.名称} {g.在地支的长生(z)}");
            g = 天干.乙;
            z = 地支.午;
            Console.WriteLine($"{g.名称}在{z.名称} {g.在地支的长生(z)}");

            var 天干表 = new 天干[] { 天干.甲, 天干.乙, 天干.丙, 天干.丁, 天干.戊, 天干.己, 天干.庚, 天干.辛, 天干.壬, 天干.癸 };
            var 地支表 = new 地支[] { 地支.子, 地支.丑, 地支.寅, 地支.卯, 地支.辰, 地支.巳, 地支.午, 地支.未, 地支.申, 地支.酉, 地支.戌, 地支.亥 };
            for (var i = 0; i < 60; i++)
            {
                var 干 = 天干表[i % 天干表.Length];
                var 支 = 地支表[i % 地支表.Length];
                showMsg.Append($"{干.名称}在{支.名称}:{干.在地支的长生(支)}\t");
                if ((i + 1) % 10 == 0)
                {
                    showMsg.Append("\r\n");
                }
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 合化测试()
        {
            天干 干 = 天干.甲;
            var 合 = 干.合();
            var 化 = 干.化(合);
            Console.WriteLine($"{干.名称}{合.名称}合化{化.名称}");

            干 = 天干.乙;
            合 = 干.合();
            化 = 干.化(合);
            Console.WriteLine($"{干.名称}{合.名称}合化{化.名称}");
        }

        [TestMethod]
        public void 地支藏干()
        {
            var 支 = 地支.子;
            Assert.IsTrue(支.藏干().余气 == null);
            Assert.IsTrue(支.藏干().中气 == null);
            Assert.IsTrue(支.藏干().本气 == "癸");
            Assert.IsTrue(支.藏干().藏干.Length == 1);

            var 藏 = 地支.丑.藏干();
            Assert.IsTrue(藏.余气 == "癸");
            Assert.IsTrue(藏.中气 == "辛");
            Assert.IsTrue(藏.本气 == "己");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.寅);
            Assert.IsTrue(藏.余气 == "戊");
            Assert.IsTrue(藏.中气 == "丙");
            Assert.IsTrue(藏.本气 == "甲");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.卯);
            Assert.IsTrue(藏.余气 == null);
            Assert.IsTrue(藏.中气 == null);
            Assert.IsTrue(藏.本气 == "乙");
            Assert.IsTrue(藏.藏干.Length == 1);

            藏 = new 地支藏干(地支.辰);
            Assert.IsTrue(藏.余气 == "乙");
            Assert.IsTrue(藏.中气 == "癸");
            Assert.IsTrue(藏.本气 == "戊");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.巳);
            Assert.IsTrue(藏.余气 == "戊");
            Assert.IsTrue(藏.中气 == "庚");
            Assert.IsTrue(藏.本气 == "丙");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.午);
            Assert.IsTrue(藏.余气 == null);
            Assert.IsTrue(藏.中气 == "己");
            Assert.IsTrue(藏.本气 == "丁");
            Assert.IsTrue(藏.藏干.Length == 2);

            藏 = new 地支藏干(地支.未);
            Assert.IsTrue(藏.余气 == "丁");
            Assert.IsTrue(藏.中气 == "乙");
            Assert.IsTrue(藏.本气 == "己");
            Assert.IsTrue(藏.藏干.Length == 3);

            Console.WriteLine($"地支未藏干:");
            foreach (var 干 in 藏.藏干)
            {
                Console.Write(干.名称 + "\t");
            }
            Console.WriteLine();

            藏 = new 地支藏干(地支.申);
            Assert.IsTrue(藏.余气 == "戊");
            Assert.IsTrue(藏.中气 == "壬");
            Assert.IsTrue(藏.本气 == "庚");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.酉);
            Assert.IsTrue(藏.余气 == null);
            Assert.IsTrue(藏.中气 == null);
            Assert.IsTrue(藏.本气 == "辛");
            Assert.IsTrue(藏.藏干.Length == 1);

            藏 = new 地支藏干(地支.戌);
            Assert.IsTrue(藏.余气 == "辛");
            Assert.IsTrue(藏.中气 == "丁");
            Assert.IsTrue(藏.本气 == "戊");
            Assert.IsTrue(藏.藏干.Length == 3);

            藏 = new 地支藏干(地支.亥);
            Assert.IsTrue(藏.余气 == null);
            Assert.IsTrue(藏.中气 == "甲");
            Assert.IsTrue(藏.本气 == "壬");
            Assert.IsTrue(藏.藏干.Length == 2);

            Console.WriteLine($"地支亥藏干:");
            foreach (var 干 in 藏.藏干)
            {
                Console.Write(干.名称 + "\t");
            }
            Console.WriteLine();
        }

        [TestMethod]
        public void 天干六亲()
        {
            // 判定测试
            Assert.IsTrue(天干.甲.的正印是(天干.癸));
            Assert.IsTrue(天干.乙.的正官是(天干.庚));
            Assert.IsTrue(天干.戊.的正官是(天干.乙));
            Assert.IsFalse(天干.庚.的正印是(天干.丁));
            Assert.IsTrue(天干.壬.的伤官是(天干.乙));
            // 对象测试
            Assert.IsTrue(天干.甲.正官() == 天干.辛);
            Assert.IsTrue(天干.乙.正印() == 天干.壬);
            // 关系测试
            Assert.IsTrue(天干.甲.的正官六亲(性别枚举.男).Contains("女儿"));
            Assert.IsTrue(天干.乙.的偏官六亲(性别枚举.女).Contains("儿媳"));

            var 十神 = new 十神(天干.己, 天干.乙);
            Assert.IsTrue(十神.枚举 == 十神枚举.偏官);
        }

        #region 三合计算
        static void 三合局计算(地支[] 地支组, 五行 判定合局)
        {
            var res = false;
            foreach (var 合局 in 三合计算.地支三合(地支组))
            {
                if (合局 == 判定合局)
                {
                    res = true;
                    Console.WriteLine($"三合{合局.名称}局");
                    break;
                }
            }
            Assert.IsTrue(res);
        }

        #endregion

        [TestMethod]
        public void 三合测试()
        {
            // 计算测试
            var 测试组合 = new 地支[] { 地支.申, 地支.子, 地支.辰, 地支.亥, 地支.卯, 地支.未 };
            三合局计算(测试组合, 五行.水);
            三合局计算(测试组合, 五行.木);
            // 扩展测试
            Assert.IsFalse(地支.子.是三合水局(地支.亥, 地支.卯));
            Assert.IsFalse(地支.丑.是三合金局(地支.酉, 地支.丑));
            Assert.IsTrue(地支.卯.是三合木局(地支.亥, 地支.未));
            Assert.IsTrue(地支.午.是三合火局(地支.寅, 地支.戌));

            Assert.IsTrue(地支.子.三合局(地支.丑, 地支.未).Length == 0);
            Assert.IsTrue(地支.戌.三合局(地支.寅, 地支.午).Contains(五行.火));
            Assert.IsTrue(地支.卯.三合局(地支.未, 地支.亥).Contains(五行.木));


        }

    }
}
