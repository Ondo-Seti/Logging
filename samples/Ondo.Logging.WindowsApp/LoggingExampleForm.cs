using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace Ondo.Logging.WindowsApp
{
    public partial class LoggingExampleForm : Form
    {
        public LoggingExampleForm()
        {
            InitializeComponent();
        }

        private void btnLogError_Click(object sender, EventArgs e)
        {
            var logger = ApplicationLogging.CreateLogger<LoggingExampleForm>();
            logger.LogError(new EventId(), new StackOverflowException("Exception with inner exception", new ArgumentNullException("Argument missing")), "Error from windows applicaiton");
                        
        }
    }
}
