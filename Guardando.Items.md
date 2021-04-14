
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

## particinha que tirei do readme do meu thema 

- **C#**
- ![image](https://user-images.githubusercontent.com/58439854/90839179-34609600-e32d-11ea-93d4-33c83bd69d36.png)

- **JS**
- ![image](https://user-images.githubusercontent.com/58439854/90838952-aa183200-e32c-11ea-9742-472eb25084d3.png)

- **HTML**
- ![image](https://user-images.githubusercontent.com/58439854/90839058-ec417380-e32c-11ea-9cac-8d056b7d41f4.png)

- **CSS**
- ![image](https://user-images.githubusercontent.com/58439854/90838846-586fa780-e32c-11ea-9bed-c64d3e5baf9d.png)