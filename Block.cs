using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
    
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites; 
    
    //cached reference
    level level;
    GameSession GameStatus;
    Ball ball;
    //state vars
    [SerializeField] int timesHit; //TODO only serialized for debugging


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        HandleHit();
    }

    private void HandleHit()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                GameStatus = FindObjectOfType<GameSession>();
                GameStatus.AddToScore();
                TriggerSparklesVFX();
                DestroyBlock();
                ball = FindObjectOfType<Ball>();
                ball.Velocity();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing from array"+ gameObject.name);
        }
        }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}