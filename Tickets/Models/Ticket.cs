namespace Tickets.Models;

public class Ticket
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public string CreatorId { get; set; }
  public string ticketname { get; set; }
  public string ticketclient { get; set; }

  public string description { get; set; }

  public Profile Creator { get; set; }

}