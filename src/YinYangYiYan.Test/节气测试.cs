namespace 阴阳易演.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Text;
    using 容器类;
    using 引用库;
    using 抽象类;
    using 枚举类;

    [TestClass]
    public class 节气测试
    {
        #region 便捷测试
        static void 便捷节气表(DateTime date, 节气节令 测试节气)
        {
            var 节 = new 节气时间(date);
            Assert.IsTrue(节.枚举 == 测试节气);
            Console.WriteLine($"时间: {date:yyyy年MM月dd日}\t节气: {节}");
            Console.WriteLine("--------------------");
        }

        static void 上下节气(DateTime date)
        {
            var j = new 节气(date);
            Assert.IsTrue(j.上一节气时间 < date);
            Assert.IsTrue(j.下一节气时间 > date);
        }

        #endregion

        [TestMethod]
        public void 节气表测试()
        {
            便捷节气表(new DateTime(2018, 12, 23, 0, 0, 0), 节气节令.冬至);

            便捷节气表(new DateTime(2019, 12, 21, 0, 0, 0), 节气节令.大雪);
            便捷节气表(new DateTime(2019, 1, 4, 0, 0, 0), 节气节令.冬至);

            便捷节气表(new DateTime(2019, 1, 5, 21, 0, 0), 节气节令.冬至);
            便捷节气表(new DateTime(2019, 1, 5, 22, 0, 0), 节气节令.小寒);
        }

        [TestMethod]
        public void 四季判断()
        {
            var showMsg = new StringBuilder();
            for (var i = 0; i < 24; i++)
            {
                var 枚 = 枚举转换类<节气节令>.获取枚举(i);
                var 时间 = 节气时间.节气时间查询(2017, 枚);
                var 季节名 = 季节.季节查询(时间).GetType().Name;
                showMsg.AppendLine($"{i}:{时间:MM-dd}\t{季节名}");
            }
            var t = new DateTime(2017, 1, 1);
            var r = new Random();
            var d = r.Next(365);
            var date = t.AddDays(d);
            var season = 季节.季节查询(date).GetType().Name;
            showMsg.AppendLine($"{date:yyyy-MM-dd}\t{season}");

            Console.Write(showMsg.ToString());
        }

        static void 节气查询判断(int 年份, int 索引, int 判定年, int 判定号)
        {
            var 进位数 = 24;
            var 序号 = 常用方法.序数取余(索引, 进位数);
            var 余数 = 索引 % 进位数;
            var 进位 = 索引 < 0 && 余数 == 0 ? 索引 / 进位数 + 1 : 索引 / 进位数;
            var 修正 = 索引 < 0 ? 进位 - 1 : 进位;
            var 查年 = 年份 + 修正;
            Assert.IsTrue(查年 == 判定年 && 序号 == 判定号);
        }

        [TestMethod]
        public void 节气索引()
        {
            节气查询判断(2000, -1, 1999, 23);
            节气查询判断(2000, -23, 1999, 1);
            节气查询判断(2000, -24, 1999, 0);
            节气查询判断(2000, -25, 1998, 23);

            节气查询判断(2000, -47, 1998, 1);
            节气查询判断(2000, -48, 1998, 0);
            节气查询判断(2000, -49, 1997, 23);

            节气查询判断(2000, 23, 2000, 23);
            节气查询判断(2000, 24, 2001, 0);
            节气查询判断(2000, 25, 2001, 1);

            节气查询判断(2000, 47, 2001, 23);
            节气查询判断(2000, 48, 2002, 0);
            节气查询判断(2000, 49, 2002, 1);
        }

        [TestMethod]
        public void 上下节气测试()
        {
            上下节气(new DateTime(2019, 1, 1, 0, 0, 0));
            上下节气(new DateTime(2019, 12, 31, 0, 0, 0));
        }

        [TestMethod]
        public void 节气时间测试()
        {
            var d = new DateTime(2019, 1, 1, 0, 0, 0);
            var t = new 节气时间(d);
            Assert.IsTrue(t.枚举 == 节气节令.冬至);
            Console.WriteLine($"出生日期:{d:yyyy/MM/dd HH:mm}\t节气时间:{t.时间:yyyy/MM/dd HH:mm}\t生于{t.枚举}后第\t{t.节后日}日");
        }
    }
}
