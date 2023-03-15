namespace Tickets.Controller;

[ApiController]
[Route("api/[controller]")]

public class TicketsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly TicketsService _ts;

  public TicketsController(Auth0Provider auth0Provider, TicketsService ts)
  {
    _auth0provider = auth0Provider;
    _ts = ts;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket newTicket)
  {
    try
    {
      Profile userInfo = await _auth0provider.GetUserInfoAsync<Profile>(HttpContext);
      newTicket.CreatorId = userInfo.Id;
      Ticket createdTicket = _ts.CreateTicket(newTicket);
      createdTicket.Creator = userInfo;
      return Ok(createdTicket);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{ticketId}")]

  public async Task<ActionResult<Ticket>> GetTicketId(int ticketId)
  {
    try
    {
      Profile userInfo = await _auth0provider.GetUserInfoAsync<Profile>(HttpContext);
      Ticket foundTicket = _ts.GetTicketId(ticketId, userInfo?.Id);
      return Ok(foundTicket);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpDelete("{ticketId}")]
  [Authorize]

  public async Task<ActionResult<string>> DeleteTicket(int ticketId)
  {
    try
    {
      Profile userInfo = await _auth0provider.GetUserInfoAsync<Profile>(HttpContext);
      _ts.DeleteTicket(ticketId, userInfo.Id);
      return Ok("Ticket Succefully Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{ticketId}")]
  [Authorize]

  public async Task<ActionResult<Ticket>> UpdateTicket([FromBody] Ticket ticketData, int ticketId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      ticketData.CreatorId = userInfo.Id;
      ticketData.Id = ticketId;
      Ticket ticket = _ts.UpdateTicket(ticketData, userInfo.Id);
      return Ok(ticket);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




}