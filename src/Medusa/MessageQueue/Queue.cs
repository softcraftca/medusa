using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MessageQueue
{
    public class Queue : IQueue, IDisposable
    {
        IConnectionFactory _factory;
        IModel _channel;
        IConnection _connection;

        string _exchangeName, _queueName, _routingKey;

        public IModel Channel { get { return _channel; } }


        public Queue(IConnectionFactory factory, string exchangeName, string queueName, string routingKey)
        {
            //factory.UserName = "murpheux";
            //factory.Password = "samlon4#";
            //factory.VirtualHost = "/";
            //factory.HostName = "gru";
            //factory.Uri = "amqp://murpheux:samlon4#@gru:5672/%2f";
            _factory = factory;
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _exchangeName = exchangeName;
            _queueName = queueName;
            _routingKey = routingKey;

            // create exchange and queue
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(queueName, false, false, false, null);
            _channel.QueueBind(queueName, exchangeName, routingKey, null);

        }

        public void SendToQueue(string content)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(content);
            _channel.BasicPublish(_exchangeName, _routingKey, props, messageBodyBytes);
        }

        public string Receive()
        {
            bool noAck = false;
            BasicGetResult result = _channel.BasicGet(_queueName, noAck);
            if (result != null)
            {
                IBasicProperties props2 = result.BasicProperties;
                byte[] body = result.Body;
                var message = Encoding.Default.GetString(body);

                _channel.BasicAck(result.DeliveryTag, false);
                return message;
            }

            return string.Empty;
        }

        public void Consume()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.Default.GetString(body);
                //return yield message;

                (ch as EventingBasicConsumer).Model.BasicAck(ea.DeliveryTag, false);
            };
            String consumerTag = _channel.BasicConsume(_queueName, false, consumer);
            _channel.BasicCancel(consumerTag);
        }

        public void Dispose()
        {
            _channel.Close(200, "Goodbye");
        }
    }
}
