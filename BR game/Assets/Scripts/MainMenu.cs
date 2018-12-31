using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // this can be changed by using the build method
    }

    public void ExitGame()
    {
        Debug.Log("You have closed the program"); 
        Application.Quit(); // shuts down the program
    }

}
