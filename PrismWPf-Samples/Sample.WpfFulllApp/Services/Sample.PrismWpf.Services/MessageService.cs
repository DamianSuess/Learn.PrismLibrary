using Test.PrismWpf.Services.Interfaces;

namespace Test.PrismWpf.Services
{
  public class MessageService : IMessageService
  {
    public string GetMessage()
    {
      return "Hello from the Message Service";
    }
  }
}
