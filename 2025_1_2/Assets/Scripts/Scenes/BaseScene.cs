using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    [Header("Scene Setting")]
    [SerializeField] protected Define.Scene _sceneType;
    public Define.Scene SceneType => _sceneType;

    protected virtual void Start()
    {
        InitScene();
    }

    protected abstract void InitScene();
    public virtual void ClearScene() { }
}
