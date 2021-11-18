using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Spawnables;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;

    [SerializeField] private float SpawnRate = 3f;
    [SerializeField] private float SpawnStart = 2f;

    [SerializeField] private Snake m_snake;

    public Transform[] objectsList;
    private Vector2 instantiatePos;

    void Start()
    {
        InvokeRepeating("Spawn", SpawnStart, SpawnRate);

    }

    void Spawn()
    {
        int x = (int) Random.Range(BorderLeft.position.x + 1 , BorderRight.position.x - 1);
        int y = (int) Random.Range(BorderTop.position.y - 1 , BorderBottom.position.y + 1 );

        instantiatePos = new Vector2(x, y);

        objectsList = gameObject.GetComponents<Transform>();

        foreach (Transform spawnedObj in objectsList)
        {
            if ((Vector2)spawnedObj.transform.localPosition == instantiatePos) return;
            else
            {
                if (m_snake.score <= 5 || GameObject.FindGameObjectsWithTag("Food").Length < 5)
                {
                    Instantiate(Spawnables[0], instantiatePos, Quaternion.identity);
                }

                else
                {
                    Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], instantiatePos, Quaternion.identity);
                }
            }
        }
        
    }
    
}
