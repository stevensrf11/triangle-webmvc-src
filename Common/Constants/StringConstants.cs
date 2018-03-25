namespace Common.Constants
{
    public static class SchemeTypes
    {
        public const string Basic = "basic";
    }
    public static class StringConstants
    {
        /// <summary> Symbolic link symbol</summary>
        public const string SymlinkArrow = "->";

        /// <summary> Indicates symbolic link</summary>
        public const char SymlinkChar = 'l';

        /// <summary> Indicates ordinary file</summary>
        public const char OrdinaryFileChar = '-';

        /// <summary> Indicates directory</summary>
        public const char DirectoryChar = 'd';

        /// <summary>Date format</summary>
        public const string Format = "d MMM yyyy HH:mm:ss.fff";

        /// <summary>Date format 1</summary>
        public const string Format1A = "MMM'-'d'-'yyyy";

        /// <summary>Date format 1</summary>
        public const string Format1B = "MMM'-'dd'-'yyyy";

        /// <summary>Date format 2</summary>
        public const string Format2A = "MMM'-'d'-'yyyy'-'HH':'mm";

        /// <summary>Date format 2</summary>
        public const string Format2B = "MMM'-'dd'-'yyyy'-'HH':'mm";

        /// <summary>Date format 2</summary>
        public const string Format2C = "MMM'-'d'-'yyyy'-'H':'mm";

        /// <summary>Date format 2</summary>
        public const string Format2D = "MMM'-'dd'-'yyyy'-'H':'mm";

        /// <summary>Date format</summary>
        public const string Format1 = "MM'-'dd'-'yy hh':'mmtt";

        /// <summary>Date format</summary>
        public const string Format2 = "MM'-'dd'-'yy hh':'mm";

        /// <public> Directory field</summary>
        public const string Dir = "<DIR>";

        public const string OffStr = "OFF";
        public const string FatalStr = "FATAL";
        public const string ErrorStr = "ERROR";
        public const string WarnStr = "WARN";
        public const string InfoStr = "INFO";
        public const string DebugStr = "DEBUG";
        public const string ExceptionStr = "EXCEPTION";
        public const string AllStr = "ALL";

        ///// <summary> Windows server comparison string</summary>
        public const string WindowsStr = "WINDOWS";

        /// <summary> UNIX server comparison string</summary>
        public const string UnixStr = "UNIX";

        /// <summary> VMS server comparison string</summary>
        public const string VmsStr = "VMS";

        /// <summary> OS/400 server comparison string</summary>
        public const string Os400Str = "OS/400";
    }
}
