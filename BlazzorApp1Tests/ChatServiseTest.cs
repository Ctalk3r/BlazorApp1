//using NUnit.Framework;
//using Microsoft.AspNetCore.Components.Testing;
//using BlazorApp1;
//using BlazorApp1.Data;
//using BlazorApp1.Pages;
//using Microsoft.JSInterop;
//using Moq;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Identity;
//using BlazorApp1.Models;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Authorization;

//namespace BlazzorApp1Tests
//{
//	public class Tests
//	{
//		private Mock<UserManager<User>> GetMockUserManager()
//		{
//			var userStoreMock = new Mock<IUserStore<User>>();
//			return new Mock<UserManager<User>>(
//				userStoreMock.Object, null, null, null, null, null, null, null, null);
//		}
//		private TestHost _host = new TestHost();
//		[SetUp]
//		public void Setup()
//		{
//			var jsRuntimeMock = new Mock<IJSRuntime>();
//			var chatMock = new Mock<ChatService>();
//			var dbMock = new Mock<ApplicationDbContext>();
//			var navMock = new Mock<NavigationManager>();
//			var userMock = GetMockUserManager();
//			var authMock = new Mock<AuthenticationStateProvider>();
//			var authPolicyMock = new Mock<IAuthorizationPolicyProvider>();
//			var authService = new Mock<IAuthorizationService>();
//			var cascadingMock = new Mock<CascadingAuthenticationState>();


//			_host.AddService(jsRuntimeMock.Object);
//			_host.AddService(chatMock.Object);
//			_host.AddService(dbMock.Object);
//			_host.AddService(navMock.Object);
//			_host.AddService(userMock.Object);
//			_host.AddService(authMock.Object);
//			_host.AddService(authPolicyMock.Object);
//			_host.AddService(authService.Object);
//			_host.AddService(cascadingMock.Object);


//		}

//		[Test]
//		public void Test1()
//		{
//			var component = _host.AddComponent<Chats>();
//			Assert.AreEqual("Chat List", component.Find("h1").InnerText);
//		}
//	}
//}