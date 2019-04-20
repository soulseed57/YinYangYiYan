using System;

namespace 阴阳易演.容器类
{
    using 枚举类;
    using 查询类;

    public class 节气
    {
        #region 构造
        public 节气(DateTime 时间)
        {
            var 枚 = 二十四节气.节气枚举查询(时间);
            名称 = 二十四节气.获取节气名称(枚);
            枚举 = 枚;
            交节 = 二十四节气.节气时间查询(时间.Year, 枚);
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public 节气枚举 枚举 { get; }
        public DateTime 交节 { get; }

        #endregion

    }
}
