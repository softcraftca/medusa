using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FakeItEasy;
using System.Net.Mail;
using Softcraftng.Medusa.Messaging.Interface;
using Softcraftng.Medusa.Messaging;
using Microsoft.Extensions.Logging;

namespace Softcraftng.Medusa.AppUnit
{
    public class MessageSystemUnitTest : IDisposable
    {
        ISmtpClient fakeSmtpClient;
        ILoggerFactory fakeLoggerFactory;

        public MessageSystemUnitTest()
        {
            fakeSmtpClient = A.Fake<ISmtpClient>();
            fakeLoggerFactory = A.Fake<ILoggerFactory>();
        }

        [Fact]
        public async void TestEmailSystem()
        {
            var email = new Email(fakeSmtpClient, fakeLoggerFactory);
            var retValue = await email.SendMessageAsync(new string[] { "onawoleco@yahoo.com" }, new string[] { }, new string[] { }, "hi", "Lorem ipsum", true);

            Assert.Equal(retValue, MessageStatus.Success);
        }

        [Fact]
        public async void TestTemplateEmailSystem()
        {
            var email = new Email(fakeSmtpClient, fakeLoggerFactory);
            var retValue = await email.SendTemplateEmailAsync("test", new string[] { }, new string[] { }, new string[] { }, "hi", "Lorem ipsum", true);

            Assert.Equal(retValue, MessageStatus.Success);
        }

        [Fact]
        public async void TestSMSSystem()
        {
            var sms = new SMS("", fakeLoggerFactory);
            var retValue = await sms.SendMessageAsyc(new string[] { }, "");

            Assert.Equal(retValue, MessageStatus.Success);
        }

        [Fact]
        public async void TestMMSSystem()
        {
            var mms = new MMS("", fakeLoggerFactory);
            var retValue = await mms.SendMessageAsyc(new string[] { }, "");

            Assert.Equal(retValue, MessageStatus.Success);
        }

        [Fact]
        public async void TestPhoneCall()
        {
            var phone = new PhoneCall("", fakeLoggerFactory);
            await phone.PlaceCall("");

        }

        public void Dispose()
        {
            // clean up
        }
    }
}
