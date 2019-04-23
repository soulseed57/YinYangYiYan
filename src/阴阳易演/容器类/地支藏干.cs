namespace 阴阳易演.容器类
{
    using 具象类.地支;
    using 抽象类;

    public class 地支藏干
    {
        public 地支藏干(地支 支)
        {
            天干 本 = null, 中 = null, 余 = null;
            switch (支)
            {
                case 子 _:
                    本 = 天干.癸;
                    藏干 = new 天干[] { 本 };
                    break;
                case 丑 _:
                    本 = 天干.己; 中 = 天干.辛; 余 = 天干.癸;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 寅 _:
                    本 = 天干.甲; 中 = 天干.丙; 余 = 天干.戊;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 卯 _:
                    本 = 天干.乙;
                    藏干 = new 天干[] { 本 };
                    break;
                case 辰 _:
                    本 = 天干.戊; 中 = 天干.癸; 余 = 天干.乙;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 巳 _:
                    本 = 天干.丙; 中 = 天干.庚; 余 = 天干.戊;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 午 _:
                    本 = 天干.丁; 中 = 天干.己;
                    藏干 = new 天干[] { 本, 中 };
                    break;
                case 未 _:
                    本 = 天干.己; 中 = 天干.乙; 余 = 天干.丁;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 申 _:
                    本 = 天干.庚; 中 = 天干.壬; 余 = 天干.戊;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 酉 _:
                    本 = 天干.辛;
                    藏干 = new 天干[] { 本 };
                    break;
                case 戌 _:
                    本 = 天干.戊; 中 = 天干.丁; 余 = 天干.辛;
                    藏干 = new 天干[] { 本, 中, 余 };
                    break;
                case 亥 _:
                    本 = 天干.壬; 中 = 天干.甲;
                    藏干 = new 天干[] { 本, 中 };
                    break;
            }
            本气 = 本?.名称;
            中气 = 中?.名称;
            余气 = 余?.名称;
        }
        public string 本气 { get; }
        public string 中气 { get; }
        public string 余气 { get; }
        public 天干[] 藏干 { get; }
    }
}
