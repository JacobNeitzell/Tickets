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
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newTicket.CreatorId = userInfo.Id;
      Ticket createdTicket = _ts.CreateTicket(newTicket);
      createdTicket.Creator = userInfo;
      return OkObjectResult(createdTicket);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }










}