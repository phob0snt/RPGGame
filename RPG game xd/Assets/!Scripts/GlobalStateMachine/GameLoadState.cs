using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadState : BaseGlobalState
{
    public async override void OnEnter()
    {
        await LoadBootScene();
        Debug.Log("Entered loading");
        await LoadGameScene();
        Debug.Log("Loaded game scene");
        await UnloadBootScene();
        Debug.Log("Unloaded boot");
        _stateMachine.SwitchState<GameplayState>();
        EventManager.Broadcast(new SceneLoadedEvent());
    }

    private async Task UnloadBootScene()
    {
        await SceneManager.UnloadSceneAsync("Boot");
    }

    private async Task LoadBootScene()
    {
        await SceneManager.LoadSceneAsync("Boot", LoadSceneMode.Single);
    }

    private async Task LoadGameScene()
    {
        await SceneManager.LoadSceneAsync("mainScene", LoadSceneMode.Additive);
    }
}
