using System.Collections.Generic;

namespace SpaceLaunchTracker.Data.ApiModels.LaunchLibrary.Launches
{
    /// <summary>
    /// GET request for getting ten next launches
    /// https://launchlibrary.net/1.4/launch
    /// </summary>
    public class LaunchLibraryCollection
    {
        public List<LibraryLaunchModel> Launches { get; set; }
    }
}
