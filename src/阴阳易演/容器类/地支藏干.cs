namespace 阴阳易演.容器类
{
    using 具象类.地支;
    using 抽象类;

    public class 地支藏干
    {
        public 地支藏干(地支 支)
        {
            天干 余 = null, 中 = null, 本 = null;
            switch (支)
            {
                case 子 _:
                    本 = 天干.癸;
                    藏干 = new 天干[] { 本 };
                    break;
                case 丑 _:
                    余 = 天干.癸;
                    中 = 天干.辛;
                    本 = 天干.己;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 寅 _:
                    余 = 天干.戊;
                    中 = 天干.丙;
                    本 = 天干.甲;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 卯 _:
                    本 = 天干.乙;
                    藏干 = new 天干[] { 本 };
                    break;
                case 辰 _:
                    余 = 天干.乙;
                    中 = 天干.癸;
                    本 = 天干.戊;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 巳 _:
                    余 = 天干.戊;
                    中 = 天干.庚;
                    本 = 天干.丙;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 午 _:
                    中 = 天干.己;
                    本 = 天干.丁;
                    藏干 = new 天干[] { 中, 本 };
                    break;
                case 未 _:
                    余 = 天干.丁;
                    中 = 天干.乙;
                    本 = 天干.己;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 申 _:
                    余 = 天干.戊;
                    中 = 天干.壬;
                    本 = 天干.庚;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 酉 _:
                    本 = 天干.辛;
                    藏干 = new 天干[] { 本 };
                    break;
                case 戌 _:
                    余 = 天干.辛;
                    中 = 天干.丁;
                    本 = 天干.戊;
                    藏干 = new 天干[] { 余, 中, 本 };
                    break;
                case 亥 _:
                    中 = 天干.甲;
                    本 = 天干.壬;
                    藏干 = new 天干[] { 中, 本 };
                    break;
            }
            余气 = 余?.名称;
            中气 = 中?.名称;
            本气 = 本?.名称;
        }
        public string 余气 { get; }
        public string 中气 { get; }
        public string 本气 { get; }
        public 天干[] 藏干 { get; }
    }
}
