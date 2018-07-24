namespace BookLibrary.Data
{
    public static class Connection
    {
        public static string ConnectionString { get; set; } = "Data Source=HAL\\MSSQLSERVER2;Database=RazorBookLibrary;Integrated Security=True";
    }
}
