namespace Tickets.Services;

public class TicketsService
{
  private readonly TicketsRepository _tr;

  public TicketsService(TicketsRepository tr)
  {
    _tr = tr;
  }




}