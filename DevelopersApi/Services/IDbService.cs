using DevelopersApi.DTO;
using DevelopersApi.Entities_Models;
using System.Threading.Tasks;

namespace DevelopersApi
{
    public interface IDbService
    {

        Task<ResultDTO> GetDevelopersByGameId(int GameId);
        Task<bool> AddDeveloperToGame(int developer, int GameId);
        Task<bool> DeleteDeveloperFromGame(int developerId);
    }
}