using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Script.Custom;


public class Snake : MonoBehaviour
{
    public GameObject SBodyPrefab;
    [SerializeField] private UIManager m_ui;

    [SerializeField] private float MoveSpeed = 3f;
    private float timeDelay;


    [HideInInspector] public float score = 0; 
    
    private Vector2 direction = Vector2.right;
    private LinkedList<Transform> tail = new LinkedList<Transform>();
    private SlinkList<Transform> tailbits = new SlinkList<Transform>();
    private bool hasEaten = false;

    void Start()
    {
        timeDelay = Time.time + 1/MoveSpeed;
    }
    
    void Update()
    { 
        if (timeDelay < Time.time) Move();

        
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && direction != Vector2.down ) direction = Vector2.up;
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && direction != Vector2.left) direction = Vector2.right;
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && direction != Vector2.right) direction = Vector2.left;
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && direction != Vector2.up) direction = Vector2.down;

    }
    
    void Move()
    {
        Vector2 nextPos = transform.position;
        
        transform.Translate(direction);

        if (hasEaten)
        {
            GameObject newSegment = Instantiate(SBodyPrefab, nextPos, Quaternion.identity);
            tailbits.AddFirst(newSegment.transform);
            hasEaten = false;
        }

        else if (tailbits.getCount() > 0 && !hasEaten)
        {
            var tempHead = tailbits.First;

            while (tempHead != null)
            {
                Vector2 gapPos = tempHead.objectData.position;
                tempHead.objectData.position = nextPos;
                nextPos = gapPos;
                tempHead = tempHead.next;
            }
        }

        timeDelay += 1/MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            hasEaten = true;
            score++;
            Destroy(other.gameObject);
            m_ui.NewScoreText.text = score.ToString();
        }
        
        else if (other.tag == "Boost")
        {
            MoveSpeed += 0.5f;
            Destroy(other.gameObject);
        }

        else if (other.tag == "Bomb" && tailbits.getCount() > 1 )
        {
            score--;
            int newSize = Mathf.RoundToInt(tailbits.getCount() / 2);
            while (tail.Count > newSize)
            {
                var xtail = tailbits.Last;
                tailbits.RemoveLast();
                Destroy(xtail.objectData.gameObject);
                
            }
            
            Destroy(other.gameObject);
            m_ui.NewScoreText.text = score.ToString();
        }

        else
        {
            m_ui.GameOver();
            if (!PlayerPrefs.HasKey("HighScore") || score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", score);
                m_ui.HiScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
            }
        }
    }

    
}
