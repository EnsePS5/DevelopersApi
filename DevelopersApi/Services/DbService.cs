using DevelopersApi.DTO;
using DevelopersApi.Entities_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersApi
{
    public class DbService : IDbService
    {

        private readonly DevStudioDbContext _devStudioDbContext;

        public DbService(DevStudioDbContext context) {

            _devStudioDbContext = context;
        }

        public async Task<bool> AddDeveloperToGame(int developer, int GameId)
        {
            SqlConnection connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            await connection.OpenAsync();
            DbTransaction transaction = await connection.BeginTransactionAsync();
            command.Transaction = (SqlTransaction)transaction;

            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Developer WHERE IdDeveloper = @idDev";
            command.Parameters.AddWithValue("@idDev", developer);
            var scalar = await command.ExecuteScalarAsync();

            if (scalar == null) {
                return false;
            }

            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Game WHERE IdGame = @GameId";
            command.Parameters.AddWithValue("@GameId", GameId);
            scalar = await command.ExecuteScalarAsync();

            if (scalar == null) {
                return false;
            }

            command.Parameters.Clear();
            command.CommandText = "SELECT 1 FROM Developer_Game WHERE IdGame = @GameId AND IdDeveloper = @idDev";
            command.Parameters.AddWithValue("@GameId", GameId);
            command.Parameters.AddWithValue("@idDev", developer);
            scalar = await command.ExecuteScalarAsync();

            if (scalar != null)
            {
                return false;
            }

            command.Parameters.Clear();
            command.CommandText = $"INSERT INTO Developer_Game VALUES(${developer},${GameId},'noobie')";
            await command.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
            return true;
        }

        public async Task<ResultDTO> GetDevelopersByGameId(int GameId)
        {
            if (_devStudioDbContext.Games.Where(x => x.IdGame == GameId) == null) {

                return new ResultDTO() {
                    httpStatusCode = System.Net.HttpStatusCode.NotFound,
                    message = "Game with such id does not exist."
                };
            }

            return await _devStudioDbContext.Games.Include(x => x.DeveloperGames).ThenInclude(x => x.IdDeveloperNavigation)
                .Where(x => x.IdGame == GameId).Select(x => new ResultDTO { 

                    httpStatusCode = System.Net.HttpStatusCode.OK,
                    message = "Ok",
                    IdGame = x.IdGame,
                    Name = x.Name,
                    Developers = x.DeveloperGames.Select(y => new DeveloperDTO { 
                        IdDeveloper = y.IdDeveloper,
                        Firstname = y.IdDeveloperNavigation.Firstname,
                        Lastname = y.IdDeveloperNavigation.Lastname,
                        DateOfJoin = y.IdDeveloperNavigation.DateOfJoin
                    }).ToList()

                }).FirstOrDefaultAsync();
        }
    }
}