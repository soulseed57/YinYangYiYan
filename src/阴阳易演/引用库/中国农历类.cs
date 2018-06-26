namespace 阴阳易演.引用库
{
    using System;

    /// <summary>
    /// 中国农历类 版本V1.0 支持 1900.1.31日起至 2049.12.31日止的数据
    /// </summary>
    /// <remarks>
    /// 本程序使用数据来源于网上的万年历查询，并综合了一些其它数据
    /// </remarks>
    public class ChineseCalendar
    {
        #region 内部结构

        struct SolarHolidayStruct
        {
            public readonly int Month;
            public readonly int Day;
            public int Recess; //假期长度
            public readonly string HolidayName;
            public SolarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        struct LunarHolidayStruct
        {
            public readonly int Month;
            public readonly int Day;
            public int Recess;
            public readonly string HolidayName;


            public LunarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        struct WeekHolidayStruct
        {
            public readonly int Month;
            public readonly int WeekAtMonth;
            public readonly int WeekDay;
            public readonly string HolidayName;


            public WeekHolidayStruct(int month, int weekAtMonth, int weekDay, string name)
            {
                Month = month;
                WeekAtMonth = weekAtMonth;
                WeekDay = weekDay;
                HolidayName = name;
            }
        }

        #endregion

        #region 内部变量

        DateTime _date;
        DateTime _datetime;
        readonly int _cYear;
        readonly int _cMonth;
        readonly int _cDay;
        readonly bool _cIsLeapMonth; //当月是否闰月
        readonly bool _cIsLeapYear; //当年是否有闰月

        #endregion

        #region 基础数据

        #region _基本常量

        const int MinYear = 1900;
        const int MaxYear = 2050;
        static DateTime _minDay = new DateTime(1900, 1, 30);
        static readonly DateTime _maxDay = new DateTime(2049, 12, 31);
        const int GanZhiStartYear = 1864; //干支计算起始年
        static readonly DateTime _ganZhiStartDay = new DateTime(1899, 12, 22);//起始日
        const string HzNum = "零一二三四五六七八九";
        const int AnimalStartYear = 1900; //1900年为鼠年
        static readonly DateTime _chineseConstellationReferDay = new DateTime(2007, 9, 13);//28星宿参考值,本日为角

        #endregion

        #region _阴历数据

        /// <summary>
        /// 来源于网上的农历数据
        /// </summary>
        /// <remarks>
        /// 数据结构如下，共使用17位数据
        /// 第17位：表示闰月天数，0表示29天   1表示30天
        /// 第16位-第5位（共12位）表示12个月，其中第16位表示第一月，如果该月为30天则为1，29天为0
        /// 第4位-第1位（共4位）表示闰月是哪个月，如果当年没有闰月，则置0
        ///</remarks>
        static readonly int[] _lunarDateArray = {
            0x04BD8,0x04AE0,0x0A570,0x054D5,0x0D260,0x0D950,0x16554,0x056A0,0x09AD0,0x055D2,
            0x04AE0,0x0A5B6,0x0A4D0,0x0D250,0x1D255,0x0B540,0x0D6A0,0x0ADA2,0x095B0,0x14977,
            0x04970,0x0A4B0,0x0B4B5,0x06A50,0x06D40,0x1AB54,0x02B60,0x09570,0x052F2,0x04970,
            0x06566,0x0D4A0,0x0EA50,0x06E95,0x05AD0,0x02B60,0x186E3,0x092E0,0x1C8D7,0x0C950,
            0x0D4A0,0x1D8A6,0x0B550,0x056A0,0x1A5B4,0x025D0,0x092D0,0x0D2B2,0x0A950,0x0B557,
            0x06CA0,0x0B550,0x15355,0x04DA0,0x0A5B0,0x14573,0x052B0,0x0A9A8,0x0E950,0x06AA0,
            0x0AEA6,0x0AB50,0x04B60,0x0AAE4,0x0A570,0x05260,0x0F263,0x0D950,0x05B57,0x056A0,
            0x096D0,0x04DD5,0x04AD0,0x0A4D0,0x0D4D4,0x0D250,0x0D558,0x0B540,0x0B6A0,0x195A6,
            0x095B0,0x049B0,0x0A974,0x0A4B0,0x0B27A,0x06A50,0x06D40,0x0AF46,0x0AB60,0x09570,
            0x04AF5,0x04970,0x064B0,0x074A3,0x0EA50,0x06B58,0x055C0,0x0AB60,0x096D5,0x092E0,
            0x0C960,0x0D954,0x0D4A0,0x0DA50,0x07552,0x056A0,0x0ABB7,0x025D0,0x092D0,0x0CAB5,
            0x0A950,0x0B4A0,0x0BAA4,0x0AD50,0x055D9,0x04BA0,0x0A5B0,0x15176,0x052B0,0x0A930,
            0x07954,0x06AA0,0x0AD50,0x05B52,0x04B60,0x0A6E6,0x0A4E0,0x0D260,0x0EA65,0x0D530,
            0x05AA0,0x076A3,0x096D0,0x04BD7,0x04AD0,0x0A4D0,0x1D0B6,0x0D250,0x0D520,0x0DD45,
            0x0B5A0,0x056D0,0x055B2,0x049B0,0x0A577,0x0A4B0,0x0AA50,0x1B255,0x06D20,0x0ADA0,
            0x14B63
        };

        #endregion

        #region _星座名称

        static readonly string[] _constellationName = {
            "白羊座", "金牛座", "双子座",
            "巨蟹座", "狮子座", "处女座",
            "天秤座", "天蝎座", "射手座",
            "摩羯座", "水瓶座", "双鱼座"
        };

        #endregion

        #region _二十四节气

        static string[] _lunarHolidayName = {
            "小寒", "大寒", "立春", "雨水",
            "惊蛰", "春分", "清明", "谷雨",
            "立夏", "小满", "芒种", "夏至",
            "小暑", "大暑", "立秋", "处暑",
            "白露", "秋分", "寒露", "霜降",
            "立冬", "小雪", "大雪", "冬至"
        };

        #endregion

        #region _二十八星宿

        static readonly string[] _chineseConstellationName = {
            // 四       五       六       日       一       二       三
            "角木蛟","亢金龙","女土蝠","房日兔","心月狐","尾火虎","箕水豹",
            "斗木獬","牛金牛","氐土貉","虚日鼠","危月燕","室火猪","壁水獝",
            "奎木狼","娄金狗","胃土彘","昴日鸡","毕月乌","觜火猴","参水猿",
            "井木犴","鬼金羊","柳土獐","星日马","张月鹿","翼火蛇","轸水蚓"
        };

        #endregion

        #region _节气数据

        static readonly string[] _solarTerm =
        {
            "小寒", "大寒",
            "立春", "雨水",
            "惊蛰", "春分",
            "清明", "谷雨",
            "立夏", "小满",
            "芒种", "夏至",
            "小暑", "大暑",
            "立秋", "处暑",
            "白露", "秋分",
            "寒露", "霜降",
            "立冬", "小雪",
            "大雪", "冬至"
        };

        static readonly int[] _sTermInfo =
        {
            0, 21208,
            42467, 63836,
            85337, 107014,
            128867, 150921,
            173149, 195551,
            218072, 240693,
            263343, 285989,
            308563, 331033,
            353350, 375494,
            397447, 419210,
            440795, 462224,
            483532, 504758
        };

        #endregion

        #region _农历相关数据

        static readonly string _ganStr = "甲乙丙丁戊己庚辛壬癸";
        static readonly string _zhiStr = "子丑寅卯辰巳午未申酉戌亥";
        static readonly string _animalStr = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
        static readonly string _nStr1 = "日一二三四五六七八九";
        static readonly string _nStr2 = "初十廿卅";
        static readonly string[] _monthString = { "出错", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "腊月" };
        /// <summary>
        /// 甲子纪年
        /// </summary>
        public static string[] JiaZhi = {
            "甲子", "乙丑", "丙寅", "丁卯", "戊辰", "己巳", "庚午", "辛未", "壬申", "癸酉",
            "甲戊", "乙亥", "丙子", "丁丑", "戊寅", "己卯", "庚辰", "辛巳", "壬午", "癸未",
            "甲申", "乙酉", "丙戌", "丁亥", "戊子", "己丑", "庚寅", "辛卯", "壬辰", "癸巳",
            "甲午", "乙未", "丙申", "丁酉", "戊戌", "己亥", "庚子", "辛丑", "壬寅", "癸卯",
            "甲辰", "乙巳", "丙午", "丁未", "戊申", "己酉", "庚戌", "辛亥", "壬子", "癸丑",
            "甲寅", "乙卯", "丙辰", "丁巳", "戊午", "己未", "庚申", "辛酉", "壬戌", "癸亥"
        };

        #endregion

        #region _按公历计算的节日

        /// <summary>
        /// 按公历计算的节日
        /// </summary>
        static readonly SolarHolidayStruct[] _sHolidayInfo = {
            new SolarHolidayStruct(1, 1, 1, "元旦"),
            new SolarHolidayStruct(2, 2, 0, "世界湿地日"),
            new SolarHolidayStruct(2, 10, 0, "国际气象节"),
            new SolarHolidayStruct(2, 14, 0, "情人节"),
            new SolarHolidayStruct(3, 1, 0, "国际海豹日"),
            new SolarHolidayStruct(3, 5, 0, "学雷锋纪念日"),
            new SolarHolidayStruct(3, 8, 0, "妇女节"),
            new SolarHolidayStruct(3, 12, 0, "植树节 孙中山逝世纪念日"),
            new SolarHolidayStruct(3, 14, 0, "国际警察日"),
            new SolarHolidayStruct(3, 15, 0, "消费者权益日"),
            new SolarHolidayStruct(3, 17, 0, "中国国医节 国际航海日"),
            new SolarHolidayStruct(3, 21, 0, "世界森林日 消除种族歧视国际日 世界儿歌日"),
            new SolarHolidayStruct(3, 22, 0, "世界水日"),
            new SolarHolidayStruct(3, 24, 0, "世界防治结核病日"),
            new SolarHolidayStruct(4, 1, 0, "愚人节"),
            new SolarHolidayStruct(4, 7, 0, "世界卫生日"),
            new SolarHolidayStruct(4, 22, 0, "世界地球日"),
            new SolarHolidayStruct(5, 1, 1, "劳动节"),
            new SolarHolidayStruct(5, 2, 1, "劳动节假日"),
            new SolarHolidayStruct(5, 3, 1, "劳动节假日"),
            new SolarHolidayStruct(5, 4, 0, "青年节"),
            new SolarHolidayStruct(5, 8, 0, "世界红十字日"),
            new SolarHolidayStruct(5, 12, 0, "国际护士节"),
            new SolarHolidayStruct(5, 31, 0, "世界无烟日"),
            new SolarHolidayStruct(6, 1, 0, "国际儿童节"),
            new SolarHolidayStruct(6, 5, 0, "世界环境保护日"),
            new SolarHolidayStruct(6, 26, 0, "国际禁毒日"),
            new SolarHolidayStruct(7, 1, 0, "建党节 香港回归纪念 世界建筑日"),
            new SolarHolidayStruct(7, 11, 0, "世界人口日"),
            new SolarHolidayStruct(8, 1, 0, "建军节"),
            new SolarHolidayStruct(8, 8, 0, "中国男子节 父亲节"),
            new SolarHolidayStruct(8, 15, 0, "抗日战争胜利纪念"),
            new SolarHolidayStruct(9, 9, 0, "  逝世纪念"),
            new SolarHolidayStruct(9, 10, 0, "教师节"),
            new SolarHolidayStruct(9, 18, 0, "九·一八事变纪念日"),
            new SolarHolidayStruct(9, 20, 0, "国际爱牙日"),
            new SolarHolidayStruct(9, 27, 0, "世界旅游日"),
            new SolarHolidayStruct(9, 28, 0, "孔子诞辰"),
            new SolarHolidayStruct(10, 1, 1, "国庆节 国际音乐日"),
            new SolarHolidayStruct(10, 2, 1, "国庆节假日"),
            new SolarHolidayStruct(10, 3, 1, "国庆节假日"),
            new SolarHolidayStruct(10, 6, 0, "老人节"),
            new SolarHolidayStruct(10, 24, 0, "联合国日"),
            new SolarHolidayStruct(11, 10, 0, "世界青年节"),
            new SolarHolidayStruct(11, 12, 0, "孙中山诞辰纪念"),
            new SolarHolidayStruct(12, 1, 0, "世界艾滋病日"),
            new SolarHolidayStruct(12, 3, 0, "世界残疾人日"),
            new SolarHolidayStruct(12, 20, 0, "澳门回归纪念"),
            new SolarHolidayStruct(12, 24, 0, "平安夜"),
            new SolarHolidayStruct(12, 25, 0, "圣诞节"),
            new SolarHolidayStruct(12, 26, 0, " 诞辰纪念")
           };

        #endregion

        #region _按农历计算的节日

        /// <summary>
        /// 按农历计算的节日
        /// </summary>
        static readonly LunarHolidayStruct[] _lHolidayInfo = {
            new LunarHolidayStruct(1, 1, 1, "春节"),
            new LunarHolidayStruct(1, 15, 0, "元宵节"),
            new LunarHolidayStruct(5, 5, 0, "端午节"),
            new LunarHolidayStruct(7, 7, 0, "七夕情人节"),
            new LunarHolidayStruct(7, 15, 0, "中元节 盂兰盆节"),
            new LunarHolidayStruct(8, 15, 0, "中秋节"),
            new LunarHolidayStruct(9, 9, 0, "重阳节"),
            new LunarHolidayStruct(12, 8, 0, "腊八节"),
            new LunarHolidayStruct(12, 23, 0, "北方小年(扫房)"),
            new LunarHolidayStruct(12, 24, 0, "南方小年(掸尘)"),
            //new LunarHolidayStruct(12, 30, 0, "除夕")  //注意除夕需要其它方法进行计算
        };

        #endregion

        #region _按某月第几个星期几的节日

        /// <summary>
        /// 按某月第几个星期几的节日
        /// </summary>
        static readonly WeekHolidayStruct[] _wHolidayInfo = {
            new WeekHolidayStruct(5, 2, 1, "母亲节"),
            new WeekHolidayStruct(5, 3, 1, "全国助残日"),
            new WeekHolidayStruct(6, 3, 1, "父亲节"),
            new WeekHolidayStruct(9, 3, 3, "国际和平日"),
            new WeekHolidayStruct(9, 4, 1, "国际聋人节"),
            new WeekHolidayStruct(10, 1, 2, "国际住房日"),
            new WeekHolidayStruct(10, 1, 4, "国际减轻自然灾害日"),
            new WeekHolidayStruct(11, 4, 5, "感恩节")
        };

        #endregion

        #endregion

        #region 构造函数

        /// <summary>
        /// 用一个标准的公历日期来初使化
        /// </summary>
        /// <param name="dt"></param>
        public ChineseCalendar(DateTime dt)
        {
            CheckDateLimit(dt);

            _date = dt.Date;
            _datetime = dt;

            //农历日期计算部分
            var leap = 0;
            var temp = 0;

            var ts = _date - _minDay;//计算两天的基本差距
            var offset = ts.Days;

            int i;
            for (i = MinYear; i <= MaxYear; i++)
            {
                temp = GetChineseYearDays(i);  //求当年农历年天数
                if (offset - temp < 1) break;
                offset = offset - temp;
            }
            _cYear = i;

            leap = GetChineseLeapMonth(_cYear);//计算该年闰哪个月
            //设定当年是否有闰月
            _cIsLeapYear = leap > 0;
            _cIsLeapMonth = false;
            for (i = 1; i <= 12; i++)
            {
                //闰月
                if ((leap > 0) && (i == leap + 1) && (_cIsLeapMonth == false))
                {
                    _cIsLeapMonth = true;
                    i = i - 1;
                    temp = GetChineseLeapMonthDays(_cYear); //计算闰月天数
                }
                else
                {
                    _cIsLeapMonth = false;
                    temp = GetChineseMonthDays(_cYear, i);//计算非闰月天数
                }
                offset = offset - temp;
                if (offset <= 0) break;
            }

            offset = offset + temp;
            _cMonth = i;
            _cDay = offset;
        }

        /// <summary>
        /// 用农历的日期来初使化
        /// </summary>
        /// <param name="cy">农历年</param>
        /// <param name="cm">农历月</param>
        /// <param name="cd">农历日</param>
        /// <param name="LeapFlag">闰月标志</param>
        public ChineseCalendar(int cy, int cm, int cd, bool leapMonthFlag)
        {
            CheckChineseDateLimit(cy, cm, cd, leapMonthFlag);

            _cYear = cy;
            _cMonth = cm;
            _cDay = cd;

            var offset = 0;

            int temp;
            int i;
            for (i = MinYear; i < cy; i++)
            {
                temp = GetChineseYearDays(i); //求当年农历年天数
                offset = offset + temp;
            }

            var leap = GetChineseLeapMonth(cy);
            _cIsLeapYear = leap != 0;
            _cIsLeapMonth = cm == leap && leapMonthFlag;
            if ((_cIsLeapYear == false) || //当年没有闰月
                 (cm < leap)) //计算月份小于闰月     
            {
                #region ...
                for (i = 1; i < cm; i++)
                {
                    temp = GetChineseMonthDays(cy, i);//计算非闰月天数
                    offset = offset + temp;
                }

                //检查日期是否大于最大天
                if (cd > GetChineseMonthDays(cy, cm))
                {
                    throw new Exception("不合法的农历日期");
                }
                offset = offset + cd; //加上当月的天数
                #endregion
            }
            else   //是闰年，且计算月份大于或等于闰月
            {
                #region ...
                for (i = 1; i < cm; i++)
                {
                    temp = GetChineseMonthDays(cy, i); //计算非闰月天数
                    offset = offset + temp;
                }

                if (cm > leap) //计算月大于闰月
                {
                    temp = GetChineseLeapMonthDays(cy);   //计算闰月天数
                    offset = offset + temp;               //加上闰月天数


                    if (cd > GetChineseMonthDays(cy, cm))
                    {
                        throw new Exception("不合法的农历日期");
                    }
                    offset = offset + cd;
                }
                else  //计算月等于闰月
                {
                    //如果需要计算的是闰月，则应首先加上与闰月对应的普通月的天数
                    if (_cIsLeapMonth) //计算月为闰月
                    {
                        temp = GetChineseMonthDays(cy, cm); //计算非闰月天数
                        offset = offset + temp;
                    }


                    if (cd > GetChineseLeapMonthDays(cy))
                    {
                        throw new Exception("不合法的农历日期");
                    }
                    offset = offset + cd;
                }
                #endregion
            }
            _date = _minDay.AddDays(offset);
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 传回农历 y年m月的总天数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        int GetChineseMonthDays(int year, int month)
        {
            return BitTest32((_lunarDateArray[year - MinYear] & 0x0000FFFF), (16 - month)) ? 30 : 29;
        }

        /// <summary>
        /// 传回农历 y年闰哪个月 1-12 , 没闰传回 0
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        int GetChineseLeapMonth(int year)
        {
            return _lunarDateArray[year - MinYear] & 0xF;
        }

        /// <summary>
        /// 传回农历 y年闰月的天数
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        int GetChineseLeapMonthDays(int year)
        {
            if (GetChineseLeapMonth(year) != 0)
            {
                return (_lunarDateArray[year - MinYear] & 0x10000) != 0 ? 30 : 29;
            }
            return 0;
        }

        /// <summary>
        /// 取农历年一年的天数
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        int GetChineseYearDays(int year)
        {
            int i, f, sumDay, info;


            sumDay = 348; //29天 X 12个月
            i = 0x8000;
            info = _lunarDateArray[year - MinYear] & 0x0FFFF;


            //计算12个月中有多少天为30天
            for (var m = 0; m < 12; m++)
            {
                f = info & i;
                if (f != 0)
                {
                    sumDay++;
                }
                i = i >> 1;
            }
            return sumDay + GetChineseLeapMonthDays(year);
        }

        /// <summary>
        /// 获得当前时间的时辰
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        /// 
        string GetChineseHour(DateTime dt)
        {
            //计算时辰的地支
            var hour = dt.Hour;
            var minute = dt.Minute;

            if (minute != 0) hour += 1;
            var offset = hour / 2;
            if (offset >= 12) offset = 0;
            //zhiHour = zhiStr[offset].ToString();

            //计算天干
            var ts = _date - _ganZhiStartDay;
            var i = ts.Days % 60;

            var indexGan = ((i % 10 + 1) * 2 - 1) % 10 - 1;
            var tmpGan = _ganStr.Substring(indexGan) + _ganStr.Substring(0, indexGan + 2);
            //ganHour = ganStr[((i % 10 + 1) * 2 - 1) % 10 - 1].ToString();

            return tmpGan[offset] + _zhiStr[offset].ToString();
        }

        /// <summary>
        /// 检查公历日期是否符合要求
        /// </summary>
        /// <param name="dt"></param>
        void CheckDateLimit(DateTime dt)
        {
            if ((dt < _minDay) || (dt > _maxDay))
            {
                throw new Exception("超出可转换的日期");
            }
        }

        /// <summary>
        /// 检查农历日期是否合理
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="leapMonth"></param>
        void CheckChineseDateLimit(int year, int month, int day, bool leapMonth)
        {
            if ((year < MinYear) || (year > MaxYear))
            {
                throw new Exception("非法农历日期");
            }
            if ((month < 1) || (month > 12))
            {
                throw new Exception("非法农历日期");
            }
            if ((day < 1) || (day > 30)) //中国的月最多30天
            {
                throw new Exception("非法农历日期");
            }
            var leap = GetChineseLeapMonth(year);// 计算该年应该闰哪个月
            if (leapMonth && (month != leap))
            {
                throw new Exception("非法农历日期");
            }

        }

        /// <summary>
        /// 将0-9转成汉字形式
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        string ConvertNumToChineseNum(char n)
        {
            if ((n < '0') || (n > '9')) return "";
            switch (n)
            {
                case '0':
                    return HzNum[0].ToString();
                case '1':
                    return HzNum[1].ToString();
                case '2':
                    return HzNum[2].ToString();
                case '3':
                    return HzNum[3].ToString();
                case '4':
                    return HzNum[4].ToString();
                case '5':
                    return HzNum[5].ToString();
                case '6':
                    return HzNum[6].ToString();
                case '7':
                    return HzNum[7].ToString();
                case '8':
                    return HzNum[8].ToString();
                case '9':
                    return HzNum[9].ToString();
                default:
                    return "";
            }
        }

        /// <summary>
        /// 测试某位是否为真
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bitpostion"></param>
        /// <returns></returns>
        bool BitTest32(int num, int bitpostion)
        {


            if ((bitpostion > 31) || (bitpostion < 0))
                throw new Exception("Error Param: bitpostion[0-31]:" + bitpostion);


            var bit = 1 << bitpostion;


            if ((num & bit) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 将星期几转成数字表示
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        int ConvertDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                case DayOfWeek.Saturday:
                    return 7;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 比较当天是不是指定的第周几
        /// </summary>
        /// <param name="date"></param>
        /// <param name="month"></param>
        /// <param name="week"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        bool CompareWeekDayHoliday(DateTime date, int month, int week, int day)
        {
            var ret = false;


            if (date.Month == month) //月份相同
            {
                if (ConvertDayOfWeek(date.DayOfWeek) == day) //星期几相同
                {
                    var firstDay = new DateTime(date.Year, date.Month, 1);//生成当月第一天
                    var i = ConvertDayOfWeek(firstDay.DayOfWeek);
                    var firWeekDays = 7 - ConvertDayOfWeek(firstDay.DayOfWeek) + 1; //计算第一周剩余天数


                    if (i > day)
                    {
                        if ((week - 1) * 7 + day + firWeekDays == date.Day)
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        if (day + firWeekDays + (week - 2) * 7 == date.Day)
                        {
                            ret = true;
                        }
                    }
                }
            }


            return ret;
        }

        #endregion

        #region  属性

        #region _节日

        /// <summary>
        /// 计算中国农历节日
        /// </summary>
        public string ChineseCalendarHoliday
        {
            get
            {
                var tempStr = "";
                if (_cIsLeapMonth == false) //闰月不计算节日
                {
                    foreach (var lh in _lHolidayInfo)
                    {
                        if ((lh.Month == _cMonth) && (lh.Day == _cDay))
                        {


                            tempStr = lh.HolidayName;
                            break;


                        }
                    }


                    //对除夕进行特别处理
                    if (_cMonth == 12)
                    {
                        var i = GetChineseMonthDays(_cYear, 12); //计算当年农历12月的总天数
                        if (_cDay == i) //如果为最后一天
                        {
                            tempStr = "除夕";
                        }
                    }
                }
                return tempStr;
            }
        }

        /// <summary>
        /// 按某月第几周第几日计算的节日
        /// </summary>
        public string WeekDayHoliday
        {
            get
            {
                var tempStr = "";
                foreach (var wh in _wHolidayInfo)
                {
                    if (CompareWeekDayHoliday(_date, wh.Month, wh.WeekAtMonth, wh.WeekDay))
                    {
                        tempStr = wh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }

        /// <summary>
        /// 按公历日计算的节日
        /// </summary>
        public string DateHoliday
        {
            get
            {
                var tempStr = "";


                foreach (var sh in _sHolidayInfo)
                {
                    if ((sh.Month == _date.Month) && (sh.Day == _date.Day))
                    {
                        tempStr = sh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }

        #endregion

        #region _公历日期

        /// <summary>
        /// 取对应的公历日期
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// 取星期几
        /// </summary>
        public DayOfWeek WeekDay
        {
            get { return _date.DayOfWeek; }
        }

        /// <summary>
        /// 周几的字符
        /// </summary>
        public string WeekDayStr
        {
            get
            {
                switch (_date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "星期日";
                    case DayOfWeek.Monday:
                        return "星期一";
                    case DayOfWeek.Tuesday:
                        return "星期二";
                    case DayOfWeek.Wednesday:
                        return "星期三";
                    case DayOfWeek.Thursday:
                        return "星期四";
                    case DayOfWeek.Friday:
                        return "星期五";
                    case DayOfWeek.Saturday:
                        return "星期六";
                    default:
                        throw new Exception("不合法的星期枚举");
                }
            }
        }

        /// <summary>
        /// 公历日期中文表示法 如一九九七年七月一日
        /// </summary>
        public string DateString
        {
            get
            {
                return "公元" + _date.ToLongDateString();
            }
        }

        /// <summary>
        /// 当前是否公历闰年
        /// </summary>
        public bool IsLeapYear
        {
            get
            {
                return DateTime.IsLeapYear(_date.Year);
            }
        }

        /// <summary>
        /// 28星宿计算
        /// </summary>
        public string ChineseConstellation
        {
            get
            {
                var offset = 0;
                var modStarDay = 0;


                var ts = _date - _chineseConstellationReferDay;
                offset = ts.Days;
                modStarDay = offset % 28;
                return (modStarDay >= 0 ? _chineseConstellationName[modStarDay] : _chineseConstellationName[27 + modStarDay]);
            }
        }

        /// <summary>
        /// 时辰
        /// </summary>
        public string ChineseHour
        {
            get
            {
                return GetChineseHour(_datetime);
            }
        }

        #endregion

        #region _农历日期

        /// <summary>
        /// 是否闰月
        /// </summary>
        public bool IsChineseLeapMonth
        {
            get { return _cIsLeapMonth; }
        }

        /// <summary>
        /// 当年是否有闰月
        /// </summary>
        public bool IsChineseLeapYear
        {
            get
            {
                return _cIsLeapYear;
            }
        }

        /// <summary>
        /// 农历日
        /// </summary>
        public int ChineseDay
        {
            get { return _cDay; }
        }

        /// <summary>
        /// 农历日中文表示
        /// </summary>
        public string ChineseDayString
        {
            get
            {
                switch (_cDay)
                {
                    case 0:
                        return "";
                    case 10:
                        return "初十";
                    case 20:
                        return "二十";
                    case 30:
                        return "三十";
                    default:
                        return _nStr2[(int)(_cDay / 10)] + _nStr1[_cDay % 10].ToString();


                }
            }
        }

        /// <summary>
        /// 农历的月份
        /// </summary>
        public int ChineseMonth
        {
            get { return _cMonth; }
        }

        /// <summary>
        /// 农历月份字符串
        /// </summary>
        public string ChineseMonthString
        {
            get
            {
                return _monthString[_cMonth];
            }
        }

        /// <summary>
        /// 取农历年份
        /// </summary>
        public int ChineseYear
        {
            get { return _cYear; }
        }

        /// <summary>
        /// 取农历年字符串如，一九九七年
        /// </summary>
        public string ChineseYearString
        {
            get
            {
                var tempStr = "";
                var num = _cYear.ToString();
                for (var i = 0; i < 4; i++)
                {
                    tempStr += ConvertNumToChineseNum(num[i]);
                }
                return tempStr + "年";
            }
        }

        /// <summary>
        /// 取农历日期表示法：农历一九九七年正月初五
        /// </summary>
        public string ChineseDateString
        {
            get
            {
                if (_cIsLeapMonth)
                {
                    return "农历" + ChineseYearString + "闰" + ChineseMonthString + ChineseDayString;
                }
                else
                {
                    return "农历" + ChineseYearString + ChineseMonthString + ChineseDayString;
                }
            }
        }

        /// <summary>
        /// 定气法计算二十四节气,二十四节气是按地球公转来计算的，并非是阴历计算的
        /// </summary>
        /// <remarks>
        /// 节气的定法有两种。古代历法采用的称为"恒气"，即按时间把一年等分为24份，
        /// 每一节气平均得15天有余，所以又称"平气"。现代农历采用的称为"定气"，即
        /// 按地球在轨道上的位置为标准，一周360°，两节气之间相隔15°。由于冬至时地
        /// 球位于近日点附近，运动速度较快，因而太阳在黄道上移动15°的时间不到15天。
        /// 夏至前后的情况正好相反，太阳在黄道上移动较慢，一个节气达16天之多。采用
        /// 定气时可以保证春、秋两分必然在昼夜平分的那两天。
        /// </remarks>
        public string ChineseTwentyFourDay
        {
            get
            {
                var baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                var tempStr = "";


                y = _date.Year;


                for (var i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + _sTermInfo[i - 1];


                    newDate = baseDateAndTime.AddMinutes(num);//按分钟计算
                    if (newDate.DayOfYear == _date.DayOfYear)
                    {
                        tempStr = _solarTerm[i - 1];
                        break;
                    }
                }
                return tempStr;
            }
        }

        /// <summary>
        /// 当前日期前一个最近节气
        /// </summary>
        public string ChineseTwentyFourPrevDay
        {
            get
            {
                var baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                var tempStr = "";


                y = _date.Year;


                for (var i = 24; i >= 1; i--)
                {
                    num = 525948.76 * (y - 1900) + _sTermInfo[i - 1];


                    newDate = baseDateAndTime.AddMinutes(num);//按分钟计算


                    if (newDate.DayOfYear < _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", _solarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }


                return tempStr;
            }


        }

        /// <summary>
        /// 当前日期后一个最近节气
        /// </summary>
        public string ChineseTwentyFourNextDay
        {
            get
            {
                var baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                var tempStr = "";


                y = _date.Year;


                for (var i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + _sTermInfo[i - 1];


                    newDate = baseDateAndTime.AddMinutes(num);//按分钟计算


                    if (newDate.DayOfYear > _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", _solarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }
                return tempStr;
            }


        }

        #endregion

        #region _星座
        /// <summary>
        /// 计算指定日期的星座序号 
        /// </summary>
        /// <returns></returns>
        public string Constellation
        {
            get
            {
                var index = 0;
                int y, m, d;
                y = _date.Year;
                m = _date.Month;
                d = _date.Day;
                y = m * 100 + d;


                if (((y >= 321) && (y <= 419))) { index = 0; }
                else if ((y >= 420) && (y <= 520)) { index = 1; }
                else if ((y >= 521) && (y <= 620)) { index = 2; }
                else if ((y >= 621) && (y <= 722)) { index = 3; }
                else if ((y >= 723) && (y <= 822)) { index = 4; }
                else if ((y >= 823) && (y <= 922)) { index = 5; }
                else if ((y >= 923) && (y <= 1022)) { index = 6; }
                else if ((y >= 1023) && (y <= 1121)) { index = 7; }
                else if ((y >= 1122) && (y <= 1221)) { index = 8; }
                else if ((y >= 1222) || (y <= 119)) { index = 9; }
                else if ((y >= 120) && (y <= 218)) { index = 10; }
                else if ((y >= 219) && (y <= 320)) { index = 11; }
                else { index = 0; }


                return _constellationName[index];
            }
        }

        #endregion

        #region _属相

        /// <summary>
        /// 计算属相的索引，注意虽然属相是以农历年来区别的，但是目前在实际使用中是按公历来计算的
        /// 鼠年为1,其它类推
        /// </summary>
        public int Animal
        {
            get
            {
                var offset = _date.Year - AnimalStartYear;
                return (offset % 12) + 1;
            }
        }

        /// <summary>
        /// 取属相字符串
        /// </summary>
        public string AnimalString
        {
            get
            {
                var offset = _date.Year - AnimalStartYear; //阳历计算
                //int offset = this._cYear - AnimalStartYear;　农历计算
                return _animalStr[offset % 12].ToString();
            }
        }

        #endregion

        #region _天干地支

        /// <summary>
        /// 取农历年的干支表示法如 乙丑年
        /// </summary>
        public string GanZhiYearString
        {
            get
            {
                var i = (_cYear - GanZhiStartYear) % 60; //计算干支
                var tempStr = _ganStr[i % 10] + _zhiStr[i % 12].ToString();
                return tempStr;
            }
        }

        /// <summary>
        /// 取干支的月表示字符串，注意农历的闰月不记干支
        /// </summary>
        public string GanZhiMonthString
        {
            get
            {
                //每个月的地支总是固定的,而且总是从寅月开始
                int zhiIndex;
                if (_cMonth > 10)
                {
                    zhiIndex = _cMonth - 10;
                }
                else
                {
                    zhiIndex = _cMonth + 2;
                }
                var zhi = _zhiStr[zhiIndex - 1].ToString();

                //根据当年的干支年的干来计算月干的第一个
                var ganIndex = 1;
                string gan;
                var i = (_cYear - GanZhiStartYear) % 60; //计算干支
                switch (i % 10)
                {
                    #region ...
                    case 0: //甲
                        ganIndex = 3;
                        break;
                    case 1: //乙
                        ganIndex = 5;
                        break;
                    case 2: //丙
                        ganIndex = 7;
                        break;
                    case 3: //丁
                        ganIndex = 9;
                        break;
                    case 4: //戊
                        ganIndex = 1;
                        break;
                    case 5: //己
                        ganIndex = 3;
                        break;
                    case 6: //庚
                        ganIndex = 5;
                        break;
                    case 7: //辛
                        ganIndex = 7;
                        break;
                    case 8: //壬
                        ganIndex = 9;
                        break;
                    case 9: //癸
                        ganIndex = 1;
                        break;
                        #endregion
                }
                gan = _ganStr[(ganIndex + _cMonth - 2) % 10].ToString();

                return gan + zhi;
            }
        }

        /// <summary>
        /// 取干支日表示法
        /// </summary>
        public string GanZhiDayString
        {
            get
            {
                int i, offset;
                var ts = _date - _ganZhiStartDay;
                offset = ts.Days;
                i = offset % 60;
                return _ganStr[i % 10] + _zhiStr[i % 12].ToString();
            }
        }

        /// <summary>
        /// 取干支时表示法
        /// </summary>
        public string GanZhiHourString
        {
            get
            {
                var ts = _date - _ganZhiStartDay;
                var offset = ts.Days;
                var i = offset % 60;
                var dayGan = _ganStr[i % 10].ToString();//获取日干
                var hour = _datetime.Hour;//得到当前小时
                if (hour % 2 != 0) hour = hour + 1;
                var j = (hour / 2) % 12;//得到时辰
                if (dayGan == "甲" || dayGan == "己")
                    return JiaZhi[j];
                if (dayGan == "乙" || dayGan == "庚")
                    return JiaZhi[j + 12];
                if (dayGan == "丙" || dayGan == "辛")
                    return JiaZhi[j + 24];
                if (dayGan == "丁" || dayGan == "壬")
                    return JiaZhi[j + 36];
                if (dayGan == "戊" || dayGan == "癸")
                    return JiaZhi[j + 48];
                return "错误";
            }
        }

        /// <summary>
        /// 取当前日期的干支表示法如 甲子年乙丑月丙庚日
        /// </summary>
        public string GanZhiDateString
        {
            get
            {
                return GanZhiYearString + " " + GanZhiMonthString + " " + GanZhiDayString + " " + GanZhiHourString;
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 取下一天
        /// </summary>
        /// <returns></returns>
        public ChineseCalendar NextDay()
        {
            var nextDay = _date.AddDays(1);
            return new ChineseCalendar(nextDay);
        }

        /// <summary>
        /// 取前一天
        /// </summary>
        /// <returns></returns>
        public ChineseCalendar PervDay()
        {
            var pervDay = _date.AddDays(-1);
            return new ChineseCalendar(pervDay);
        }

        #endregion

    }

}