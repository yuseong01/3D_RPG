# 🛡️ Unity RPG Project - YUSEONG

이 프로젝트는 Unity 기반의 3D 방치형 RPG 게임입니다.  
FSM 기반의 전투 시스템, 플레이어 & 적AI, 인벤토리 & 장비 UI, 플레이어 스탯 관리, Cinemachine 카메라, 그리고 UI 인터페이스를 구현하였습니다.

---

## 🎮 주요 기능

### ✅ Player 시스템
- 상태(StateMachine) 기반 이동 및 공격 FSM
- AI Navigation 시스템 (NavMeshAgent 기반 경로 탐색)
- 스탯 관리 (`HP`, `공격력`, `속도`, `공격/감지 범위`)
- 장비 착용/해제 기능 (`무기`, `악세서리`)
- 소비 아이템 사용 시 스탯 증가
<img width="774" alt="스크린샷 2025-06-11 오후 12 33 08" src="https://github.com/user-attachments/assets/864694e4-3bf3-4491-abb5-bcd470a5372d" />

### ✅ Enemy 시스템
- 상태(StateMachine) 기반 이동 및 공격 FSM
- AI Navigation 시스템 (NavMeshAgent 기반 경로 탐색)
  <img width="709" alt="스크린샷 2025-06-11 오후 12 34 23" src="https://github.com/user-attachments/assets/653007ff-c9ed-4c54-8044-28c33e1d7cc9" />

### ✅ UI 시스템
- 메인 메뉴 UI: 닉네임, 레벨, 설명, 체력 바, 골드 텍스트, 인벤토리 및 상태창 버튼 표시
  <img width="737" alt="스크린샷 2025-06-11 오후 12 48 08" src="https://github.com/user-attachments/assets/0a7f52ed-0980-4056-bd1b-9f8928819fae" />

- 인벤토리 UI: 장비/소비 아이템 리스트 + 장착 여부 테두리 표시
  <img width="742" alt="스크린샷 2025-06-11 오후 12 41 26" src="https://github.com/user-attachments/assets/5270c008-9c18-41cc-94e8-d4e53b2abef3" />
  <img width="743" alt="스크린샷 2025-06-11 오후 12 41 42" src="https://github.com/user-attachments/assets/826868b9-eada-47b0-95d2-85a3e8d2b125" />
----------------
+ Consumable 아이템은 사용시 사라짐
<img width="148" alt="스크린샷 2025-06-11 오후 12 42 00" src="https://github.com/user-attachments/assets/cbc94fde-db0f-4d14-ad48-b6508f42f43e" />
<img width="145" alt="스크린샷 2025-06-11 오후 12 42 09" src="https://github.com/user-attachments/assets/cd789c22-bb47-4980-bcca-fe6addea36b3" />

- 상태창 UI: 기본 스탯 + 보너스 스탯 `(ex. 탐지거리 5 (+3))`
  <img width="741" alt="image" src="https://github.com/user-attachments/assets/1bce8ad1-4b54-44c3-93d9-e63cb1358e9e" />
  <img width="742" alt="스크린샷 2025-06-11 오후 12 43 01" src="https://github.com/user-attachments/assets/a3274c5f-3ce9-41c8-bf9f-03216c0bcd70" />

- GameOver UI: 종료시 Restart버튼과 함께 표시
  <img width="742" alt="스크린샷 2025-06-11 오후 12 43 57" src="https://github.com/user-attachments/assets/949263b0-9392-4061-99ad-f26db4be8a38" />


### ✅ 인벤토리 & 아이템
- `ScriptableObject` 기반 아이템 관리
- 아이템 타입: `무기`, `악세서리`, `소비 아이템`
- 장비 시 스탯 증가, 소비 시 효과 적용 후 제거
--------
<img width="346" alt="스크린샷 2025-06-11 오후 12 44 19" src="https://github.com/user-attachments/assets/049cf9ea-c47c-4305-a2ad-85cc8b1778c3" />

### ✅ 게임플레이
- 적 처치 시 10 골드 획득
<img width="735" alt="스크린샷 2025-06-11 오후 12 44 59" src="https://github.com/user-attachments/assets/3c27048a-4474-4c7c-9262-b177a9798d01" />

- 플레이어 사망 시 "Game Over" UI 표시
- `Restart` 버튼으로 재시작 가능

---

## 🔧 기술 스택

- Unity 2022.3.17f1
- C#
- TextMeshPro
- Cinemachine
- NavMeshAgent
- ScriptableObject
- Custom FSM 구조

---

🧑‍💻 제작자
YUSEONG
Contact: dog2655@naver.com
