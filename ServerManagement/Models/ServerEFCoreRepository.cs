using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;

namespace ServerManagement.Models
{
    public class ServerEFCoreRepository : IServerEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> contextFactory;

        public ServerEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void AddServer(Server server)
        {
            using var db = contextFactory.CreateDbContext();
            db.Servers.Add(server);

            db.SaveChanges();
        }

        public List<Server> GetServers()
        {
            using var db = contextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public List<Server> GetServersByCity(string cityName)
        {
            using var db = contextFactory.CreateDbContext();
            return db.Servers.Where(s => s.City == cityName).ToList();

        }

        public Server GetServerById(int id)
        {
            using var db = contextFactory.CreateDbContext();
            var server = db.Servers.Find(id);
            if (server != null) return server;

            return new Server();

        }

        public void UpdateServer(int serverId, Server server)
        {
            if (server == null) throw new ArgumentNullException(nameof(server));
            if (serverId != server.ServerId) return;

            using var db = contextFactory.CreateDbContext();
            var serverToUpdate = db.Servers.Find(serverId);
            if (serverToUpdate is not null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
            db.SaveChanges();
        }

        public void DeleteServer(int serverId)
        {

            using var db = contextFactory.CreateDbContext();
            var server = db.Servers.Find(serverId);
            if (server is null) return;

            db.Servers.Remove(server);
            db.SaveChanges();

        }

        public List<Server> SearchServers(string searchTerm)
        {
            using var db = contextFactory.CreateDbContext();
            return db.Servers
                .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            s.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
