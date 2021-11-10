using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SBodyPrefab;
    [SerializeField] private UIManager m_ui;

    [SerializeField] private float MoveSpeed = 3f;
    private float timeDelay;
    
    [HideInInspector] public float score = 0; 
    
    private Vector2 direction = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private LinkedList<Transform> tailbits = new LinkedList<Transform>();
    private bool hasEaten = false;

    void Start()
    {
        timeDelay = Time.time + 1/MoveSpeed;
    }
    
    void Update()
    {
        if (timeDelay < Time.time) Move();
        
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && direction != Vector2.left) direction = Vector2.right;
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && direction != Vector2.right) direction = Vector2.left;
        else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && direction != Vector2.down ) direction = Vector2.up;
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && direction != Vector2.up) direction = Vector2.down;
        
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
        
        else if (other.tag == "Bomb" && tail.Count > 1 )
        {
            score--;
            var chopped= tail.GetRange(tail.Count - (Mathf.RoundToInt(tail.Count / 2) + 1), Mathf.RoundToInt(tail.Count / 2) );
            tail.GetRange(tail.Count - (Mathf.RoundToInt(tail.Count / 2) + 1), Mathf.RoundToInt(tail.Count / 2) );
            foreach (var tailComponent in chopped)
            {
                Destroy(tailComponent.gameObject);
            }
            
            tail.RemoveRange(tail.Count - (Mathf.RoundToInt(tail.Count / 2) + 1), Mathf.RoundToInt(tail.Count / 2) );
            Destroy(other.gameObject);
            m_ui.NewScoreText.text = score.ToString();
        }

        else
        {
            m_ui.GameOver();
            if (PlayerPrefs.GetFloat("HighScore") == null || score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", score);
                m_ui.HiScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
            }
        }
    }

    void Move()
    {
        Vector2 nextPos = transform.position;
        
        transform.Translate(direction);

        if (hasEaten)
        {
            GameObject newSegment = Instantiate(SBodyPrefab, nextPos, Quaternion.identity);
            tail.Insert(0, newSegment.transform);
            hasEaten = false;
        }

        else if (tail.Count > 0 && !hasEaten)
        {
            // tail.Last().position = gapPos;
            // tail.Insert(0,tail.Last());
            // tail.RemoveAt(tail.Count - 1);
            
            foreach (var tailSegment in tail)
            {
                Vector2 gapPos = tailSegment.position;
                tailSegment.position = nextPos;
                nextPos = gapPos;
            }
        }

        timeDelay += 1/MoveSpeed;
    }
}
