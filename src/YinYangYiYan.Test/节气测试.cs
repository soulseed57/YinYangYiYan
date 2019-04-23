namespace 阴阳易演.Test
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 抽象类;
    using 枚举类;
    using 查询类;

    [TestClass]
    public class 节气测试
    {
        #region 便捷测试
        static void 便捷节气表(DateTime date, 节气枚举 测试节气, bool 精确到分钟 = false)
        {
            var 节气 = 节气表.节气枚举查询(date, 精确到分钟);
            Assert.IsTrue(节气 == 测试节气);
            Console.WriteLine($"时间: {date:yyyy年MM月dd日}\t节气: {节气}");
            Console.WriteLine("--------------------");
        }

        #endregion

        [TestMethod]
        public void 节气时间测试()
        {
            // 精确到天
            便捷节气表(new DateTime(2018, 12, 23), 节气枚举.冬至);
            便捷节气表(new DateTime(2019, 12, 21), 节气枚举.大雪);
            便捷节气表(new DateTime(2019, 1, 4), 节气枚举.冬至);
            便捷节气表(new DateTime(2019, 1, 5), 节气枚举.小寒);
            // 精确到分钟
            便捷节气表(new DateTime(2019, 1, 5, 21, 0, 0), 节气枚举.冬至, true);
            便捷节气表(new DateTime(2019, 1, 5, 22, 0, 0), 节气枚举.小寒, true);

        }

        [TestMethod]
        public void 四季判断()
        {
            var showMsg = new StringBuilder();
            for (var i = 0; i < 24; i++)
            {
                var 节气 = (节气枚举)Enum.ToObject(typeof(节气枚举), i);
                var 时间 = 节气表.节气时间查询(2017, 节气);
                var 季节名 = 季节.季节查询(时间).GetType().Name;
                showMsg.AppendLine($"{节气}:{时间:MM-dd}\t{季节名}");
            }
            var t = new DateTime(2017, 1, 1);
            var r = new Random();
            var d = r.Next(365);
            var date = t.AddDays(d);
            var season = 季节.季节查询(date).GetType().Name;
            showMsg.AppendLine($"{date:yyyy-MM-dd}\t{season}");

            Console.Write(showMsg.ToString());
        }

    }
}
