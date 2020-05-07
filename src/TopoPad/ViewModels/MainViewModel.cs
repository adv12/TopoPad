using Dock.Model;
using Dock.Model.Controls;

namespace TopoPad.ViewModels
{
    public class MainViewModel : RootDock
    {
        public override IDockable Clone()
        {
            var mainViewModel = new MainViewModel();

            CloneHelper.CloneDockProperties(this, mainViewModel);
            CloneHelper.CloneRootDockProperties(this, mainViewModel);

            return mainViewModel;
        }
    }
}
