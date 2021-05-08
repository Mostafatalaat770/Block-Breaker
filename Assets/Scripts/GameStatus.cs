using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int pointsPerBlock = 10;
    [SerializeField] TextMeshProUGUI scoreLabel;

    private void Awake()
    {
        if(FindObjectsOfType<GameStatus>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void UpdateScore()
    {
        score += pointsPerBlock;
        scoreLabel.SetText(score.ToString());
    }
    public void Reset()
    {
        Destroy(gameObject);
    }
}
