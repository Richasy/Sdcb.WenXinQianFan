# Sdcb.WenXinQianFan [![NuGet](https://img.shields.io/nuget/v/Sdcb.WenXinQianFan.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![NuGet](https://img.shields.io/nuget/dt/Sdcb.WenXinQianFan.svg?style=flat-square)](https://www.nuget.org/packages/Sdcb.WenXinQianFan/) [![GitHub](https://img.shields.io/github/license/sdcb/Sdcb.WenXinQianFan.svg?style=flat-square&label=license)](https://github.com/sdcb/Sdcb.WenXinQianFan/blob/master/LICENSE.txt)

**[English](README_EN.md)** | **��������**

`Sdcb.WenXinQianFan`��һ���ǹٷ��Ŀ�Դ��Ŀ���ṩWenXin QianFan API �� .NET �ͻ��ˡ������Ŀ�������������ܹ�����Ȼ�������û���������������˺��������֡�

## ����

- Ϊ WenXin QianFan API �ṩ .NET �ͻ��ˡ�
- ֧��ͬ�����첽ͨ�š�
- ʵ������API����ʵ��ʵʱͨ�š�
- Ϊ��������˿����ṩ�˼�ֱ�۵�API��

## ��װ

ͨ��NuGet���԰�װ `Sdcb.WenXinQianFan`�� �ڳ��������������̨���������������԰�װ�������

```
Install-Package Sdcb.WenXinQianFan
```

## ʹ�÷���

Ҫʹ�� Sdcb.WenXinQianFan������Ҫ����һ�� `QianFanClient` ��ʵ����������ͨ����WenXin QianFan APIƾ�ݴ��ݸ����캯���������ͻ��ˣ�

```csharp
QianFanClient client = new QianFanClient(apiKey, apiSecret);
```

### ʾ��1��ʹ��ͬ��API��������������

����ʾ����ʾ�����ʹ�� `ChatAsync` �����������������죺

```csharp
QianFanClient c = new QianFanClient(apiKey, apiSecret);
ChatResponse msg = await c.ChatAsync(KnownModel.ERNIEBotTurbo, new ChatMessage[]
{
    ChatMessage.FromUser("ϵͳ��ʾ�����������һ��5���к������ڽ�ɫҡ���׶�԰��ѧ�������������ģ���һ������ʦ"),
    ChatMessage.FromAssistant("����"),
    ChatMessage.FromUser("���С���ѣ���������ʦ����������ѧ��"),
});
Console.WriteLine(msg.Result);
```

### ʾ��2��ʹ����API��������������

����ʾ����ʾ�����ʹ�� `ChatAsStreamAsync` �����Լ���API�������������죺

```csharp
StringBuilder sb = new StringBuilder();
QianFanClient c = new QianFanClient(apiKey, apiSecret);
await foreach (StreamedChatResponse msg in c.ChatAsStreamAsync(KnownModel.ERNIEBot, new ChatMessage[] { ChatMessage.FromUser("���ϵ�ʡ�����ģ�") }, new ChatRequestParameters
{
    Temperature = 0.5f,
    PenaltyScore = 2.0f,
    UserId = "zhoujie"
}))
{
    sb.Append(msg.Result);
}
Console.WriteLine(sb.ToString());
```

## ֧�ֵ�ģ��

������ Sdcb.WenXinQianFan ֧�ֵ�����ģ���б�

| ģ�� | ���� |
| --- | --- |
| ERNIEBot | �ٶ������з��Ĵ�����ģ�ͣ����Ǻ����������ݣ����и�ǿ�ĶԻ��ʴ����ݴ������ɵ������� |
| ERNIEBotTurbo | �ٶ������з��Ĵ�����ģ�ͣ����Ǻ����������ݣ����и�ǿ�ĶԻ��ʴ����ݴ������ɵ���������Ӧ�ٶȸ��졣 |
| BLOOMZ_7B | ҵ��֪���Ĵ�����ģ�ͣ���BigScience�з�����Դ���ܹ���46�����Ժ�13�ֱ����������ı��� |
| Llama2_7bChat | Meta AI�з�����Դ���ڱ��롢����֪ʶӦ�õȳ����������㣬Llama-2-7b-chat�Ǹ�����ԭ����Դ�汾�������ڶԻ������� |
| Llama2_13bChat | Meta AI�з�����Դ���ڱ��롢����֪ʶӦ�õȳ����������㣬Llama-2-13b-chat��������Ч�������ԭ����Դ�汾�������ڶԻ������� |
| Llama2_70bChat | Meta AI�з�����Դ���ڱ��롢����֪ʶӦ�õȳ����������㣬Llama-2-70b-chat�Ǹ߾���Ч����ԭ����Դ�汾�� |
| QianfanBLOOMZ_7BCompressed | ǧ���Ŷ���BLOOMZ-7B�����ϵ�ѹ���汾���ں�������ϡ�軯�ȼ������Դ�ռ�ý���30%���ϡ� |
| QianfanChineseLlama2_7B | ǧ���Ŷ���Llama-2-7b�����ϵ�������ǿ�汾����CMMLU��C-EVAL���������ݼ��ϱ������졣 |
| ChatGLM2_6B_32K | ����AI���廪KEGʵ���ҷ�������Ӣ˫��Ի�ģ�ͣ��ܹ����õĴ������32K���ȵ������ġ� |
| AquilaChat_7B | ����Դ�о�Ժ�з�������Aquila-7Bѵ���ĶԻ�ģ�ͣ�֧���������ı��Ի���������������������ͨ���������չ������ָ��淶��ʵ�� AquilaChat������ģ�ͺ͹��ߵĵ��ã���������չ�� |

���µ��б������[��������](https://cloud.baidu.com/doc/WENXINWORKSHOP/s/Nlks5zkzu)�˽⡣

## ���֤

Sdcb.WenXinQianFan ��ѭ MIT ���֤�� �����[LICENSE.txt](LICENSE.txt)�ļ��Ի�ȡ������Ϣ��