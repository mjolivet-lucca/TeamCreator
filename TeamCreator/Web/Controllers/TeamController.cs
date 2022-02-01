using Domain;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    public TeamController()
    {
        
    }

    [HttpGet]
    public async Task<Result> GetTeams()
    {
        var roster = await new FileSaver().GetMembers();
        var (team1, team2) = new Shuffler(roster).CreateTwoTeams();
        return new Result(team1, team2);
    }

    [HttpPost]
    public async Task AddMembers([FromBody] List<string> members)
    {
        await new FileSaver().Save(members.Select(m => new Member(m)).ToList());
    }
    
    [HttpDelete]
    public void Wipe()
    {
        new FileSaver().Wipe();
    }
    
}