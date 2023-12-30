namespace Student_Task.Data
{
    public static class DatabaseContext
    {
        // Added TrustServerCertificate=True because dont have CA and will get error
        public static string connectionString = @"Data Source=MSI\MSSQLSERVER01;Initial Catalog=Student_Task;Persist Security Info=True;User ID=devLogin;Password=D@uxanh2;MultipleActiveResultSets=true;TrustServerCertificate=True";

        public static string CString { get => connectionString; }
    }
}
