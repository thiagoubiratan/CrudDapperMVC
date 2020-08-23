using CrudDapperMVC.Model;
using CrudDapperMVC.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace CrudDapperMVC.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client ORDER BY Name";
                    List<Client> clients = con.Query<Client>(query).ToList();
                    return View(clients);
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.Index" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public ActionResult Details(int id)
        {
            return View(GetByID(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    if (!Validation(client)) return View(client);
                    var query = "INSERT INTO Client(Name, CPF, Email, Phone, Active, DateRegister, ZipCode, Street, Number, AddressComplement, City, Neighborhood, State) " +
                        "VALUES(@Name, @CPF, @Email, @Phone, @Active, @DateRegister, @ZipCode, @Street, @Number, @AddressComplement, @City, @Neighborhood, @State);";
                    Client pClient = PrepareObjectToSave(client);
                    con.Execute(query, pClient);
                    TempData["success"] = "Operação realizada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.Create" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public ActionResult Edit(int id)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client WHERE Id =" + id;
                    Client client = con.Query<Client>(query).FirstOrDefault();
                    return View(client);
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.Edit" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    if (!Validation(client)) return View(client);
                    var query = "UPDATE Client SET Name = @Name, CPF = @CPF, Email = @Email, Phone = @Phone, Active = @Active, " +
                        "ZipCode = @ZipCode, Street = @Street, Number = @Number, AddressComplement = @AddressComplement, City = @City, Neighborhood = @Neighborhood, State = @State " +
                        "WHERE Id = " + client.Id;
                    con.Execute(query, PrepareObjectToSave(client));
                    TempData["success"] = "Operação realizada com sucesso!";
                    return RedirectToAction("Index");
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

        public ActionResult Delete(int id)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client WHERE Id =" + id;
                    Client client = con.Query<Client>(query).FirstOrDefault();
                    return View(client);
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.Delete" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "DELETE FROM Client WHERE Id =" + id;
                    con.Execute(query);
                    TempData["success"] = "Operação realizada com sucesso!";
                    return RedirectToAction("Index");
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

        private Client GetByID(int id)
        {
            Client client = new Client();
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    var query = "SELECT * FROM Client WHERE Id =" + id;
                    client = con.Query<Client>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.GetByID" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return client;
        }

        private Client GetByCPF(Client client)
        {
            Client clientQuery = new Client();
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    string pCpf = PrepareToCpf(client.CPF);
                    var query = "SELECT * FROM Client WHERE CPF = '" + pCpf + "' AND  Id <> " + client.Id;
                    clientQuery = con.Query<Client>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("ClientController.GetByCPF" + ex.Message, ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return clientQuery;
        }

        private SqlConnection OpenConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["UserRegistration"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con;
        }

        private bool Validation(Client client)
        {
            bool validation = true;
            if (!ValidaCPF.IsCpf(PrepareToCpf(client.CPF)))
            {
                TempData["warning"] = "CPF invalido!";
                validation = false;
            }
            else if (GetByCPF(client) != null)
            {
                TempData["warning"] = "CPF já Registrado!";
                validation = false;
            }
            return validation;
        }

        private Client PrepareObjectToSave(Client client)
        {
            return new Client
            {
                Active = client.Active,
                CPF = PrepareToCpf(client.CPF),
                Email = client.Email,
                Id = client.Id,
                Name = client.Name,
                Phone = PrepareToPhone(client.Phone),
                ZipCode = PrepareToZipCode(client.ZipCode),
                Street = client.Street,
                Number = client.Number,
                AddressComplement = client.AddressComplement,
                City = client.City,
                Neighborhood = client.Neighborhood,
                State = client.State
            };
        }

        private string PrepareToCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").Trim();
        }

        private string PrepareToPhone(string phone)
        {
            return phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "").Replace(" ", "").Trim();
        }

        private string PrepareToZipCode(string zipCode)
        {
            return zipCode.Replace(".", "").Replace("-", "").Trim();
        }
    }
}
