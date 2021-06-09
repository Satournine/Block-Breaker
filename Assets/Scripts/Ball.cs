using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioSource startSound;
    [SerializeField] AudioSource colisSound;
    Vector2 paddleToBallVector;
     bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        AudioSource[] audios = GetComponents<AudioSource>();
        startSound = audios[1];
        colisSound = audios[0];
    }

    // Update is called once per frame
    void Update()
    {
      if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
            startSound.Play();
        }
    }

     private void LockBallToPaddle()
    {
        
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        colisSound.Play(); 
    }
}
