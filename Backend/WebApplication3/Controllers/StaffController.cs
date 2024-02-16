using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StaffController : ApiController
    {


        public HttpResponseMessage Get()
        {
            string query = @"select StaffId,name,department from dbo.Staff";

            DataTable table = new DataTable();

            using (var con = new SqlConnection
            (ConfigurationManager.ConnectionStrings["StaffAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string  Post(Staff st)
        {
            try
            {
                string query = @"insert into dbo.Staff values
                (
                    '"+ st.name + @"',
                    '"+ st.department + @"'

                    )
                 ";
                DataTable table = new DataTable();
                using (var con =new SqlConnection(ConfigurationManager.ConnectionStrings["StaffAppDB"].ConnectionString))
                using (var cmd =new SqlCommand(query,con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    da.Fill(table);
                }
                return "successfully added";
            }
            catch (Exception ex)
            {
                return "failed to added";
            }

        }
        public string Put(Staff st)
        {
            try
            {
                string query = @" update dbo.Staff set
                 name = '" + st.name + @"',
                 department = '" + st.department + @"'
                 where staffId = "+st.StaffId+@" 
              ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StaffAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    da.Fill(table);
                }
                return "update to successfuly";
            }
            catch (Exception ex)
            {
                return "failed to update";
            }
        }
       public string Delete(int id)
        {
            try
            {
              string query = @"delete from dbo.Staff where StaffId = "+id + @"
                      ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StaffAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    da.Fill(table);
                }
                return "Delete successfuly";
            }
            catch (Exception ex)
            {
                return "failed to Delete";
            }
        }
            
        }
    }
    

