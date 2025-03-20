using UnityEngine;

public class Utility_Manager
{
    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerRotate.canRotate = true;
    }

    public void UnLockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerRotate.canRotate = false;
    }
}
