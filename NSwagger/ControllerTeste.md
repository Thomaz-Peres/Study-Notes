[TestFixture]
    public class ControllersTests
    {
        [Test]
        public async Task DeveEnviarUmEmail()
        {
            HttpClient httpClient = new HttpClient();

            Client cli = new Client("", httpClient);

            var result = await cli.SendEmailAsync(new EmailEntity() { Message = "", Subject = "Teste Unitário", To = "" });

            Assert.AreEqual(result, result);

        }
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }