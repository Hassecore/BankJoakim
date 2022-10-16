using System.Threading.Tasks;

namespace BankJoakim.Models.Accounts.RandomIbanRetriever
{
    public interface IRandomIbanRetriever
    {
        Task<string> Retrieve();
    }
}
