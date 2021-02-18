using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PhonebookBackend_Api.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PhonebookBackend_Api.Controllers
{
    public class ClientController : ApiController
    {
        //Writing the methods below for (get, put and post)
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                            select clientID, clientName, clientSurname, clientIdNumber, clientTelephone, clientEmail, ClientAddress from
                            dbo.CLIENT";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbPhonebook"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Client client)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            Insert into dbo.CLIENT (clientName, clientSurname, clientIdNumber, clientTelephone, clientEmail, clientAddress) 
                values('" + client.clientName + @"'
                       ,'" + client.clientSurname + @"'
                       ,'" + client.clientIdNumber + @"'
                       ,'" + client.clientTelephone + @"'
                       ,'" + client.clientEmail + @"'
                       ,'" + client.clientAddress + @"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbPhonebook"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Client added successfully";
            }

            catch (Exception)
            {
                return "Failed to add client";
            }
        }

        public string Put(Client client)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                        UPDATE dbo.CLIENT set
                        clientName = '" + client.clientName + @"'
                        ,clientSurname = '" + client.clientSurname + @"'
                        ,clientIdNumber = '"+ client.clientIdNumber + @"'
                        ,clientTelephone = '" + client.clientTelephone + @"'
                        ,clientEmail = '" + client.clientEmail + @"'
                        ,clientAddress = '" + client.clientAddress + @"'
                        where clientID = '" + client.clientID + @"'
                        ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbPhonebook"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Updated successfully";
            }

            catch (Exception)
            {
                return "Failed to update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                        delete from dbo.CLIENT where clientID = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbPhonebook"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Deleted successfully";
            }

            catch (Exception)
            {
                return "Failed to delete";
            }
        }
    }
}
