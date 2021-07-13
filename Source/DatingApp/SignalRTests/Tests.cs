
using Microsoft.AspNet.SignalR.Hubs;
using Moq;
using System;
using System.Dynamic;
using Xunit;

namespace SignalRTests
{
    public class Tests
    {
        [Fact]
        public void HubsAreMockableViaDynamic()
        {
            bool sendCalled = false;
            var hub = new ChatHub();
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = mockClients.Object;
            dynamic all = new ExpandoObject();
            all.broadcastMessage = new Action<string, string>((name, message) => {
                sendCalled = true;
            });
            mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
            hub.Send("TestUser", "TestMessage");
            Assert.True(sendCalled);
        }

        public interface IClientContract
        {
            void broadcastMessage(string name, string message);
        }
        [Fact]
        public void HubsAreMockableViaType()
        {
            var hub = new ChatHub();
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            var all = new Mock<IClientContract>();
            hub.Clients = mockClients.Object;
            all.Setup(m => m.broadcastMessage(It.IsAny<string>(),
                 It.IsAny<string>())).Verifiable();
            mockClients.Setup(m => m.All).Returns(all.Object);
            hub.Send("TestUser", "TestMessage");
            all.VerifyAll();
        }
    }
}
