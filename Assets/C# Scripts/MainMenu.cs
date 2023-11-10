using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        // Set inMainMenu to false when playGame is executed
        CursorUnlocker.inMainMenu = false;

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }

    public void Ouit()
    {
        Application.Quit();
    }
}
