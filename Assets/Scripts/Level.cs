using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;

    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        GetNumberOfBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetNumberOfBlocks()
    {
        numberOfBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
        Debug.Log(numberOfBlocks);
    }

    internal void DestroyBlock()
    {
        numberOfBlocks--;
        if(numberOfBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
