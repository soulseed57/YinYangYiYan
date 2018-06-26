using System;

namespace 阴阳易演.计算类
{
    using 具象类.地支;
    using 抽象类;
    using 抽象类.基类;

    public class 河图
    {
        public int 河图数 { get; protected set; }
        public 两仪 阴阳 { get; protected set; }
        public 五行 五行 { get; protected set; }
        public 地支[] 地支 { get; protected set; }

        public 河图(int 原数)
        {
            河图数 = 太极.河洛数(原数);
            switch (河图数)
            {
                //1 6为水，1数为阳水，6数为阴水，故1可配子，6可配亥；
                case 1:
                    阴阳 = 两仪.阳;
                    五行 = 五行.水;
                    地支 = new 地支[] { new 子() };
                    break;
                case 6:
                    阴阳 = 两仪.阴;
                    五行 = 五行.水;
                    地支 = new 地支[] { new 亥() };
                    break;
                //2 7为火，7数为阳火，2数为阴火，故7可配午，2可配巳；
                case 7:
                    阴阳 = 两仪.阳;
                    五行 = 五行.火;
                    地支 = new 地支[] { new 午() };
                    break;
                case 2:
                    阴阳 = 两仪.阴;
                    五行 = 五行.火;
                    地支 = new 地支[] { new 巳() };
                    break;
                //3 8为木，3数为阳木，8数为阴木，故3可配寅，8可配卯；
                case 3:
                    阴阳 = 两仪.阳;
                    五行 = 五行.木;
                    地支 = new 地支[] { new 寅() };
                    break;
                case 8:
                    阴阳 = 两仪.阴;
                    五行 = 五行.木;
                    地支 = new 地支[] { new 卯() };
                    break;
                //4 9为金，9数为阳金，4数为阴金，故9可配申，4可配酉；
                case 9:
                    阴阳 = 两仪.阳;
                    五行 = 五行.金;
                    地支 = new 地支[] { new 申() };
                    break;
                case 4:
                    阴阳 = 两仪.阴;
                    五行 = 五行.金;
                    地支 = new 地支[] { new 酉() };
                    break;
                //5 10为土，5数为阳土，10数为阴土，故5可配辰、戌，10可配丑、未
                case 5:
                    阴阳 = 两仪.阳;
                    五行 = 五行.土;
                    地支 = new 地支[] { new 辰(), new 戌() };
                    break;
                case 10:
                    阴阳 = 两仪.阴;
                    五行 = 五行.土;
                    地支 = new 地支[] { new 丑(), new 未() };
                    break;
                default:
                    throw new Exception($"数值错误,当前给定数值{原数}不正确");
            }
        }

    }
}
