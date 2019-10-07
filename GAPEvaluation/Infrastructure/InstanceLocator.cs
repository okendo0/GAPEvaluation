namespace GAPEvaluation.Infrastructure
{
    using GAPEvaluation.ViewModels;

    /// <summary>
    /// To instanciate the MainViewModel class
    /// </summary>
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}