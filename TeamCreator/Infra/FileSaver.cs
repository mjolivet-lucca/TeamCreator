using Domain;

namespace Infra;

public class FileSaver
{
    private const string Path = @"C:\atelierMembres";
    public FileSaver()
    {
        
    }

    public async Task Save(List<Member> members)
    {
        if (!File.Exists(Path))
        {
            await using(File.Create(Path)){}
        }

        await File.AppendAllLinesAsync(Path, members.Select(m => m.Name));
    }

    public async Task<List<Member>> GetMembers()
    {
        if (!File.Exists(Path))
        {
            return new List<Member>();
        }
        var memberNames = await File.ReadAllLinesAsync(Path);
        return memberNames.Select(m => new Member(m)).ToList();
    }

    public void Wipe()
    {
        if (File.Exists(Path))
        {
            File.Delete(Path);
        }
    }
}