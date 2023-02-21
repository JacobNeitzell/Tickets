namespace Tickets.Models;

public class UserTickets
{
  public int Id { get; set; }
  public string creatorId { get; set; }

  public string name { get; set; }

  public Account Creator { get; set; }


}

