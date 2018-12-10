using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreNumber;

    void Update () {
        scoreNumber.text = GameSession.currentScore.ToString();
        GameSession.Destroy(this);
	}
}
