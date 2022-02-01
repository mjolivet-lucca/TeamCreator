using System.Collections.Generic;
using Xunit;

namespace Domain.Test;

public class ShufflerTest
{
    [Fact]
    public void ShouldReturnEmptyTeam_WhenNoRosterIsProvided()
    {
        var shuffler = new Shuffler(new List<Member>());

        var (team1, team2) = shuffler.CreateTwoTeams();
        
        Assert.Empty(team1.Members);
        Assert.Empty(team2.Members);
    }

    [Fact]
    public void ShouldReturnEqualAmountOfMembers_WhenEvenAmountOfMemberInRoster()
    {
        var shuffler = new Shuffler(new List<Member>
        {
            new("andré"),
            new("benoit"),
            new("charles"),
            new("damien")
        });
        
        var (team1, team2) = shuffler.CreateTwoTeams();
        
        Assert.Equal(2, team1.Members.Count);
        Assert.Equal(2, team2.Members.Count);
    }
}