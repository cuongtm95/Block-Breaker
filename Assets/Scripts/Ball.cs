using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] Sprite[] ballShapes;
    [SerializeField] float randomBounceFactor = 0.2f;

    //state
    Vector3 paddleToBallVector;
    Boolean hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        Sprite balls = ballShapes[UnityEngine.Random.Range(0, ballShapes.Length)];
        GetComponent<SpriteRenderer>().sprite = balls;
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, 1);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomBounceFactor),
                                            UnityEngine.Random.Range(0f, randomBounceFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }

}
