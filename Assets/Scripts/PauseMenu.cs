using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame(InputAction.CallbackContext ctx)
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Debug.Log("Paused");
        if(pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    } 
    
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("In build this will quit the game");
    }
}
