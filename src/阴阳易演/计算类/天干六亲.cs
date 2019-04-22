namespace 阴阳易演.计算类
{
    using System.Collections.Generic;
    using 抽象类;
    using 枚举类;

    public static class 天干六亲
    {
        #region 扩展
        public static List<string> 正官匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.官鬼() == 客.五行 && 主.阴阳 != 客.阴阳)
            {
                return 正官(男女);
            }
            return null;
        }
        public static List<string> 偏官匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.官鬼() == 客.五行 && 主.阴阳 == 客.阴阳)
            {
                return 偏官(男女);
            }
            return null;
        }
        public static List<string> 正印匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.父母() == 客.五行 && 主.阴阳 != 客.阴阳)
            {
                return 正印(男女);
            }
            return null;
        }
        public static List<string> 偏印匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.父母() == 客.五行 && 主.阴阳 == 客.阴阳)
            {
                return 偏印(男女);
            }
            return null;
        }
        public static List<string> 劫财匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.兄弟() == 客.五行 && 主.阴阳 != 客.阴阳)
            {
                return 劫财(男女);
            }
            return null;
        }
        public static List<string> 比肩匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.兄弟() == 客.五行 && 主.阴阳 == 客.阴阳)
            {
                return 比肩(男女);
            }
            return null;
        }
        public static List<string> 伤官匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.子孙() == 客.五行 && 主.阴阳 != 客.阴阳)
            {
                return 伤官(男女);
            }
            return null;
        }
        public static List<string> 食神匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.子孙() == 客.五行 && 主.阴阳 == 客.阴阳)
            {
                return 食神(男女);
            }
            return null;
        }
        public static List<string> 正财匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.妻妾() == 客.五行 && 主.阴阳 != 客.阴阳)
            {
                return 正财(男女);
            }
            return null;
        }
        public static List<string> 偏财匹配(this 天干 主, 天干 客, 性别枚举 男女)
        {
            if (主.五行.妻妾() == 客.五行 && 主.阴阳 == 客.阴阳)
            {
                return 偏财(男女);
            }
            return null;
        }

        #endregion

        #region 计算
        public static List<string> 正官(性别枚举 男女)
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
        public static List<string> 偏官(性别枚举 男女)
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
        public static List<string> 正印(性别枚举 男女)
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
        public static List<string> 偏印(性别枚举 男女)
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
        public static List<string> 劫财(性别枚举 男女)
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
        public static List<string> 比肩(性别枚举 男女)
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
        public static List<string> 伤官(性别枚举 男女)
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
        public static List<string> 食神(性别枚举 男女)
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
        public static List<string> 正财(性别枚举 男女)
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
        public static List<string> 偏财(性别枚举 男女)
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