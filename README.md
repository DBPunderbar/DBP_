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
2021.12.01. 19:23 frinedsPage가 사용자 정의 컨트롤인데 이것 또한 컨트롤이니까 mainForm 디자인에서 추가가 가능함 => 이럴 경우 생성자를 Designer에서 만들어주는데,(button 처럼) 이럴 경우 생성자에 어떤 파라미터도 넣지 못함. (만약 넣을 경우 main폼 디자인이 안열리면서 designer오류가 뜸)   
그래서 발상이 얘도 컨트롤이니까 동적생성으로 만들어 버리자. 여서 mainform디자인에서 컨트롤 추가를 하지 않고 객체를 동적으로 생성함.(친구버튼을 눌렀을 때 이벤트 핸들러에서) 그래서 이때 userID를 파라미터로 넘겨주고 friendsPage는 userID를 받아와서 목록을 보여줌. (아직 그룹박스 사이즈 등은 다시 맞춰야함)   
이 부분에서 따로 함수로 빼서 mainform이 불러와질때 자동으로 친구목록을 볼 수 있도록(굳이 친구 버튼을 클릭하지 않고) mainform 생성자에 넣어주려 했으나 그럴 경우 친구 버튼을 눌렀을 때 이벤트 핸들러에서 friendsPage1.BringToFront()에서 오류가 뜸(객체가 없어서)   
==> 그래서 버튼 클릭 핸들러에서 객체 생성을 하고, 대신 form Load 이벤트(폼이 로드될 때)를 버튼 클릭 핸들러로 연결해줘서 mainform이 실행될 때 친구 버튼 눌렀을 때 이벤트가 실행되도록 함(buttonClick 이벤트 핸들러 주석 참고)   
