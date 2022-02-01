namespace Domain;

public class Team
{
    public string Name { get; private set; }

    public IReadOnlyCollection<Member> Members => InternalMembers;
    private List<Member> InternalMembers { get; }

    public Team(string name)
    {
        Name = name;
        InternalMembers = new List<Member>();
    }

    public void AddMember(Member member)
    {
        InternalMembers.Add(member);
    }
}