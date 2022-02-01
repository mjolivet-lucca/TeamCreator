namespace Domain;

public class Shuffler
{
    private readonly List<Member> _roster;

    public Shuffler(IReadOnlyCollection<Member> roster)
    {
        _roster = roster.ToList();
    }

    public (Team first, Team second) CreateTwoTeams()
    {
        var rng = new Random();
        var remainingMembers = _roster.ToList();
        var first = new Team("Ecrit le test");
        var second = new Team("Fait passer au vert");
        var i = 0;
        while (remainingMembers.Any())
        {
            var memberId = rng.Next(0, remainingMembers.Count -1);
            var member = remainingMembers[memberId];
            if (i % 2 == 0)
            {
                first.AddMember(member);
            }
            else
            {
                second.AddMember(member);
            }

            remainingMembers.Remove(member);
            i++;
        }

        return (first, second);
    }
}