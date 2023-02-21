namespace Tickets.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}


public class Profile : Account
{
  public new string Email { get; set; }


}