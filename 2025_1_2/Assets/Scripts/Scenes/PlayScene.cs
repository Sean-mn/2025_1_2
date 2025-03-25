public class PlayScene : BaseScene
{
    protected override void InitScene()
    {
        _sceneType = Define.Scene.Play;

        Managers.Util.LockCursor();
        Timers.Instance.StartTimer();
    }

    public override void ClearScene()
    {
        Timers.Instance.StopTimer();
    }
}
