using RunLib.Model;

namespace RunLib.Repository
{
    public interface IMemberRepository
    {
        Member Add(Member m);
        Member Delete(int id);
        List<Member> GetAll();
        Member GetById(int id);
        List<Member> Search(int? id, string? name, string? team);
        string? ToString();
        Member Update(int id, Member member);
    }
}