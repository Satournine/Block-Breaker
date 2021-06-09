using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] int breakableBlock;
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void countBreakableBlocks()
    {
        breakableBlock++;
    }

    public void BlockDestroyed()
    {
        breakableBlock--;
        if(breakableBlock <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
