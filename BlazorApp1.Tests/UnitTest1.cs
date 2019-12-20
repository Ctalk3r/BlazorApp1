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

namespace BlazorApp1.Tests
{
	public class UnitTest1
	{
		TestHost _host = new TestHost();
		[Fact]
		public void Test1()
		{

			var component = _host.AddComponent<Chats>();

			Assert.Equal("Chat List", component.Find("h1").InnerText);
		}
	}
}
