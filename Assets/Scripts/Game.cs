using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// credit to Michael Guerrero

public class Game : MonoBehaviour
{
    public Transform ball;
    public float speed = 3f;
    private Vector3 ballPos;
    
    public Trigger leftTrigger;
    public Trigger RightTrigger;

    private int player1 = 0;
    private int player2 = 0;

    private AudioSource audioSource;
    public AudioClip playerScoreSound;
    
    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.position;
        Rigidbody body = ball.GetComponent<Rigidbody>();
        body.velocity = new Vector3(1f, 0f, 0f) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log($"We Hit");
            
            ballPos = ball.position;
            Rigidbody body = ball.GetComponent<Rigidbody>();
            body.velocity = new Vector3(1f, 0f, 0f) * 5f;
            
            other.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    public void OnTrigger(Trigger trigger)
    {
        if (trigger == RightTrigger)
        {
            player2 += 1;
            GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>().SetText("Player 2 Score: " + player2.ToString());
            Debug.Log($"Player 2 scored: {player2}");

            if (player2 == 5)
            {
                GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>().color = Color.green;  
            }
            if (player2 == 9)
            {
                GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>().color = Color.red;  
            }
            
            if (player2 == 11)
            {
                GameObject.Find("Player2Wins").GetComponent<TextMeshProUGUI>().SetText("Player 2 Wins");
                Debug.Log("Player 2 wins!");
            }
            else
            {
                Reset(-1f);
            }
        }
        else if (trigger == leftTrigger)
        {
            player1 += 1;
            GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>().SetText("Player 1 Score: " + player1.ToString());
            Debug.Log($"Player 1 scored: {player1}");
            
            if (player1 == 5)
            {
                GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>().color = Color.green;
            }
            if (player1 == 9)
            {
                GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            
            if (player1 == 11)
            {
                GameObject.Find("Player1Wins").GetComponent<TextMeshProUGUI>().SetText("Player 1 Wins" );
                Debug.Log("Player 1 wins!");
            }
            else
            {
                Reset(-1f);
            }
        }
    }

    private void Reset(float direction)
    {
        ball.position = ballPos;

        direction = Mathf.Sign(direction);
        Vector3 newDirection = new Vector3(direction, 0f, 0f) * speed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rb = ball.GetComponent<Rigidbody>();
        rb.velocity = newDirection;
        rb.angularVelocity = new Vector3();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
