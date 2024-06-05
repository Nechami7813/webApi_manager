using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProject;

internal class DataAccess
{

    public int AddUser(string connString)
    {
        string email, password, firstName, lastName;
        Console.WriteLine("insert email");
        email = Console.ReadLine();

        Console.WriteLine("insert password");
        password = Console.ReadLine();

        Console.WriteLine("insert firstName");
        firstName = Console.ReadLine(); 

        Console.WriteLine("insert lastName");
        lastName = Console.ReadLine();

        User user = new User()
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };
       
        string sql = "INSERT INTO User_tbl (Email,FirstName,LastName,Password)VALUES(@Email,@FirstName,@LastName,@Password); "+"SELECT CAST(scope_identity() AS INT);";
        using(SqlConnection connection=new SqlConnection(connString))
        {

            
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add("@Email", SqlDbType.VarChar);
            cmd.Parameters["@Email"].Value = user.Email;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar);
            cmd.Parameters["@FirstName"].Value = user.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            cmd.Parameters["@LastName"].Value = user.LastName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            cmd.Parameters["@Password"].Value = user.Password;
            try
            {
                connection.Open();
                user.UserId = (Int32)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return (int)user.UserId;
    }
    public int AddCategory(string connString)
    {
        string categoryName;
        Console.WriteLine("insert categoryName");
        categoryName = Console.ReadLine();

        

        Category category = new Category()
        {
            CategoryName = categoryName
        };

        string sql = "INSERT INTO Category_tbl (CategoryName)VALUES(@CategoryName); " + "SELECT CAST(scope_identity() AS INT);";
        using (SqlConnection connection = new SqlConnection(connString))
        {


            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar);
            cmd.Parameters["@CategoryName"].Value = category.CategoryName;
            
            try
            {
                connection.Open();
                category.CategoryId = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return (int)category.CategoryId;
    }

    public int AddProduct(string connString)
    {
        string description, prodName;
        Int32 price, categoryId;
        Console.WriteLine("insert ProdName");
        prodName = Console.ReadLine();

        Console.WriteLine("insert price");
        price =  Convert.ToInt32(Console.ReadLine()); 

        Console.WriteLine("insert categoryId");
        categoryId = Convert.ToInt32(Console.ReadLine()); ;

        Console.WriteLine("insert Description");
        description = Console.ReadLine();



        Product product = new Product()
        {
            ProdName = prodName,
            Price=price,
            CategoryId=categoryId,
            Description=description
        };

        string sql = "INSERT INTO Product_tbl (ProdName,Price,CategoryId,Description)VALUES(@ProdName,@Price,@CategoryId,@Description); " + "SELECT CAST(scope_identity() AS INT);";
        using (SqlConnection connection = new SqlConnection(connString))
        {


            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add("@ProdName", SqlDbType.VarChar);
            cmd.Parameters["@ProdName"].Value = product.ProdName;

            cmd.Parameters.Add("@Price", SqlDbType.VarChar);
            cmd.Parameters["@Price"].Value = product.Price;

            cmd.Parameters.Add("@Description", SqlDbType.VarChar);
            cmd.Parameters["@Description"].Value = product.Description;

            cmd.Parameters.Add("@CategoryId", SqlDbType.VarChar);
            cmd.Parameters["@CategoryId"].Value = product.CategoryId;

            try
            {
                connection.Open();
                product.ProdId = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return (int)product.ProdId;
    }
}
