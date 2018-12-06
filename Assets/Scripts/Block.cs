using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] int blockHps;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession gamestatus;

    int hits;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gamestatus = FindObjectOfType<GameSession>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        countHits();
        triggerBlockVFX();
        gamestatus.countScore();
    }

    private void DestroyBlocks()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject, 0.0f);
        level.BlockDestroyed();
    }

    private void triggerBlockVFX()
    {
        GameObject blockvfx = Instantiate(blockVFX, transform.position, transform.rotation);
    }

    private void countHits()
    {
        hits++;
        if(hits >= blockHps)
        {
            DestroyBlocks();
        }
        else
        {
            DisplayNextSprites();
        }
    }

    private void DisplayNextSprites()
    {
        int spriteIndex = hits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
