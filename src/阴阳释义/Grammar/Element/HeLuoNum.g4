grammar HeLuoNum;

/*
 * Parser Rules
 */

result
	:	HeLuoNum '对应' ('天干'|'地支'|'五行')	# HeLuoNumMap
	;

/*
 * Lexer Rules
 */

HeLuoNum
	:	'0'..'9'
	;
