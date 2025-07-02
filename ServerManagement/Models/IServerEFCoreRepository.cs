﻿
namespace ServerManagement.Models
{
    public interface IServerEFCoreRepository
    {
        void AddServer(Server server);
        void DeleteServer(int serverId);
        Server GetServerById(int id);
        List<Server> GetServers();
        List<Server> GetServersByCity(string cityName);
        List<Server> SearchServers(string searchTerm);
        void UpdateServer(int serverId, Server server);
    }
}