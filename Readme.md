# Namespace / Variable
- 사용자 정의 변수가 없이, 지정된 변수만 사용할 수 있습니다.
- X::Y::Z 형식으로 구조화된 변수와 특수변수 시발이 있습니다.

X::Y::Z 구성은 다음과같습니다.

X = 우리, 상대
Y = 탑,정글, 미드, 서폿, 봇
Z = 딜량, CS, 레벨, 킬, 데스, 어시

X::Y::Z 변수를 사용하기위해서는 space 로 분리하여 사용합니다
예)
`우리 탑 딜량`
`상대 미드 어시`

# 초기화
`실화냐?` : {Varialbe} {Value} 실화냐? 로 초기화 합니다
예) `우리 정글 딜량 15 실화냐?`

- 조건문은 `실화냐?` 로 끝나기 때문에 조건문의 {condition} 에서는 초기화가 불가능합니다

단 특수 변수 `시발`은 아래와 같이 초기화 합니다
- `{variable} 시발` : 시발의 값을 {variable} 로 초기화합니다.
예) 

```
우리 정글 딜량 시발
시발 너네는 지는게 맞다
```

# 조건문
`근데 진짜 {condition} 실화냐?` : IF 문의 시작입니다.
`근데 아니 {condition} 실화냐?` : IF not 문의 시작입니다.
`아니 근데 {condition} 실화냐?` : IF not 문의 시작입니다.
`답이 없네` : BREAK 문으로 조건문을 빠저나갑니다.

조건문을 사용하게되면 해당 조건문에 해당하는 식은 Depth가 한단계 늘어납니다. Depth 는 스페이스바로 구분합니다.

예)
```
근데 진짜 우리 정글 딜량 15 실화냐?
 상대 미드 정글 딜량 5 실화냐?
 답이없네
```

# Property
`다해도`  : sum Property
- {X} {Z} 다해도 
예) `우리 딜량 다해도` - 우리::Y:딜량 을 전부 더한 값

`차이` : - Property
- {X::Y::Z} 차이 : {X::Y::Z} - {다른X::Y::Z} 차이 값
예) `우리 정글 딜량 차이` : 우리::정글::딜량 - 상대::정글::딜량
예) `상대 정글 딜량 차이` : 상대::정글::딜량 - 우리::정글::딜량
