using System.Collections.Generic;

namespace Learn.PrismWpf.BasicRegions.Services
{
  public class LargeMemoryService : ILargeMemoryService
  {
    public List<string> GetAll()
    {
      return new List<string>
      {
        "Here is a",
        "fake list of",
        "items which",
        "would be a memory",
        "hog.",
      };
    }
  }
}