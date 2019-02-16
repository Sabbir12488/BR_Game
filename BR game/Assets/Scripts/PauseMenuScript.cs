using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class PauseMenuScript : MonoBehaviour

{
    public GameObject PausedMenuUI;
    public static bool GameIsPaused = false;

    // Use this for initialization
    void Start()
    {

    }
    public void Update() // ask for help with the points.
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();


            }
            else
            {

                Pause();

            }



        }

    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.None; 
        PausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        PausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        Debug.Log("Menu loading...");
        PausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void QuitGame()
    {

        Debug.Log("Quiting menu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void Options()
    {
        Debug.Log("Working on it"); 
    }

}
