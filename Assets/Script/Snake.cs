using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SBodyPrefab;
    [SerializeField] private UIManager m_ui;

    [SerializeField] private float MoveSpeed = 0.3f;
    
    private Vector2 direction = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private bool hasEaten = false;
    

    void Start()
    {
        InvokeRepeating("Move", MoveSpeed, MoveSpeed );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) direction = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) direction = Vector2.left;
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) direction = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) direction = Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            hasEaten = true; 
            Destroy(other.gameObject);
        }

        else
        {
            m_ui.GameOver();
        }
    }

    void Move()
    {
        Vector2 gapPos = transform.position;
        
        transform.Translate(direction);

        if (hasEaten)
        {
            GameObject newSegment = Instantiate(SBodyPrefab, gapPos, Quaternion.identity);
            tail.Insert(0, newSegment.transform);
            hasEaten = false;
        }

        else if (tail.Count > 0 && !hasEaten)
        {
            tail.Last().position = gapPos;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        
    }
}
