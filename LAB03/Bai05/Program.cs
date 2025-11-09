namespace Bai05
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DialogResult result = MessageBox.Show(
               "Chọn Yes để chạy Server\nChọn No để chạy Client",
               "Chọn chế độ chạy",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
                Application.Run(new Server());
            else
                Application.Run(new Client());
        }
    }
}