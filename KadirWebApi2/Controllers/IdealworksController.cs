using Dapper;
using KadirWebApi2.Helper;
using KadirWebApi2.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KadirWebApi2.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class IdealworksController:ControllerBase
    {
        private string TableNameProducts = "Products";
        private string TableNameCustomers = "Customers";
        private string TableNameOrders = "Orders";

        [HttpGet(Name ="ProductGetById")]
        public ActionResult ProductGetById(int id)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = con.Query<Products>(@$"select * from Products where id=@ID", new { ID = id }).ToList();
                return Ok(sql);

            }
        }

        [HttpGet(Name ="ProductGetAll")]
        public ActionResult ProductGetAll()
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = con.Query<Products>($@"select * from Products").ToList();
                return Ok(sql);
            }
        }

        [HttpPost(Name ="ProductAdded")]
        public ActionResult ProductAdded([FromBody]List<Products> products)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = $"insert into Products (ProductName,StockCount) values(@ProductName,@StockCount)";
                con.Execute(sql,products);
                return Ok(sql);
            }
        }

        [HttpPost(Name ="ProductDeletedById")]
        public ActionResult ProductDeletedById(int id)
        {
            using (SqlConnection con = new SqlConnection(StaticVars.connectionString))
            {
                con.Execute($@"delete from Products where id=@ID", new { ID = id });
                return Ok("Kayıt Silindi");
            }
        }

        [HttpGet(Name ="CustomerGetById")]
        public ActionResult CustomerGetById(int id)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = con.Query<Customers>($@"select * from Customers where id=@ID", new { ID = id }).ToList();
                return Ok(sql);
            }
        }

        [HttpGet(Name ="CustomerGetAll")]
        public ActionResult CustomerGetAll()
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql=con.Query<Customers>($"select * from Customers").ToList();
                return Ok(sql);
            }
        }

        [HttpPost(Name ="CustomerAdded")]
        public ActionResult CustomerAdded([FromBody] List<Customers> customers)
        {
            using(SqlConnection con = new SqlConnection(StaticVars.connectionString))
            {
                var sql = $@"insert into Customers (CustomerName,TelNo) values (@CustomerName,@TelNo)";
                
                con.Execute(sql,customers);
                return Ok(sql);
            }
        }

        [HttpPost(Name ="CustomerDeletedById")]
        public ActionResult CustomerDeletedById(int id)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                con.Execute($@"delete from Customers where id=@ID", new { ID = id });
                return Ok("Kayıt Silindi");
            }
        }

        [HttpGet(Name ="OrderGetById")]
        public ActionResult OrderGetById(int id)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = con.Query<Orders>($@"select * from Orders where id=@ID", new { ID = id }).ToList();
                return Ok(sql);
               
            }
        }

        [HttpGet(Name ="OrderGetAll")]
        public ActionResult OrderGetAll()
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = con.Query<Orders>($@"select * from Orders").ToList();
                return Ok(sql);
            }
        }

        [HttpPost(Name ="OrderAdded")]
        public ActionResult OrderAdded([FromBody] List<Orders> orders)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                var sql = @$"insert into Orders (CustomerId,ProductId,OrderCount,OrderDate) values (@CustomerId,@ProductId,@OrderCount,@OrderDate)";
                
                con.Execute(sql,orders);
                return Ok(sql);
            }
        }

        [HttpPost(Name ="OrderDeletedById")]
        public ActionResult OrderDeletedById(int id)
        {
            using(SqlConnection con=new SqlConnection(StaticVars.connectionString))
            {
                con.Execute($@"delete from Orders where id=@ID", new { ID = id });
                return Ok("Kayıt silindi");
            }
        }
    }


}
