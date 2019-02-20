using NUnit.Framework;
using ServerType;

namespace RoomsTest
{
    public class Tests
    {
        private Server myRooms;

        [SetUp]
        public void Setup()
        {
            myRooms = new Server();
        }

        [Test]
        public void ConstructorCalled()
        {
            Assert.IsInstanceOf<Server>(myRooms, "Not a Rooms object");
        }

        [Test]
        public void UserCreated()
        {
            string name = "FosJak";
            myRooms.createUser(name);

            Assert.AreEqual(name, myRooms.getUser(name).getName());
        }

        [Test]
        public void ChatRoomCreated()
        {
            string name = "FosJak's Chat Room";
            myRooms.createChatRoom(name);

            Assert.AreEqual(name, myRooms.getChatRoom(name).getName());
        }
    }
}