using NUnit.Framework;
using Server;
using System.Collections.Generic;

namespace RoomsTest
{
    public class Tests
    {
        private Server.Server myServer;

        [SetUp]
        public void Setup()
        {
            myServer = new Server.Server();
        }

        [Test]
        public void ConstructorCalled()
        {
            Assert.IsInstanceOf<Server.Server>(myServer, "Not a Rooms object");
        }

        [Test]
        public void ChatRoomCreated()
        {
            string name = "FosJak's Chat Room";
            myServer.createChatRoom(name);

            Assert.AreEqual(name, myServer.getChatRoom(name).getName());
        }

        [Test]
        public void ChatRoomCreatedAndUserAdded()
        {
            string userName = "FosJak";
            string chatRoomName = "FosJak's Chat Room";

            myServer.createChatRoom(chatRoomName);
            ChatRoom myChat = myServer.getChatRoom(chatRoomName);
            User myUser = new User(userName);
            myChat.addUser(myUser);

            Assert.AreEqual(myServer.getChatRoom(chatRoomName).getUser(userName).getName(), userName);
        }

        [Test]
        public void ChatRoomCreatedAndUserAddedThenDeleted()
        {
            string userName = "FosJak";
            string chatRoomName = "FosJak's Chat Room";

            myServer.createChatRoom(chatRoomName);
            ChatRoom myChat = myServer.getChatRoom(chatRoomName);
            User myUser = new User(userName);
            myChat.addUser(myUser);

            Assert.AreEqual(myServer.getChatRoom(chatRoomName).getUser(userName).getName(), userName);
        }

        [Test]
        public void ChatRoomCreatedAndUserAddedFail()
        {
            string userName = "FosJak";
            string chatRoomName = "FosJak's Chat Room";

            myServer.createChatRoom(chatRoomName);
            ChatRoom myChat = myServer.getChatRoom(chatRoomName);
            User myUser = new User(userName);
            myChat.addUser(myUser);

            Assert.IsFalse(myChat.addUser(myUser));
        }

        [Test]
        public void ChatRoomCreatedFail()
        {
            string name = "FosJak's Chat Room";
            myServer.createChatRoom(name);

            Assert.IsFalse(myServer.createChatRoom(name));
        }

        [Test]
        public void CreateAndRetrieveAMessage()
        {
            string userName = "FosJak";
            string chatRoomName = "FosJak's Chat Room";
            string message = "Hello World!";
            string expected = userName + ": " + message;

            myServer.createChatRoom(chatRoomName);
            ChatRoom myChat = myServer.getChatRoom(chatRoomName);
            User myUser = new User(userName);
            myChat.addUser(myUser);
            myUser.addMessageToChat(message);

            List<Message> myMessages = myChat.getMessageList();

            Assert.AreEqual(expected, myMessages[myMessages.Count - 1].toString());
        }

        [Test]
        public void CreateAndRetrieveAMessage100Xs()
        {
            string userName1 = "FosJak";
            string userName2 = "JakFos";
            string chatRoomName = "FosJak's Chat Room";
            string expected = userName1 + ": This is chat room message number 100";

            myServer.createChatRoom(chatRoomName);
            ChatRoom myChat = myServer.getChatRoom(chatRoomName);
            User FosJak = new User(userName1);
            User JakFos = new User(userName2);
            myChat.addUser(FosJak);
            myChat.addUser(JakFos);

            string message;
            for (int i = 1; i <= 100; i++)
            {
                message = "This is chat room message number " + i;

                if (i % 2 == 0)
                    FosJak.addMessageToChat(message);
                else
                    JakFos.addMessageToChat(message);
            }

            List<Message> myMessages = myChat.getMessageList();

            Assert.AreEqual(expected, myMessages[myMessages.Count - 1].toString());
        }

        [Test]
        public void CreateUsersThenDeleteUsers()
        {
            string userName1 = "FosJak";
            string userName2 = "JakFos";
            string chatRoomName = "FosJak's Chat Room";
            string expected = userName1 + ": This is chat room message number 100";

            if (!myServer.createChatRoom(chatRoomName))
                Assert.Fail();
            if(!myServer.addUser(userName1))
                Assert.Fail();
            if(!myServer.addUser(userName2))
                Assert.Fail();

            if (!myServer.connectUserToRoom(myServer.getUser(userName1), myServer.getChatRoom(chatRoomName)))
                Assert.Fail();
            if (!myServer.connectUserToRoom(myServer.getUser(userName2), myServer.getChatRoom(chatRoomName)))
                Assert.Fail();

            if(!myServer.removeUser(myServer.getUser(userName1)))
                Assert.Fail();
            if (!myServer.removeUser(myServer.getUser(userName2)))
                Assert.Fail();

            if (myServer.getNumUsers() != 0)
                Assert.Fail();

            if (!myServer.removeChatRoom(myServer.getChatRoom(chatRoomName)))
                Assert.Fail();

            if (myServer.getNumChats() != 0)
                Assert.Fail();

            Assert.Pass();
        }
    }
}