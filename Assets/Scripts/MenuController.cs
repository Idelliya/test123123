using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Text Highscore1;
    public Text Highscore2;
    public Text Highscore3;
    public Text CurrentScore;


    // Start is called before the first frame update
    void Start()
    {
        if (CurrentScore.text != null)
            CurrentScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();

        if (Highscore1.text != null)
            Highscore1.text = PlayerPrefs.GetInt("highscore1").ToString();

        if (Highscore2.text != null)
            Highscore2.text = PlayerPrefs.GetInt("highscore2").ToString();

        if (Highscore3.text != null)
            Highscore3.text = PlayerPrefs.GetInt("highscore3").ToString();

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("level");
    }
    public void PlayCustomGame()
    {
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        DataStorage.ClearValue();
        PlayerPrefs.SetInt("GameMode", 0);
        Application.Quit();
    }

    public void Pause()
    {
        DataStorage.ClearValue();
        PlayerPrefs.SetInt("GameMode", 0);
        SceneManager.LoadScene("MainMenu");
    }


}
