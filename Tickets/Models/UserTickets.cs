using Tickets.Interfaces;

namespace Tickets.Models;



public class UserTickets : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public string CreatorId { get; set; }

  public string name { get; set; }

  public int TicketId { get; set; }

  public Account Creator { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

}

