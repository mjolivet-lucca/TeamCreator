using Domain;

namespace Web.DTO;

public class Result
{
    public List<string> WriteTest { get; set; }
    public List<string> SolveTest { get; set; }

    public Result(Team first, Team second)
    {
        WriteTest = first.Members.Select(m => m.Name).ToList();
        SolveTest = second.Members.Select(m => m.Name).ToList();
    }
}