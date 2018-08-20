namespace BookLibrary.Data
{
    public static class Connection
    {
        public static string ConnectionString { get; set; } = "Data Source=.;Database=RazorBookLibrary;Integrated Security=True";
        //public static string ConnectionString { get; set; } = "Server=tcp:softunidatabases.database.windows.net,1433;Initial Catalog=Test_DB;Persist Security Info=False;User ID=Nasokila;Password=Bg9212060000$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}   

