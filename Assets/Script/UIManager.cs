using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MyEvent : UnityEvent<GameObject>
{
}
public class UIManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text PrevHiScore;
    [SerializeField] private TMP_Text ScoreText;

    [Header("Panels")] 
    [SerializeField] private Canvas PausePanel;
    [SerializeField] private Canvas GameOverPanel;



    public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
