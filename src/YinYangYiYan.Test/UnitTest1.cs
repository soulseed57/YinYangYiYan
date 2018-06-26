using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YinYangYiYan.Test
{
    using 阴阳易演.具象类.两仪;
    using 阴阳易演.具象类.五行;
    using 阴阳易演.具象类.地支;
    using 阴阳易演.计算类;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 阳水()
        {
            var 配地支 = new 河图(-231);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阳));
            Assert.IsInstanceOfType(配地支.五行, typeof(水));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(子));
        }

        [TestMethod]
        public void 阴水()
        {
            var 配地支 = new 河图(96);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阴));
            Assert.IsInstanceOfType(配地支.五行, typeof(水));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(亥));
        }

        [TestMethod]
        public void 阳火()
        {
            var 配地支 = new 河图(-77);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阳));
            Assert.IsInstanceOfType(配地支.五行, typeof(火));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(午));
        }

        [TestMethod]
        public void 阴火()
        {
            var 配地支 = new 河图(12);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阴));
            Assert.IsInstanceOfType(配地支.五行, typeof(火));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(巳));
        }

        [TestMethod]
        public void 阳木()
        {
            var 配地支 = new 河图(623);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阳));
            Assert.IsInstanceOfType(配地支.五行, typeof(木));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(寅));
        }

        [TestMethod]
        public void 阴木()
        {
            var 配地支 = new 河图(-7318);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阴));
            Assert.IsInstanceOfType(配地支.五行, typeof(木));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(卯));
        }

        [TestMethod]
        public void 阳金()
        {
            var 配地支 = new 河图(-79);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阳));
            Assert.IsInstanceOfType(配地支.五行, typeof(金));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(申));
        }

        [TestMethod]
        public void 阴金()
        {
            var 配地支 = new 河图(-2344);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阴));
            Assert.IsInstanceOfType(配地支.五行, typeof(金));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(酉));
        }

        [TestMethod]
        public void 阳土()
        {
            var 配地支 = new 河图(25);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阳));
            Assert.IsInstanceOfType(配地支.五行, typeof(土));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(辰));
            Assert.IsInstanceOfType(配地支.地支[1], typeof(戌));
        }

        [TestMethod]
        public void 阴土()
        {
            var 配地支 = new 河图(0);
            Assert.IsInstanceOfType(配地支.阴阳, typeof(阴));
            Assert.IsInstanceOfType(配地支.五行, typeof(土));
            Assert.IsInstanceOfType(配地支.地支[0], typeof(丑));
            Assert.IsInstanceOfType(配地支.地支[1], typeof(未));
        }
    }
}
