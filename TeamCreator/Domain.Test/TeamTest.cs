using System.Linq;
using Xunit;

namespace Domain.Test;

public class TeamTest
{
    [Fact]
    public void ShouldInitWithNoMembers()
    {
        var team = new Team("");
        
        Assert.Empty(team.Members);
    }

    [Fact]
    public void ShouldAddMember_WhenMemberIsAdded()
    {
        var team = new Team("");
        
        team.AddMember(new Member("test"));

        Assert.Single(team.Members);
        Assert.Equal("test", team.Members.FirstOrDefault()?.Name);
    }
}