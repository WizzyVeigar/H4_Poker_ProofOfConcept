User user = new User("Ben Dover");

//User is logging into system with username from frontend
user.Login(user.Username);
//user.Login("Mike Litoris");

int roomId = 5;
//User picks a game to join
user.JoinRoom(roomId);


