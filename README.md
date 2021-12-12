# Real_Modal.test

2021.11.15. 10:45 방준하님의 커밋 시점   
2021.11.15. 10.46 김서지님의 테이블 변경 -> Column friendsID를 삭제하고 friends table(userID, friendID)로 전환   
2021.11.15. 10.51 백지승님의 자동 로그인 수정   
2021.11.17.  16:59 김서지님의 변경사항   
      textbox1 삭제(중간에 큰~~ 텍스트박스, groupbox가 줄줄이 나오는 형식이라 textbox는 필요없음)

      친구 버튼 이벤트 핸들러 등록, 친구 테이블이 따로 DB에 생성되었으니까 따로 수정 필요

      로그인 창의 텍스트 박스가 change될 때마다 ID를 저장할 수 있도록
      (로그인)모달 폼에서 getUserID() 함수를 만들어 return가능, 만약 textbox가 바뀌지 않았다면(작성된 게 아무것도 없다면) "입력없음"이 반환

      mainform에서는 userID를 전역변수로 만들어 로그인 모달창이 띄워진 후에 getUserID()로 모달폼에서 얻어옴(모달폼 객체가 생성된 곳에서 얻어올 수 있음)

2021.11.17. 20:25 김지현님의 변경사항
      ( 로그인 창 분리, 회원가입 UI 절반 완성
      !! 앞으로 각각 파트 맡으신 부분, 친구분들은 FriendsPage 채팅분들은 MessagesPage 에서 그대로 작업하시면 됩니다.
      아마 MainForm 에서는 이제 특별한 사항 아니고서야 건들일 일 없을 거라 생각됩니다. !! )

2021.11.22. 13:11 김지현님의 mouve 수정   
2021.11.27. 22:28 김서지님의 디자인 폼 안뜨는 오류 수정, 자동 로그인 완성(?)   
2021.12.01. 19:23 김서지님   

    frinedsPage가 사용자 정의 컨트롤인데 이것 또한 컨트롤이니까 mainForm 디자인에서 추가가 가능함 => 이럴 경우 생성자를 Designer에서 만들어주는데,(button 처럼) 이럴 경우 생성자에 어떤 파라미터도 넣지 못함. (만약 넣을 경우 main폼 디자인이 안열리면서 designer오류가 뜸, 우리는 userID를 생성자 파라미터로 보내줘야함)   
    
    그래서 발상이 얘도 컨트롤이니까 동적생성으로 만들어 버리자. 여서 mainform디자인에서 컨트롤 추가를 하지 않고 객체를 동적으로 생성함.(친구버튼을 눌렀을 때 이벤트 핸들러에서) 그래서 이때 userID를 파라미터로 넘겨주고 friendsPage는 userID를 받아와서 목록을 보여줌. (아직 그룹박스 사이즈 등은 다시 맞춰야함)   
    
    이 부분에서 따로 함수로 빼서 mainform이 불러와질때 자동으로 친구목록을 볼 수 있도록(굳이 친구 버튼을 클릭하지 않고) mainform 생성자에 넣어주려 했으나 그럴 경우 친구 버튼을 눌렀을 때 이벤트 핸들러에서 friendsPage1.BringToFront()에서 오류가 뜸(객체가 없어서)   
    ==> 그래서 버튼 클릭 핸들러에서 객체 생성을 하고, 대신 form Load 이벤트(폼이 로드될 때)를 버튼 클릭 핸들러로 연결해줘서 mainform이 실행될 때 친구 버튼 눌렀을 때 이벤트가 실행되도록 함(buttonClick 이벤트 핸들러 주석 참고)   
    
    +) Read() 전에 접근하는게 잘못됐다는 오류가 자꾸 떠서 DBmanager로 바꿈   
    
    +) 프로필을 누르면 프로필이 뜨고, 오른편에 친구의 친구가 뜸(본인 프로필을 누르면 본인 친구가 뜸)/ 친구의 친구목록에서 친구를 누르면 또 프로필이 뜨는것 가능   

아 맞다 지금 정보들 암호화 다 해놔서 어떤 아이디로도 login 가능   
2021.12.03. 00:28 김서지님 role + nickname에서 role이 길면 nickname을 침범해서 이 부분을 상대적으로(?) 바꿔놨음, 그룹박스 우클릭시 삭제한 후에 새로고침 할 때 원래는 본인 프로필까지 모든 그룹박스를 form에서 삭제하고 다시 불러오는 거였지만 본인 프로필은 남기게 해둠 ==> 그룹박스 삭제하고 친구프로필만 불러오면 됨   
2021.11.27. 18:03 김지현님의 UI 수정(채팅폼, 친구추가폼 추가 / 전반적 디자인 조금씩 수정)   
2021.12.08. 16:45 김서지 : addInfo에서 회원가입 후 로그인화면이 뜨는게 아니라 바로 mainform으로 이동하게 해놓음, 친구목록에서 친구 검색기능 추가, 더블클릭/클릭 구분 완료, 친구 프로필에서 '[position] nickname' label을 두개로 분리   
2021.12.10. 17:32 김서지 : 친구 테이블에 'tome'라는 없는 계정이 들어갈 것을 대비해 널처리 등록, 회원가입시 자동으로 ToMe와 친구맺기, 현재 doya, jihyeonGOD, 208ehd 계정은 모두 ToMe와 친구중, 정보 수정 창에 기존의 정보가 불러와지도록 수정(아 프로필사진 불러오는건 까먹었다) 그리고 addr도.., friends에서 SELECT할때 이제 ToMe가 항상 들어가있어서 그거 전처리 해주세요!   

2021.12.10 21:20 백지승 : 서버 연동, 채팅 기능, 이모티콘 리소스 등록 / 메시지 페이지 더블 클릭 이벤트 추가, 알림 수정 필요   
2021.12.10. 23:36 김서지 : 더블클릭

2021.12.11 01:37 조성민 : tcp upload 성공 [zip] 관련 채팅 처리 필요   
2021-12.11 01:42 백지승 : 알림 추가('아주 약간' 수정 필요)    
2021-12.11 01:55 백지승 : '아주 약간' 수정 완료   
2021-12.11 03:07 김지현 : 이것저것(ui, 채팅 말풍선, 다크모드 DB불러와서 적용)수정   
2021-12.11 03:25 백지승 : 일부 수정 후 다시 푸시(메시지페이지 friendName label 수정 필요)   

2021-12.12 12:48 백지승 : 이모티콘 동적 생성 + 메시지 페이지 클릭 이벤트 오류 수정? (+ 12:55 : 오타 수정)   
2021-12.12 14:36 백지승 : 친구 검색 오류 수정, friendName.Location 아래로 뺌

2021-12.12 14:45 김지현 : 정보수정 버튼 추가, placeholder 수정, '사용되지 않은 ...' 오류 수정
