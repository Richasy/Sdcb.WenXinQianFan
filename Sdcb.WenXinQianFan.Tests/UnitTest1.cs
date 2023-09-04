using Microsoft.Extensions.Configuration;
using System.Text;
using Xunit.Abstractions;

namespace Sdcb.WenXinQianFan.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _console;

        static UnitTest1()
        {
            Config = new ConfigurationBuilder()
                .AddUserSecrets<UnitTest1>()
                .Build();
        }

        public static IConfigurationRoot Config { get; }

        static QianFanClient CreateAPIClient()
        {
            string? apiKey = Config["QianFanConfig:ApiKey"];
            string? apiSecret = Config["QianFanConfig:ApiSecret"];
#pragma warning disable CS8604 // �������Ͳ�������Ϊ null��
            return new QianFanClient(apiKey, apiSecret);
#pragma warning restore CS8604 // �������Ͳ�������Ϊ null��
        }

        public UnitTest1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public async Task ChatAsStreamAsyncTest()
        {
            StringBuilder sb = new();
            QianFanClient c = CreateAPIClient();
            await foreach (StreamedChatResponse msg in c.ChatAsStreamAsync(KnownModel.ERNIEBot, new ChatMessage[] { ChatMessage.FromUser("���ϵ�ʡ�����ģ�") }, new ChatRequestParameters
            {
                Temperature = 0.5f,
                PenaltyScore = 2.0f,
                UserId = "zhoujie"
            }))
            {
                // append the result to the string builder
                sb.Append(msg.Result);
            }

            Assert.Contains("��ɳ", sb.ToString());
            _console.WriteLine(sb.ToString());
        }

        [Fact]
        public async Task ChatAsyncTest()
        {
            QianFanClient c = CreateAPIClient();
            ChatResponse msg = await c.ChatAsync(KnownModel.ERNIEBotTurbo, new ChatMessage[]
            {
                ChatMessage.FromUser("ϵͳ��ʾ�����������һ��5���к������ڽ�ɫҡ���׶�԰��ѧ�������������ģ���һ������ʦ"),
                ChatMessage.FromAssistant("����"),
                ChatMessage.FromUser("���С���ѣ���������ʦ����������ѧ��"),
            });
            _console.WriteLine(msg.Result);
            Assert.Contains("��ɫҡ���׶�԰", msg.Result);
        }
    }
}