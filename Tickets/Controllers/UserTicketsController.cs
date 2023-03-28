namespace Tickets.Controller;

[ApiController]
[Route("api/[controller]")]

public class UserTicketsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly UserTicketsService _uts;

  public UserTicketsController(Auth0Provider auth0Provider, UserTicketsService uts)
  {
    _auth0provider = auth0Provider;

    _uts = uts;
  }



  [HttpPost]
  [Authorize]

  public async Task<ActionResult<UserTickets>> CreateUserTickets([FromBody] UserTickets newUserTicket)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newUserTicket.CreatorId = userInfo.Id;
      UserTickets createdUserTicekts = _uts.CreateUserTicket(newUserTicket, userInfo.Id);
      return Ok(createdUserTicekts);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }









}

