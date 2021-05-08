using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] audioClips;

    Vector2 paddleToBall = new Vector2();
    private bool isLaunched = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        startGame();
    }

    private void startGame()
    {
        if (!isLaunched)
        {
            lockBallToPaddle();
            launchBall();
        }
    }

    private void launchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            isLaunched = true;
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLaunched)
        {

            audioSource.PlayOneShot(audioClips[UnityEngine.Random.Range(0, audioClips.Length)]);
        }
    }
}
