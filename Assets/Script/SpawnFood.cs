using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;

    [SerializeField] private float SpawnRate = 3f;
    [SerializeField] private float SpawnStart = 4f;
    
    void Start()
    {
        InvokeRepeating("Spawn", SpawnStart, SpawnRate);
    }

    void Spawn()
    {
        int x = (int) Random.Range(BorderLeft.position.x, BorderRight.position.x);
        int y = (int) Random.Range(BorderTop.position.y, BorderBottom.position.y);

        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
