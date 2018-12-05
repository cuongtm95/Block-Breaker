using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    float mousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector3 paddlePos = new Vector3(mousePos, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(paddlePos.x, 0, 16);
        transform.position = paddlePos;
	}
}
