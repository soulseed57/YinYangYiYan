namespace 阴阳易演.容器类
{
    using System;
    using 引用库;
    using 枚举类;

    public class 节气
    {
        #region 构造
        public 节气(DateTime 日期)
        {
            var 节气时间 = new 节气时间(日期);
            名称 = 枚举转换类<节气节令>.获取名称(节气时间.枚举);
            枚举 = 节气时间.枚举;
            交节 = 节气时间.时间;
            上一节气时间 = 节气时间.上一节令时间(日期);
            下一节气时间 = 节气时间.下一节令时间(日期);
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public 节气节令 枚举 { get; }
        public DateTime 交节 { get; }
        public DateTime? 上一节气时间 { get; }
        public DateTime? 下一节气时间 { get; }

        #endregion

        #region 重写
        public override string ToString() => 名称;

        #endregion

    }
}
