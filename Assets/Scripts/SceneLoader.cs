using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScence()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void playAgain()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().resetGame();
        
    }

}
