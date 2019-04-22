namespace 阴阳易演.计算类
{
    using System.Collections.Generic;
    using 抽象类;
    using 枚举类;
    using 查询类;

    public static class 天干六亲
    {
        #region 扩展
        /**
         * 十神对象 
         */
        public static 天干 正官(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.官鬼() == 客.五行 && 主.阴阳 != 客.阴阳); }
        public static 天干 偏官(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.官鬼() == 客.五行 && 主.阴阳 == 客.阴阳); }
        public static 天干 正印(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.父母() == 客.五行 && 主.阴阳 != 客.阴阳); }
        public static 天干 偏印(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.父母() == 客.五行 && 主.阴阳 == 客.阴阳); }
        public static 天干 劫财(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.兄弟() == 客.五行 && 主.阴阳 != 客.阴阳); }
        public static 天干 比肩(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.兄弟() == 客.五行 && 主.阴阳 == 客.阴阳); }
        public static 天干 伤官(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.子孙() == 客.五行 && 主.阴阳 != 客.阴阳); }
        public static 天干 食神(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.子孙() == 客.五行 && 主.阴阳 == 客.阴阳); }
        public static 天干 正财(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.妻妾() == 客.五行 && 主.阴阳 != 客.阴阳); }
        public static 天干 偏财(this 天干 主) { return 干支表.天干列表.Find(客 => 主.五行.妻妾() == 客.五行 && 主.阴阳 == 客.阴阳); }
        /**
         * 十神判定
         * 命名规则使用了中文语言习惯,方便调用时阅读
         * 例如: 
         * 天干.甲.的正印是(天干.癸)
         * 天干.乙.的正官是(天干.庚)
         */
        public static bool 的正官是(this 天干 主, 天干 客) => 主.正官() == 客;
        public static bool 的偏官是(this 天干 主, 天干 客) => 主.偏官() == 客;
        public static bool 的正印是(this 天干 主, 天干 客) => 主.正印() == 客;
        public static bool 的偏印是(this 天干 主, 天干 客) => 主.偏印() == 客;
        public static bool 的劫财是(this 天干 主, 天干 客) => 主.劫财() == 客;
        public static bool 的比肩是(this 天干 主, 天干 客) => 主.比肩() == 客;
        public static bool 的伤官是(this 天干 主, 天干 客) => 主.伤官() == 客;
        public static bool 的食神是(this 天干 主, 天干 客) => 主.食神() == 客;
        public static bool 的正财是(this 天干 主, 天干 客) => 主.正财() == 客;
        public static bool 的偏财是(this 天干 主, 天干 客) => 主.偏财() == 客;
        /**
         * 六亲列表
         * 命名规则使用了中文语言习惯,方便调用时阅读
         * 例如: 
         * 天干.甲.的正官六亲(性别枚举.男)
         * 天干.乙.的偏官六亲(性别枚举.女)
         */
        public static List<string> 的正官六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("女儿");
                    关系组.Add("侄女");
                    关系组.Add("外婆");
                    关系组.Add("姑表姐妹");
                    break;
                case 性别枚举.女:
                    关系组.Add("丈夫");
                    关系组.Add("姐夫");
                    关系组.Add("妹婿");
                    关系组.Add("姑表兄弟");
                    关系组.Add("小叔子");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的偏官六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("儿子");
                    关系组.Add("姐夫");
                    关系组.Add("妹婿");
                    关系组.Add("侄儿");
                    关系组.Add("姑表兄弟");
                    break;
                case 性别枚举.女:
                    关系组.Add("情人");
                    关系组.Add("儿媳");
                    关系组.Add("姑表姐妹");
                    关系组.Add("外婆");
                    关系组.Add("大小姑子");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的正印六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("母亲");
                    关系组.Add("外孙女");
                    关系组.Add("姨");
                    break;
                case 性别枚举.女:
                    关系组.Add("祖父");
                    关系组.Add("女婿");
                    关系组.Add("孙儿");
                    关系组.Add("舅");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的偏印六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("祖父");
                    关系组.Add("外孙");
                    关系组.Add("外父");
                    关系组.Add("舅");
                    break;
                case 性别枚举.女:
                    关系组.Add("母亲");
                    关系组.Add("孙女");
                    关系组.Add("姨");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的劫财六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("姐妹");
                    关系组.Add("儿媳");
                    关系组.Add("堂姐妹");
                    关系组.Add("姨表姐妹");
                    break;
                case 性别枚举.女:
                    关系组.Add("兄弟");
                    关系组.Add("家公");
                    关系组.Add("堂兄弟");
                    关系组.Add("姨表兄弟");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的比肩六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("兄弟 ");
                    关系组.Add("姑丈");
                    关系组.Add("堂兄弟");
                    关系组.Add("姨表兄弟");
                    break;
                case 性别枚举.女:
                    关系组.Add("姐妹");
                    关系组.Add("堂姐妹");
                    关系组.Add("姨表姐妹");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的伤官六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("祖母");
                    关系组.Add("孙女");
                    关系组.Add("外母");
                    关系组.Add("外甥女");
                    break;
                case 性别枚举.女:
                    关系组.Add("儿子");
                    关系组.Add("外甥");
                    关系组.Add("外公");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的食神六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("女婿");
                    关系组.Add("孙儿");
                    关系组.Add("外公");
                    关系组.Add("外甥");
                    break;
                case 性别枚举.女:
                    关系组.Add("祖母");
                    关系组.Add("女儿");
                    关系组.Add("外甥女");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的正财六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("妻子");
                    关系组.Add("兄嫂");
                    关系组.Add("弟媳");
                    关系组.Add("舅表姐妹");
                    关系组.Add("大小姨子");
                    break;
                case 性别枚举.女:
                    关系组.Add("父亲");
                    关系组.Add("伯叔");
                    关系组.Add("外孙儿");
                    关系组.Add("舅表兄弟");
                    break;
            }
            return 关系组;
        }
        public static List<string> 的偏财六亲(this 天干 主, 性别枚举 男女)
        {
            var 关系组 = new List<string>();
            switch (男女)
            {
                case 性别枚举.男:
                    关系组.Add("父亲");
                    关系组.Add("伯叔");
                    关系组.Add("情人");
                    关系组.Add("小舅");
                    关系组.Add("舅表兄弟");
                    break;
                case 性别枚举.女:
                    关系组.Add("家婆");
                    关系组.Add("兄嫂");
                    关系组.Add("弟媳");
                    关系组.Add("外孙女");
                    关系组.Add("舅表姐妹");
                    break;
            }
            return 关系组;
        }

        #endregion

    }
}