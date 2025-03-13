using UnityEngine;

public class PlayScene : BaseScene
{
    protected override void InitScene()
    {
        _sceneType = Define.Scene.Play;

        Managers.Util.LockCursor();
    }

    public override void ClearScene()
    {

    }
}
