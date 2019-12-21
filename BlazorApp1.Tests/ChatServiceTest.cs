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
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorApp1.Tests
{
    public class ChatServiceTest
    {
       
        [Fact]
        public async Task TimerDeletionTest()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "database_name").Options; ;


            Message message1 = new Message("vasya", "Hello", true)
            {
                IsTimered = true,
                IsSecret = true,
                CreationTime = DateTime.Now,
                FirstUserId = "1",
                SecondUserId = "2"
            };
            Message message2 = new Message("petya", "Nixao", false)
            {
                IsTimered = true,
                IsSecret = true,
                CreationTime = DateTime.Now - TimeSpan.FromDays(1),
                FirstUserId = "1",
                SecondUserId = "2"
            };
            using (var db = new ApplicationDbContext(dbOptionsBuilder))
            {
                db.Set<Message>().Add(message1);
                db.Set<Message>().Add(message2);
                await db.SaveChangesAsync();
            }

            using (var db = new ApplicationDbContext(dbOptionsBuilder))
            {
                db.Set<SecretChat>().Add(new SecretChat("1_2")
                {
                    Timer = TimeSpan.FromMinutes(1)
                });
                await db.SaveChangesAsync();
            }

            using (var db = new ApplicationDbContext(dbOptionsBuilder))
            {
                var service = new ChatService();

                var result = service.CheckSecretChats(db);

                Assert.NotNull(result);
                Assert.Equal(result.First().MesssageId, message2.MesssageId);
            }
        }
    }
}
