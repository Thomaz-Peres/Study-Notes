
serviceMock.Setup(m => m.SendEmail(It.IsAny<EmailEntity>(), new System.Threading.CancellationToken())).ReturnsAsync(new EmailEntity(assunto, mensagem, para));
messageController = new MessageController(serviceProvider.Object);

Mock<Microsoft.AspNetCore.Mvc.IUrlHelper> url = new Mock<Microsoft.AspNetCore.Mvc.IUrlHelper>();
url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
messageController.Url = url.Object;

var email = new EmailEntity
{
Message = mensagem,
Subject = assunto,
To = para
};

var result = await sut.SendEmail(email, new System.Threading.CancellationToken());
Assert.True(result.Result is Microsoft.AspNetCore.Mvc.OkObjectResult);