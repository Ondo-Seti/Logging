namespace Ondo.Logging.Abstractions
{
    public class RollingFile : CommonOptions    {

        public RollingFile() { this.Include = Defaults.INCLUDE_FILE; }

        /// <summary>        
        ///   
        /// </summary>
        /// <value>Default value is <see cref="Defaults.FILE_NAME"/></value>
        public string RollingFilePath { get; set; } = Defaults.FILE_NAME;

        /// <summary>The MaxNumberOfFilesToKeep property represents number of days the rolling files will be kept on disk</summary>
        /// <value>Default value is <see cref="Defaults.MAX_NUMBER_OF_FILES_TO_KEEP"/></value>
        public int? MaxNumberOfFilesToKeep { get; set; } = Defaults.MAX_NUMBER_OF_FILES_TO_KEEP;
        /// <summary>
        /// Default value is 1 MB (1024 x 1024 bytes)
        /// </summary>
        public long? FileSizeLimitInBytes { get; set; } = Defaults.ONE_MEGABYTE;
    }
}
