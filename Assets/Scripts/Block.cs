using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparklesVFX;
   Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        if (tag == "Block")
        {
            Destroy(gameObject);
            TriggerSparklesVFX();
            level.DestroyBlock();
            FindObjectOfType<GameStatus>().UpdateScore();
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
    }
}
