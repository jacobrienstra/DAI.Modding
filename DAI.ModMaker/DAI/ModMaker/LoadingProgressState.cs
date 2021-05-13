namespace DAI.ModMaker
{
    public class LoadingProgressState
    {
        public bool UpdateStatus;

        public bool UpdateProgress;

        public bool UpdateLog;

        public string StatusText;

        public string LogText;

        public LoadingProgressState(bool InUpdateStatus, bool InUpdateProgress, bool InUpdateLog, string InStatusText, string InLogText)
        {
            UpdateStatus = InUpdateStatus;
            UpdateProgress = InUpdateProgress;
            UpdateLog = InUpdateLog;
            StatusText = InStatusText;
            LogText = InLogText;
        }
    }
}
