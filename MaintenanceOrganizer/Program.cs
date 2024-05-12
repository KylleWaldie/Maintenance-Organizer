namespace MaintenanceOrganizer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initializes the form
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenuForm());
        }
    }
}