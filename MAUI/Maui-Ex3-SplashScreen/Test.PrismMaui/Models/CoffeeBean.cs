namespace Test.PrismMaui.Models;

public class CoffeeBean
{
  public CoffeeBean()
  {
  }

  public CoffeeBean(string name)
  {
    Name = name;
  }

  public string Name { get; set; } = "Unknown";
}