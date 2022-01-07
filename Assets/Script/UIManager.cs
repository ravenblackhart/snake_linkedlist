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
            public TMP_Text NewScoreText;
            public TMP_Text HiScoreText;
            [SerializeField] private TMP_Text PauseButton;
        
            [Header("Panels")] 
            [SerializeField] private Canvas PausePanel;
            [SerializeField] private Canvas GameOverPanel;
            [SerializeField] private Canvas ReadyPanel;
            
        
            private void Awake()
            {
                Time.timeScale = 0;
                ReadyPanel.enabled = true;
                GameOverPanel.enabled = false;
                PausePanel.enabled = false;
        
                NewScoreText.text = "0";
                HiScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
            }
            
        
            public void Play()
            {
                Time.timeScale = 1f;
                ReadyPanel.enabled = false;
            }
        
            public void Restart()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
            public void Pause()
            {
                if (PausePanel.isActiveAndEnabled)
                {
                    PausePanel.enabled = false;
                    Time.timeScale = 1f;
                    PauseButton.text = "Pause";
        
                }
                
                else
                {
                    PausePanel.enabled = true;
                    Time.timeScale = 0f;
                    PauseButton.text = "Resume";
                }
            }
            
            public void GameOver()
            {
                GameOverPanel.enabled = true;
                Time.timeScale = 0;
                
            }
        
            public void Quit()
            {
                Application.Quit();
            }
    }