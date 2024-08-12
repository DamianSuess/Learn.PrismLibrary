using System;

namespace Learn.PrismWpf.Common
{
  [AttributeUsage(AttributeTargets.Class,
                  AllowMultiple = false)]
  public class RolesAttribute : Attribute
  {
    public RolesAttribute(params string[] roles)
    {
      Roles = roles;
    }

    public string[] Roles { get; set; }
  }
}
