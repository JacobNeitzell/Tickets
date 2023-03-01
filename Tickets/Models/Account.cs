using Tickets.Interfaces;
namespace Tickets.Models;

public class Account : IRepoItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }

  public DateTime CreatedAt { get; set; }

  public DateTime Updatedat { get; set; }
  public DateTime UpdatedAt { get; set; }
}


public class Profile : Account
{
  public new string Email { get; set; }


}