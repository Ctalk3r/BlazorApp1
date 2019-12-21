using System;
using Xunit;
using Microsoft.AspNetCore.Components.Testing;
using BlazorApp1;
using BlazorApp1.Data;
using BlazorApp1.Pages;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using Moq;
using System.Net.Mail;
using MimeKit;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlazorApp1.Tests
{
	public class EmailServiceTest
	{
        public interface ISmtpClient
        {
            void Send(MailMessage message);
        }

        public class RealSmtpClient : ISmtpClient
        {
            public void Send(MailMessage message)
            {
                SmtpClient client = new SmtpClient();
                client.Send(message);
            }
        }

        public class FakeSmtpClient : ISmtpClient
        {
            public bool MailSent { get; set; }
            public FakeSmtpClient()
            {
                MailSent = false;
            }
            public void Send(MailMessage message)
            {
                MailSent = true;
            }
        }

        public class EmailHelper
        {
            private ISmtpClient smtpClient;

            public EmailHelper(ISmtpClient smtpClient)
            {
                this.smtpClient = smtpClient;
            }

            public void SendSupportMail(string toAddress)
            {
                if (IsValid(toAddress))
                {
                    MailMessage message = MakeMessage(toAddress);
                    smtpClient.Send(message);
                }
            }

            public MailMessage MakeMessage(string toAddress)
            {
                MailMessage message = new MailMessage("test@mail.ru", toAddress);
                message.IsBodyHtml = false;
                message.Subject = "Test";
                message.Body = string.Format("Number {0}.", new Random().Next(0, 10000));
                return message;
            }

            public bool IsValid(string emailAddress)
            {
                return Regex.IsMatch(emailAddress, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
            }
        }
        [Fact]
        public void TestTrueEmailValidation()
        {
            FakeSmtpClient fakeClient = new FakeSmtpClient();
            EmailHelper helper = new EmailHelper(fakeClient);

            helper.SendSupportMail("mat@blazor.com");

            Assert.True(fakeClient.MailSent);
        }

        [Fact]
        public void TestFalseEmailValidation()
        {
            FakeSmtpClient fakeClient = new FakeSmtpClient();
            EmailHelper helper = new EmailHelper(fakeClient);

            helper.SendSupportMail("matblazor.com");

            Assert.False(fakeClient.MailSent);
        }
    }
}
