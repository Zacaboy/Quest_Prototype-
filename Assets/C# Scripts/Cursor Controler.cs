using UnityEngine;

public class CursorUnlocker : MonoBehaviour
{
    public static bool inMainMenu = true; // Set this to true when in the main menu

    private void Update()
    {
        if (inMainMenu)
        {
            UnlockCursor();
        }
        else
        {
            LockCursor();
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
