# LolChatLang
LolChatLang (LOLCHatlANG / 롤챙 으로 발음) 은 정수 계산에 딱히 최적화 되지 않은 프로그래밍 언어로 친숙한 자연어 구문을 이용하여 프로그램을 작성 할 수 있습니다.


# Spec
## Value
Value 의 경우 정수형 자료형만 사용 가능합니다

예) `5`, `10`

## Namespace / Variable / Properties
### Namespace / Variable
사용자 정의 변수가 없이, 지정된 변수만 사용할 수 있습니다.

X::Y::Z 형식으로 구조화된 변수와 특수변수 시발이 있습니다.

X::Y::Z 구성은 다음과같습니다.

- X = 우리, 상대

- Y = 탑,정글, 미드, 서폿, 봇

- Z = 딜량, CS, 레벨, 킬, 데스, 어시

X::Y::Z 변수를 사용하기위해서는 space 로 분리하여 사용합니다

예) `우리 탑 딜량`,  `상대 미드 어시`


모든 변수는 기본값 0을 가지고있습니다.

---------------------------------------
### Print
변수 출력은 `보소` 또는 `봐라` 구문을 이용하여 출력합니다.

예) `우리 탑 딜량 봐라`

---------------------------------------
### Properties
값 할당은 불가능 하지만 조건문 혹은 출력을 위한 Properties 가 존재합니다

`다해도` 는 `{X} {Z} 다해도` 구문으로 모든 Y 에 대한 합을 반환합니다.

예) `우리 딜량 다해도` - 우리::Y:딜량 을 전부 더한 값

---------------------------------------

`차이` 는 `{X::Y::Z}차이` 구문으로 {X::Y::Z} - {다른X::Y::Z} 값을 반환합니다

예) `우리 정글 딜량차이` : 우리::정글::딜량 - 상대::정글::딜량

예) `상대 정글 딜량차이` : 상대::정글::딜량 - 우리::정글::딜량

### Operator
오직 {X::Y::데스} 변수에 대하여 1을 더하는 연산자만 가능합니다.

`{X::Y::데스} 솔킬 따이네` 로 {X::Y::데스} 값을 1 상승시킵니다.

음수 값에 대한 Operator 를 사용하고 싶은 경우, ` 솔킬 따이네` 연산으로 더하기 1을 얻고 이에 대한 `차이` 프로퍼티를 사용하여야 합니다

예)
```
우리 탑 솔킬 따이네
근데 진짜 우리 탑 데스차이 1 실화냐?
 답이없네
근데 진짜 상대 탑 데스차이 -1 실화냐?
 답이없네
```

## 초기화
`실화냐?` 구문을 이용하여 변수를 초기화 합니다

`{varialbe} {value} 실화냐?` 로 초기화 합니다

예) `우리 정글 딜량 15 실화냐?`

단 특수 변수 `시발`은 아래와 같이 초기화 합니다

`{variable|properties} 시발` : 시발의 값을 {variable} 또는 {properties} 과 동일한 값으로 초기화 합니다

예) `우리 탑 딜량 시발`, `우리 데스 다해도 시발`

## 반환
`{variable} 니네는 지는게 맞다` 구문으로 `{variable}` 값을 최종적으로 반환합니다.

`시발` 변수를 사용하는것을 추천합니다

예)
```
우리 정글 딜량 시발
시발 니네는 지는게 맞다
```

# 조건문
조건문을 위한 구문은 아래와 같습니다

- `근데 진짜 {variable|properties} {value} 실화냐?` : IF 문의 시작입니다.  {variable|properties} == {value} 인 경우 Body 가 실행됩니다.
- `근데 아니 {variable|properties} {value} 실화냐?` : IF not 문의 시작입니다. {variable|properties} != {value} 인 경우 Body 가 실행됩니다.
- `아니 근데 {variable|properties} {value} 실화냐?` : IF not 문의 시작입니다. {variable|properties} != {value} 인 경우 Body 가 실행됩니다.
- `답이 없네` : BREAK 문으로 조건문을 빠저나갑니다.

조건문을 사용하게되면 해당 조건문에 해당하는 식은 Depth가 한단계 늘어납니다. Depth 는 스페이스바로 구분합니다.

예)
```
근데 진짜 우리 정글 딜량 15 실화냐?
 상대 미드 정글 딜량 5 실화냐?
 답이없네
```

## Flow Control
`ㅅㄱ 던짐 {line} 서렌 ㄱㄱ` 구문을 통하여 해당 line 가는 GOTO 문을 지원합니다.

제약 조건으로는 {line} 번째 의 Line 의 경우 Depth 가 0 이어 야 합니다. 또한 line 은 0번 부터 시작합니다

예) `ㅅㄱ 던짐 7 서렌 ㄱㄱ`

Spcial Form 으로 18/28 번째 라인으로 가는  GOTO 문은 아래와 같이 작성할수있습니다
- `18 년아 라인 쳐 가라고`
- `28 년아 라인 쳐 가라고`

반복문이 지원되지 않지만, GOTO 문으로 반복문을 구현 할 수 있습니다.

## Reflection
`@ㅐ미` `@ㅐ비` 구문을 통한 리플렉션 기능을 지원합니다.

`@ㅐ미 {variable}` : {variable} 에 대한 {X::Y::Z} 값을 출력합니다

`@ㅐ비 {variable}` : {variable} 에 대한 값 변경 히스토리를 출력합니다

예)
```
상대 탑 데스 20 실화냐?
@ㅐ미 상대 탑 데스
@ㅐ비 상대 탑 데스
``` 
위 코드의 결과는 다음과 같습니다
```
"상대::탑::데스"
[20; 0]
```

## 주석
주석 기능은 존재하지 않습니다.

다만 인터프리터를 대충 만들어서 구문오류가 나면 그냥 아무것도 하지 않기때문에, 파싱안되는 모든 구문이  주석입니다.

그냥 Line 을 따와서 수동 파싱했으므로 구문 뒤에 주석을 달수 없습니다.

예)

`소환사의 협곡에 오신것을 환엽합니다` 는 아무 구문과 파싱되지 않으므로 무시됩니다.

`아니 근데 우리 탑 데스 5 실화냐?` 는 파싱이 되어 구문인식이 되지만  `아니 근데 우리 탑 데스 5 실화냐? // 검사` 는 파싱 되지 않아 무시됩니다.

---------------------------------------

## 예시 코드 및 결과
```
소환사의 협곡에 오신것을 환엽합니다

우리 미드 데스 1 실화냐?
우리 정글 데스 10 실화냐?
우리 탑 데스 1 실화냐?
상대 탑 데스 20 실화냐?

아니 근데 우리 탑 데스 5 실화냐?
 우리 탑 솔킬 따이네
 @ㅐ미 우리 탑 데스
 우리 탑 데스 보소
 @ㅐ비 우리 탑 데스
 ㅅㄱ 던짐 7 서렌 ㄱㄱ

근데 진짜 우리 탑 데스차이 -15 실화냐?
 @ㅐ미 상대 탑 데스
 @ㅐ비 상대 탑 데스
 답이없네
 @ㅐ미 상대 미드 데스


우리 미드 데스 보소
우리 정글 데스 보소
우리 탑 데스 보소
우리 데스 다해도 시발
시발 보소
시발 니네는 지는게 맞다
```

콘솔 출력
```
"우리::탑::데스"
2
[2; 1; 0]
"우리::탑::데스"
3
[3; 2; 1; 0]
"우리::탑::데스"
4
[4; 3; 2; 1; 0]
"우리::탑::데스"
5
[5; 4; 3; 2; 1; 0]
"상대::탑::데스"
[20; 0]
1
10
5
16
```

프로그램 반환값 16


