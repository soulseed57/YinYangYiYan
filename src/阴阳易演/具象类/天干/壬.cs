﻿namespace 阴阳易演.具象类.天干
{
    using 抽象类;

    public class 壬 : 天干
    {
        public 壬()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.水;
        }
    }

    public class 壬水 : 壬
    {
    }
}