using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Business.Concrete
{
    public class InfoManager : IInfoService
    {
        // Turn on command {"confirmed": false, "fPort": 10, "data": "aAJQIYEABGgBBvAAIAEhZGUW"}
        // Turn off command {"confirmed": false, "fPort": 10, "data": "aAJQIYEABGgBBvAAIAEiAAIW"}

        public IResult PublishMessage(object message)
        {
            
            MqttClient client = new MqttClient(IPAddress.Parse("192.168.20.60"));
           // client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //client.Subscribe(new string[] { "application/1/device/24e124136b146730/event/up" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            

            byte[] bytes = Encoding.ASCII.GetBytes(message.ToString());


            client.Publish("application/4/device/0095690600001873/command/down", bytes);

            //client.Disconnect();

            return new SuccessResult(message.ToString());
            
        }

        public IResult TurnOffLight(object command)
        {
            MqttClient client = new MqttClient(IPAddress.Parse("192.168.20.60"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            byte[] turnOffBytes = Encoding.ASCII.GetBytes(command.ToString());

            client.Publish("application/4/device/0095690600001873/command/down", turnOffBytes);

            //client.Disconnect();

            return new SuccessResult();

        }

        public IResult TurnOnLight(object command)
        {
            MqttClient client = new MqttClient(IPAddress.Parse("192.168.20.60"));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            byte[] turnOnBytes = Encoding.ASCII.GetBytes(command.ToString());

            client.Publish("application/4/device/0095690600001873/command/down", turnOnBytes);

            //client.Disconnect();

            return new SuccessResult();
        }
    }
}
