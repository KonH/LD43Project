using UDBase.Installers;
using ViewModels;

namespace Utils {
	public class SceneInstaller : UDBaseSceneInstaller {
		public WaypointSet Waypoints;
		public SpawnPointSet Spawnpoints;
		public BloodViewModel BloodViewModel;
		
		public override void InstallBindings() {
			AddDirectSceneLoader();
			AddEmptyLogger();
			AddEvents();
			Container.BindInstance(Waypoints);
			Container.BindInstance(Spawnpoints);
			Container.BindInstance(BloodViewModel);
		}
	}
}