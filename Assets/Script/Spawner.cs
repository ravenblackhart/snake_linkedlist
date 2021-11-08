using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] Spawnables;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;

    [SerializeField] private float SpawnRate = 3f;
    [SerializeField] private float SpawnStart = 4f;

    [SerializeField] private Snake m_snake;

    void Start()
    {
        InvokeRepeating("Spawn", SpawnStart, SpawnRate);

    }

    void Spawn()
    {
        int x = (int) Random.Range(BorderLeft.position.x, BorderRight.position.x);
        int y = (int) Random.Range(BorderTop.position.y, BorderBottom.position.y);

        if (m_snake.score <= 5)
        {
            Instantiate(Spawnables[0], new Vector2(x, y), Quaternion.identity);
        }

        else
        {
            Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], new Vector2(x, y), Quaternion.identity);
        }
    }
}
