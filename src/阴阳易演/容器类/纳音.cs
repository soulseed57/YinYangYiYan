namespace 阴阳易演.容器类
{
    using System;
    using 抽象类;
    using 枚举类;

    public class 纳音
    {
        #region 构造
        public 纳音(甲子枚举 枚)
        {
            switch (枚)
            {
                case 甲子枚举.甲子:
                case 甲子枚举.乙丑:
                    名称 = "海中金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.丙寅:
                case 甲子枚举.丁卯:
                    名称 = "炉中火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.戊辰:
                case 甲子枚举.己巳:
                    名称 = "大林木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.庚午:
                case 甲子枚举.辛未:
                    名称 = "路旁土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.壬申:
                case 甲子枚举.癸酉:
                    名称 = "剑锋金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.甲戌:
                case 甲子枚举.乙亥:
                    名称 = "山头火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.丙子:
                case 甲子枚举.丁丑:
                    名称 = "涧下水";
                    五行 = 五行.水;
                    break;
                case 甲子枚举.戊寅:
                case 甲子枚举.己卯:
                    名称 = "城头土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.庚辰:
                case 甲子枚举.辛巳:
                    名称 = "白蜡金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.壬午:
                case 甲子枚举.癸未:
                    名称 = "杨柳木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.甲申:
                case 甲子枚举.乙酉:
                    名称 = "井泉水";
                    五行 = 五行.水;
                    break;
                case 甲子枚举.丙戌:
                case 甲子枚举.丁亥:
                    名称 = "屋上土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.戊子:
                case 甲子枚举.己丑:
                    名称 = "霹雳火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.庚寅:
                case 甲子枚举.辛卯:
                    名称 = "松柏木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.壬辰:
                case 甲子枚举.癸巳:
                    名称 = "长流水";
                    五行 = 五行.水;
                    break;
                case 甲子枚举.甲午:
                case 甲子枚举.乙未:
                    名称 = "砂中金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.丙申:
                case 甲子枚举.丁酉:
                    名称 = "山下火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.戊戌:
                case 甲子枚举.己亥:
                    名称 = "平地木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.庚子:
                case 甲子枚举.辛丑:
                    名称 = "壁上土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.壬寅:
                case 甲子枚举.癸卯:
                    名称 = "金箔金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.甲辰:
                case 甲子枚举.乙巳:
                    名称 = "覆灯火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.丙午:
                case 甲子枚举.丁未:
                    名称 = "天河水";
                    五行 = 五行.水;
                    break;
                case 甲子枚举.戊申:
                case 甲子枚举.己酉:
                    名称 = "大驿土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.庚戌:
                case 甲子枚举.辛亥:
                    名称 = "钗钏金";
                    五行 = 五行.金;
                    break;
                case 甲子枚举.壬子:
                case 甲子枚举.癸丑:
                    名称 = "桑柘木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.甲寅:
                case 甲子枚举.乙卯:
                    名称 = "大溪水";
                    五行 = 五行.水;
                    break;
                case 甲子枚举.丙辰:
                case 甲子枚举.丁巳:
                    名称 = "砂中土";
                    五行 = 五行.土;
                    break;
                case 甲子枚举.戊午:
                case 甲子枚举.己未:
                    名称 = "天上火";
                    五行 = 五行.火;
                    break;
                case 甲子枚举.庚申:
                case 甲子枚举.辛酉:
                    名称 = "石榴木";
                    五行 = 五行.木;
                    break;
                case 甲子枚举.壬戌:
                case 甲子枚举.癸亥:
                    名称 = "大海水";
                    五行 = 五行.水;
                    break;
                default:
                    throw new Exception($"未找到匹配的枚举,当前输入:{枚}");
            }
        }

        #endregion

        #region 属性
        public string 名称 { get; }
        public 五行 五行 { get; }

        #endregion

    }
}