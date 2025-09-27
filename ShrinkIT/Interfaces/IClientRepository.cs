using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Interfaces;
public interface IClientRepository
{
    void AddClient(Client client);
    void UpdateClient(Client client);
    void DeleteClient(int clientID);
    Client GetClient(int clientID);
    List<Client> GetAllClients();
}
