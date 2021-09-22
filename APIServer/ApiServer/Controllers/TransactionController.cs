using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Models;
using Microsoft.Extensions.Configuration;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public TransactionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //gets and displays data from db
        [HttpGet]
        public JsonResult Get()
        {
            //better methods of doing this than raw query ( could use stored procedures or entity framework)
            //select query
            var query = @"SELECT * FROM TestTB;";
            DataTable table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("DbConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon= new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mycCommand=new SqlCommand(query, myCon))
                {
                    myReader = mycCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        //posts data to data base
        [HttpPost]
        public JsonResult Post(Transaction transaction)
        {
            //insert query
            var query = @"";
            DataTable table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("TransactionAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mycCommand = new SqlCommand(query, myCon))
                {
                    myReader = mycCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Add Succeeded");
        }
        //updates data
        [HttpPut]
        public JsonResult Put(Transaction transaction)
        {
            //update query
            var query = @"";
            DataTable table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("TransactionAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mycCommand = new SqlCommand(query, myCon))
                {
                    myReader = mycCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Update Succeeded");
        }
        //sends id through URL
        [HttpDelete("{transactionId}")]
        public JsonResult Delete(Transaction transactionId)
        {
            //Delete query
            var query = @"";
            DataTable table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("TransactionAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mycCommand = new SqlCommand(query, myCon))
                {
                    myReader = mycCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Update Succeeded");
        }
    }
}
