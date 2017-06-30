namespace Ondo.Logging.Abstractions
{
    public class Console : CommonOptions
    {
        public Console()
        {
            this.Include = Defaults.INCLUDE_CONSOLE;
        }
    }
}
