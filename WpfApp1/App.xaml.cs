using System;
using System.Threading;
using System.Windows;

namespace RustImageLibrary
{
    public partial class App : Application
    {
        // Declare a mutex variable
        private static Mutex mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string mutexName = "Global\\RustImageLibrarySingleInstanceMutex"; // Use 'Global' prefix

            // Create the mutex and check if another instance is already running
#pragma warning disable IDE0018 // Inline variable declaration
            bool createdNew;
#pragma warning restore IDE0018 // Inline variable declaration
            mutex = new Mutex(true , mutexName , out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("Rust Image Library is already running !");
                Current.Shutdown();
                return;
            }

            base.OnStartup(e);
        }
    }
}
