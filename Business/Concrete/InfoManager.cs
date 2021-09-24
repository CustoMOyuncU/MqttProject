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
        
        public IResult PublishMessage()
        {
            
            MqttClient client = new MqttClient(IPAddress.Parse("192.168.20.60"));
           // client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //client.Subscribe(new string[] { "application/1/device/24e124136b146730/event/up" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            string message = "Test";

            byte[] bytes = Encoding.ASCII.GetBytes(message);


            client.Publish("application/1/device/24e124136b146730/event/up", bytes);

            client.Disconnect();

            return new SuccessResult();
            
        }
       


    }
}
