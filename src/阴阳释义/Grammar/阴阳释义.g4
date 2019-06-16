grammar 阴阳释义;

// ------------------------------------------------------------
// Parser Rules 语法规则
// ------------------------------------------------------------

options {
	language=CSharp;
}

program
	:	statement+ compileUnit
	;

statement
	:	declareExpression
	|	expression
	;

// ------------------------------
// expression
// ------------------------------

declareExpression
	: basicType declarators
	;

expression
	:	calculateExpression
	;

calculateExpression
	:	mapExpression
	|	asExpression
	|	atExpression
	|	fiveAttributeRelationshipExpression
	;

// ------------------------------
// 计算表达式
// ------------------------------

fiveAttributeRelationshipExpression
	:	FiveAttribute ('生' | '克' | '制' | '化' | '刑' | '冲' | '合' | '害' ) FiveAttribute
	|	fiveAttributeRelationshipExpression ('生' | '克' | '制' | '化' | '刑' | '冲' | '合' | '害' ) FiveAttribute
	;

atExpression
	:	FiveAttribute TwelveGrowthProcess '在' EarthBranch
	;

asExpression
	:	SkyTrunk '为' LunarAndSolar
	|	SkyTrunk '为' FiveAttribute
	|	EarthBranch '为' LunarAndSolar
	|	EarthBranch '为' FiveAttribute
	;

mapExpression
	:	OriginDigit '对应' SkyTrunk
	|	OriginDigit '对应' EarthBranch
	|	OriginDigit '对应' FiveAttribute
	|	assignExpression '对应' SexagesimalSkyTrunkAndEarthBranch
	;

assignExpression
	:	SkyTrunk '配' EarthBranch
	;

// ------------------------------
// 定义
// ------------------------------

basicType
	:	'河洛数'
	|	'五行'
	|	'天干'
	|	'地支'
	|	'var'
	;

declarators
	:	assign (',' assign)*
	;

assign
	:	Name '=' expression
	;

// ------------------------------
// 结束符
// ------------------------------

compileUnit
	:	EOF
	;

// ------------------------------------------------------------
// Lexer Rules 词法规则
// ------------------------------------------------------------

// ------------------------------
// 原子项
// ------------------------------

// 名称
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

LunarAndSolar
	:	('阴'|'阳')
	;

OriginDigit
	:	Digit
	;

// ------------------------------
// 运算符
// ------------------------------

MAP			:		'对应';		// 一个原子项映射为另一个原子项
AS			:		'为';		// 取得此原子项内部属性，例如：甲为木，甲为阳，因为甲既有阳又有木这两个属性
AT			:		'在';		// 
ASSIGN		:		'配';		// 为两个原子项组合成一个合并原子项

FiveAttributeRelationship
	:	('生'|'克'|'制'|'化'|'刑'|'冲'|'合'|'害')
	;

WS
	:	' ' -> channel(HIDDEN)
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

fragment NameChar
	: (NameStart)
	| '0'
	| NonZeroDigit
	;

fragment NonZeroDigit
	: '1'..'9'
	;

fragment Digit
	: '0'..'9'
	;

fragment NameStart
	: '_'
	| Letter
	// | UniversalAlpha
	;

fragment Letter
	:	'a'..'z'
	|	'A'..'Z'
	|	'\u4E00'..'\u9FA5'
	|	'\uF900'..'\uFA2D'
	;
