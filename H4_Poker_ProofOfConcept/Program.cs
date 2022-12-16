User user = new User();
string PokerType = "TexasHoldEm";

//User is logging into system with username from frontend
user.Login("Ben Dover");

int roomId = 5;
//User picks a game to join
user.JoinRoom(roomId);


