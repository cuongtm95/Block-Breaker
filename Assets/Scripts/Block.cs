using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;

    //cached reference
    Level level;
    GameStatus gamestatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gamestatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlocks();
        gamestatus.countScore();
    }

    private void DestroyBlocks()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0.0f);
        level.BlockDestroyed();
    }
}
