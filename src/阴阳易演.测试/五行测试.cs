namespace 阴阳易演.测试
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 具象类.五行;
    using 容器类;
    using 抽象类;
    using 枚举类;
    using 计算类;

    [TestClass]
    public class 五行测试
    {
        #region 便捷测试
        static void 十神计算测试(天干 主, 天干 客, 十神枚举 测试枚举)
        {
            var 神 = new 十神(主, 客);
            Console.WriteLine($"主:{主.名称} 客:{客.名称} 名称:{神.名称} 简称:{神.简称}");
            Console.WriteLine("----------");
            Assert.IsTrue(神.枚举 == 测试枚举);
        }

        #endregion

        [TestMethod]
        public void 五行六亲计算()
        {
            // 金
            Assert.IsTrue(五行.金.的父母是(五行.土));
            Assert.IsTrue(五行.金.的子孙是(五行.水));
            Assert.IsTrue(五行.金.的官鬼是(五行.火));
            Assert.IsTrue(五行.金.的妻妾是(五行.木));
            Assert.IsTrue(五行.金.的兄弟是(五行.金));
            // 水
            Assert.IsTrue(五行.水.的父母是(五行.金));
            Assert.IsTrue(五行.水.的子孙是(五行.木));
            Assert.IsTrue(五行.水.的官鬼是(五行.土));
            Assert.IsTrue(五行.水.的妻妾是(五行.火));
            Assert.IsTrue(五行.水.的兄弟是(五行.水));
            // 木
            Assert.IsTrue(五行.木.的父母是(五行.水));
            Assert.IsTrue(五行.木.的子孙是(五行.火));
            Assert.IsTrue(五行.木.的官鬼是(五行.金));
            Assert.IsTrue(五行.木.的妻妾是(五行.土));
            Assert.IsTrue(五行.木.的兄弟是(五行.木));
            // 火
            Assert.IsTrue(五行.火.的父母是(五行.木));
            Assert.IsTrue(五行.火.的子孙是(五行.土));
            Assert.IsTrue(五行.火.的官鬼是(五行.水));
            Assert.IsTrue(五行.火.的妻妾是(五行.金));
            Assert.IsTrue(五行.火.的兄弟是(五行.火));
            // 土
            Assert.IsTrue(五行.土.的父母是(五行.火));
            Assert.IsTrue(五行.土.的子孙是(五行.金));
            Assert.IsTrue(五行.土.的官鬼是(五行.木));
            Assert.IsTrue(五行.土.的妻妾是(五行.水));
            Assert.IsTrue(五行.土.的兄弟是(五行.土));
        }

        [TestMethod]
        public void 生克关系()
        {
            Assert.IsInstanceOfType(五行.土.生我(), typeof(火));
            Assert.IsInstanceOfType(五行.土.我生(), typeof(金));
            Assert.IsInstanceOfType(五行.土.克我(), typeof(木));
            Assert.IsInstanceOfType(五行.土.我克(), typeof(水));
            Assert.IsInstanceOfType(五行.土.同我(), typeof(土));

            Assert.IsInstanceOfType(五行.金.生我, typeof(土));
            Assert.IsInstanceOfType(五行.金.我生, typeof(水));
            Assert.IsInstanceOfType(五行.金.克我, typeof(火));
            Assert.IsInstanceOfType(五行.金.我克, typeof(木));
            Assert.IsInstanceOfType(五行.金.同我, typeof(金));

            Assert.IsInstanceOfType(五行.金.我生.我生.我生, typeof(火));
        }

        [TestMethod]
        public void 五行旺衰()
        {
            var showMsg = new StringBuilder();
            var 季节列表 = new List<季节> { 季节.春季, 季节.夏季, 季节.秋季, 季节.冬季, 季节.长夏 };
            foreach (var 季 in 季节列表)
            {
                if (季.名称 == "春季")
                {
                    Assert.IsTrue(季.名称 == "春季" && 季.旺.名称 == "木");
                }

                if (季.名称 == "夏季")
                {
                    Assert.IsTrue(季.名称 == "夏季" && 季.旺.名称 == "火");
                }

                if (季.名称 == "秋季")
                {
                    Assert.IsTrue(季.名称 == "秋季" && 季.旺.名称 == "金");
                }

                if (季.名称 == "冬季")
                {
                    Assert.IsTrue(季.名称 == "冬季" && 季.旺.名称 == "水");
                }

                if (季.名称 == "长夏")
                {
                    Assert.IsTrue(季.名称 == "长夏" && 季.旺.名称 == "土");
                }

                showMsg.Append($"{季.名称}\r\n");
                showMsg.Append($"{季.旺.名称}旺\t");
                showMsg.Append($"{季.相.名称}相\t");
                showMsg.Append($"{季.休.名称}休\t");
                showMsg.Append($"{季.囚.名称}囚\t");
                showMsg.Append($"{季.死.名称}死\t");
                showMsg.AppendLine();
            }
            Console.Write(showMsg.ToString());
        }

        [TestMethod]
        public void 十神测试()
        {
            十神计算测试(天干.甲, 天干.乙, 十神枚举.劫财);
            十神计算测试(天干.丙, 天干.甲, 十神枚举.偏印);
            十神计算测试(天干.庚, 天干.壬, 十神枚举.食神);
            十神计算测试(天干.癸, 天干.丁, 十神枚举.偏财);
            十神计算测试(天干.戊, 天干.乙, 十神枚举.正官);
        }
    }
}