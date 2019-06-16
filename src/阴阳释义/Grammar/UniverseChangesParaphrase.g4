grammar UniverseChangesParaphrase;

// ------------------------------------------------------------
// Parser Rules 语法规则
// ------------------------------------------------------------

 program
	:	expression
	;

expression 
	:	'(' expression ')'							# Parenthesis
	|	expression '为' expression					# As
	|	expression '对应' expression				# Map
	|	TwelveGrowthProcess							# TwelveGrowthProcess
	|	SexagesimalSkyTrunkAndEarthBranch			# SexagesimalSkyTrunkAndEarthBranch
	|	EarthBranch									# EarthBranch
	|	SkyTrunk									# SkyTrunk
	|	FiveAttribute								# FiveAttribute
	|	DarkAndLight								# DarkAndLight
	|	TheInitialDigit								# TheInitialDigit
	;

compileUnit
	:	EOF
	;

// ------------------------------------------------------------
// Lexer Rules 词法规则
// ------------------------------------------------------------

// ------------------------------
// 运算符
// ------------------------------
MAP			:		'对应';		// 一个原子项映射为另一个原子项
AS			:		'为';		// 取得此原子项内部属性，例如：甲为木，甲为阳，因为甲既有阳又有木这两个属性
AT			:		'在';		// 
ASSIGN		:		'配';		// 为两个原子项组合成一个合并原子项

// ------------------------------
// 原子项
// ------------------------------

Name
	: (NameStart) (NameChar)*
	;

TwelveGrowthProcess
	:	('长生'|'沐浴'|'冠带'|'临官'|'帝旺'|'衰'|'病'|'死'|'墓'|'绝'|'胎'|'养')
	;

SexagesimalSkyTrunkAndEarthBranch
	:	'甲'('子'|'戌'|'申'|'午'|'辰'|'寅')
	|	'乙'('丑'|'亥'|'酉'|'未'|'巳'|'卯')
	|	'丙'('寅'|'子'|'戌'|'申'|'午'|'辰')
	|	'丁'('卯'|'丑'|'亥'|'酉'|'未'|'巳')
	|	'戊'('辰'|'寅'|'子'|'戌'|'申'|'午')
	|	'己'('巳'|'卯'|'丑'|'亥'|'酉'|'未')
	|	'庚'('午'|'辰'|'寅'|'子'|'戌'|'申')
	|	'辛'('未'|'巳'|'卯'|'丑'|'亥'|'酉')
	|	'壬'('申'|'午'|'辰'|'寅'|'子'|'戌')
	|	'癸'('酉'|'未'|'巳'|'卯'|'丑'|'亥')
	;

EarthBranch
	:	('子'|'丑'|'寅'|'卯'|'辰'|'巳'|'午'|'未'|'申'|'酉'|'戌'|'亥')
	;

SkyTrunk
	:	('甲'|'乙'|'丙'|'丁'|'戊'|'己'|'庚'|'辛'|'壬'|'癸')
	;

FiveAttribute
	:	('金'|'木'|'水'|'火'|'土')
	;

DarkAndLight
	:	('阴'|'阳')
	;

TheInitialDigit
	:	Digit
	;

// 空行
WS	:	[ \t\r\n]+ -> skip
	; 

// 多行注释
COMMENT
	:	'/*' .*? '*/' -> channel(HIDDEN)
	;

// 单行注释
LINE_COMMENT
	:	'//' ~[\r\n]* -> skip
    ;

// ------------------------------
// 片段
// ------------------------------

// 名称单字
fragment NameChar
	: (NameStart)
	| Digit
	;

// 名称字首
fragment NameStart
	: '_'
	| Character
	// | UniversalAlpha
	;

// 单数
fragment Digit
	: '0'..'9'
	;

// 单字
fragment Character
	:	'a'..'z'
	|	'A'..'Z'
	|	'\u4E00'..'\u9FA5'
	|	'\uF900'..'\uFA2D'
	;
