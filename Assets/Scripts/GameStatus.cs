using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f,5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlocks = 53;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreNumber;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
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
        Time.timeScale = gameSpeed;
	}

    public void countScore()
    {
        currentScore = currentScore + pointsPerBlocks;
        scoreNumber.text = currentScore.ToString();
    }
}
