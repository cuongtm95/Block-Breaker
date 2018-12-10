using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [Range(0.1f,5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlocks = 53;
    [SerializeField] public static int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreNumber;
    public string gameoverScene = "Game Over";
    Scene m_scene;


    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void resetGame()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        scoreNumber.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        m_scene = SceneManager.GetActiveScene();
        if (m_scene.name == gameoverScene)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        Time.timeScale = gameSpeed;
	}

    public void countScore()
    {
        currentScore = currentScore + pointsPerBlocks;
        scoreNumber.text = currentScore.ToString();
    }
}
