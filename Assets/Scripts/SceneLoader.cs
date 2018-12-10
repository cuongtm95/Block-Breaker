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

    public void credit()
    {
        SceneManager.LoadScene(6);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void playAgain()
    {
        SceneManager.LoadScene(0);
    }

    // Transition scene
    public Animator transitionAnim;

    public void triggerTransition()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        LoadNextScence();
    }



}
