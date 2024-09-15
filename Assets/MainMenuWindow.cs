using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuWindow : MonoBehaviour
{
    private Text scoreText;

    private void Awake() 
    {
        scoreText = transform.Find("Score").GetComponent<Text>();
    }
    private void Update() 
    {
        if (Snake.score != null) 
        {
            scoreText.text = "Your score: " + Snake.GetScore().ToString();
        }
    }
    public void LoadGame() {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void ShowRules() {
        SceneManager.LoadScene("ShowRules", LoadSceneMode.Single);
    }

    public void Quit() {
        Application.Quit();
    }
}
