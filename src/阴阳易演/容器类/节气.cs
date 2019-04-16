using System;

namespace 阴阳易演.容器类
{
    using 枚举类;
    using static 查询类.二十四节气;

    public class 节气
    {
        public 节气(DateTime 时间)
        {
            var 节 = 节气查询(时间);
            名称 = 节.ToString();
            枚举 = 节;
            交节 = 节气查询(时间.Year, 节);
        }

        public string 名称 { get; protected set; }
        public 节气枚举 枚举 { get; protected set; }
        public DateTime 交节 { get; protected set; }

    }
}
