using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklingVFX;
    [SerializeField] int maxHits = 2;
    [SerializeField] Sprite[] hitSprites;
    //State Variable
    [SerializeField] int timesHits = 0;

    level level;
    GameStatus GameStatus;
 
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.countBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHits++;
        if (timesHits >= maxHits)
        {
            destroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void destroyBlock()
    {  


            PlayBlockDestroySFX();
            Destroy(gameObject);
            level.BlockDestroyed();
            triggerSparklesVFX();
        
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklingVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }
}
