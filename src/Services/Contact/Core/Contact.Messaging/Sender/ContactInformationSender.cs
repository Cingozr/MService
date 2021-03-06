﻿using Contact.Data.Entities;
using Contact.Messaging.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Contact.Messaging.Sender
{
    public class ContactInformationSender : IContactInformationSender
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly int _port;
        private IConnection _connection;

        public ContactInformationSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _port = rabbitMqOptions.Value.Port;
            CreateConnection();
        }
        public void AddContactInformationToPerson(ContactInformations model)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    Port = _port,
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }
        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
