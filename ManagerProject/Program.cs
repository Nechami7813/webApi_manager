// See https://aka.ms/new-console-template for more information

using ManagerProject;

Console.WriteLine("Hello, World!");

string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Product_326075108;Integrated Security=True;Encrypt=False";


DataAccess da = new DataAccess();
//da.AddUser(connectionString);
da.AddCategory(connectionString);
for (int i = 0; i < 20; i++)
{
    da.AddProduct(connectionString);
}

