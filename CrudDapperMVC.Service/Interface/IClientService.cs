using CrudDapperMVC.Domain.Entities;
using System.Collections.Generic;

namespace CrudDapperMVC.Service.Interface
{
    public interface IClientService
    {
        void Add(Client client);
        Client GetByID(long ID);
        List<Client> GetAll();
        void Update(Client client);
        void Remove(int ID);
    }
}
