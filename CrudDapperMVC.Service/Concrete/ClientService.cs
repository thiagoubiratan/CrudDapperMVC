using CrudDapperMVC.Domain.Entities;
using CrudDapperMVC.Repository.Interface;
using CrudDapperMVC.Service.Interface;
using System.Collections.Generic;

namespace CrudDapperMVC.Service.Concrete
{
    public class ClientService : IClientService
    {
        protected readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Add(Client client)
        {
            _clientRepository.Add(client);
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Client GetByID(long ID)
        {
            return _clientRepository.GetByID(ID);
        }

        public void Remove(int ID)
        {
            _clientRepository.Remove(ID);
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
