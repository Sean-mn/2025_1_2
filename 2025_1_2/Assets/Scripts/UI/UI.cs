using System.Collections;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    protected virtual void Awake()
    {
        InitUI();
    }

    protected abstract void InitUI();
    public virtual void UIFunction()
    {

    }
    public virtual IEnumerator UIFunctionCor()
    {
        yield return null;
    }
}
