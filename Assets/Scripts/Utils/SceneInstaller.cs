using ViewModels;
using Zenject;

namespace Utils {
	public class SceneInstaller : MonoInstaller {
		public WaypointSet Waypoints;
		public BloodViewModel BloodViewModel;
		
		public override void InstallBindings() {
			Container.BindInstance(Waypoints);
			Container.BindInstance(BloodViewModel);
		}
	}
}