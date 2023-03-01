using Tickets.Interfaces;

namespace Tickets.Models;

public class Ticket : ICreated, IRepoItem<int>
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