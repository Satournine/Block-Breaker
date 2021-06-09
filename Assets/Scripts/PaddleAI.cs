using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    
    public GameObject ballLocation;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 ballPosition = new Vector2(ballLocation.transform.position.x, 11.5f);
       
            transform.position = ballPosition;
       // Vector2 paddlePosition = new Vector2(pad)
    }
}
