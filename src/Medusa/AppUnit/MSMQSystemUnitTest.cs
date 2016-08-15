using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using RabbitMQ.Client;
using Softcraftng.Medusa.MessageQueue;

namespace Softcraftng.Medusa.UnitTest
{
    public class MSMQSystemUnitTest : IDisposable
    {
        IConnectionFactory fakeFactory;
        Queue amqpMessageQueue;

        public MSMQSystemUnitTest()
        {
            fakeFactory = A.Fake<IConnectionFactory>();

            string _exchangeName = "demo";
            string _queueName = "demo";
            string _routingKey = "demo";

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Gotcha!");

            amqpMessageQueue = new Queue(fakeFactory, _exchangeName, _queueName, _routingKey);
            A.CallTo(() => amqpMessageQueue.Channel.BasicGet(_queueName, false)).Returns(new BasicGetResult(0ul, false, _exchangeName, _routingKey, 0, null, messageBodyBytes));
        }

        [Fact]
        public void TestSendToQueue()
        {
            amqpMessageQueue.SendToQueue("Test string");

            //Assert.
        }

        [Fact]
        public void TestReceive()
        {
            var result = amqpMessageQueue.Receive();

            Assert.Equal(result, "Gotcha!");
        }

        public void Dispose()
        {

        }
    }
}
