namespace SSCDeploy.Actions
{
    public class DeployProgressReport
    {
        //current progress
        public int CurrentProgressAmount { get; set; }

        //some message to pass to the UI of current progress
        public string CurrentProgressMessage { get; set; }
    }
}
