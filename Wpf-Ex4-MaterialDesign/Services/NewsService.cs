using System.Collections.Generic;

namespace Learn.PrismWpf.BasicRegions.Services
{
  public class NewsService : INewsService
  {
    public List<string> GetTitles()
    {
      return new List<string>
      {
        "Growing Apple Trees",
        "Making Jack Fruit Side Dishes",
        "Angle Food Cake",
        "Grilling Steaks 101",
        "Winter Cooking With Smokeless Grills"
      };
    }
  }
}