using System;

namespace 阴阳易演.容器类
{
    using 查询类;

    public class 节气
    {
        public 节气(int 年份, 二十四节气.节气枚举 节)
        {
            名称 = 节.ToString();
            日期 = 二十四节气.节气查询(年份, 节);
        }
        public string 名称 { get; protected set; }
        public DateTime 日期 { get; protected set; }
    }
}
