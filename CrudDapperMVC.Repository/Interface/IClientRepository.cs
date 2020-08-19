using CrudDapperMVC.Domain.Entities;
using System.Collections.Generic;

namespace CrudDapperMVC.Repository.Interface
{
    public interface IClientRepository
    {
        void Add(Client client);
        Client GetByID(long ID);
        List<Client> GetAll();
        void Update(Client client);
        void Remove(int ID);
        Client PrepareObjectToSave(Client client);
    }
}
