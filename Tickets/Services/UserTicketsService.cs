namespace Tickets.Services;

public class UserTicketsService
{
  private readonly TicketsRepository _tr;

  private readonly UserTicketsRepository _ut;

  private readonly TicketsService _ts;

  public UserTicketsService(UserTicketsRepository ut, TicketsRepository tr, TicketsService ts)
  {
    _tr = tr;
    _ut = ut;
    _ts = ts;
  }

internal UserTickets CreateUserTicket(UserTickets ticketData, string accountId)
{
  Ticket ticket = _ts.GetTicketId(ticketData.TicketId, accountId);
  if (ticketData.CreatorId != ticket.CreatorId)
  {
    throw new Exception("Unauthorized");
  }
}



}