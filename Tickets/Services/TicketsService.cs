namespace Tickets.Services;

public class TicketsService
{
  private readonly TicketsRepository _tr;

  public TicketsService(TicketsRepository tr)
  {
    _tr = tr;
  }


  internal Ticket CreateTicket(Ticket newTicket)
  {
    return _tr.Create(newTicket);
  }



}