using CrudDapperMVC.Repository.Interface;
using Dapper;
using CrudDapperMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CrudDapperMVC.Repository.Concrete
{
    public class ClientRepository : IClientRepository
    {
        public SqlConnection OpenConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["UserRegistration"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con; 
        }

        public void Add(Client client)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "INSERT INTO Client(Name, CPF, Email, Phone, Active, DateRegister) VALUES(@Name, @CPF, @Email, @Phone, @Active, @DateRegister);";
                    con.Execute(query, client);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client ORDER BY Name";
                    clients = con.Query<Client>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return clients;
            }
        }

        public Client GetByID(long ID)
        {
            Client client = new Client();

            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client WHERE Id =" + ID;
                    client = con.Query<Client>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return client;
            }
        }

        public void Remove(int ID)
        {

            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "DELETE FROM Client WHERE Id =" + ID;
                    con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Update(Client client)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var clientDB = PrepareObjectToSave(client);
                    var query = "UPDATE Client SET Name = @Name, CPF = @CPF, Email = @Email, Phone = @Phone, Active = @Active WHERE Id = " + clientDB.Id;
                    con.Execute(query, clientDB);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Client PrepareObjectToSave(Client client)
        {
            return new Client {
                Active = client.Active,
                CPF = client.CPF.Replace(".", "").Replace("-", "").Trim(),
                Email = client.Email,
                Id = client.Id,
                Name = client.Name,
                Phone = client.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "").Replace(" ", "").Trim()
            };
        }
    }
}
