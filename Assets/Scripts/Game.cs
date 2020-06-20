using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
   

    public float FallSpeed = 1.0f;

    private int LinesCleared = 0;
    private int CurrentLevel = 0;

    public Text Score;
    public Text Level;
    public Text Lines;

    public static  bool IsPaused = false;

    private static int currentScore = 0;

    public int scoreOneLine = 40;
    public int scoreTwoLine = 100;
    public int scoreThreeLine = 300;
    public int scoreFourLine = 1200;

    private GameObject previewTetromino;
    private GameObject nextTetromino;
    private bool gameStarted = false;

   

    private int StartingHighscore1;
    private int StartingHighscore2;
    private int StartingHighscore3;

    private Vector2 previewTetrominoPosition = new Vector2(9f, 22);

    private List<int> FiguresPool;
    // Start is called before the first frame update
    void Start()
    {
        FiguresPool = DataStorage.GetValues();
       // Debug.Log(FiguresPool[0] + " " + FiguresPool[1] + " " + FiguresPool[2] + " " + FiguresPool[3] + " " + FiguresPool[4] + " " + FiguresPool[5] + " " + FiguresPool[6]);
        SpawnNextTetromino();
       
        StartingHighscore1 = PlayerPrefs.GetInt("highscore1");
        StartingHighscore2 = PlayerPrefs.GetInt("highscore2");
        StartingHighscore3 = PlayerPrefs.GetInt("highscore3");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateUI();
        UpdateLevel();
        UpdateSpeed();
    }

    public void Pause()
    {
        if (Time.timeScale ==1)
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
        else 
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
    }
    public void UpdateLevel ()
    {
        CurrentLevel = LinesCleared / 10;
        //Debug.Log(FallSpeed);
    }
    public void UpdateSpeed()
    {
        FallSpeed = 1.0f - ((float)CurrentLevel * 0.1f);

    }
    public void UpdateUI()
    {
        Score.text = currentScore.ToString();
        //Lines.text = LinesCleared.ToString();
        Level.text = CurrentLevel.ToString();
    }


    public void UpdateScore()
    {
        if (FindObjectOfType<Grid>().GetnumberOfRowsThisTurn() > 0)
        {
            if (FindObjectOfType<Grid>().GetnumberOfRowsThisTurn() == 1)
            {
                ClearedOneLine();
            }
            else if (FindObjectOfType<Grid>().GetnumberOfRowsThisTurn() == 2)
            {
                ClearedTwoLine();
            }
            else if (FindObjectOfType<Grid>().GetnumberOfRowsThisTurn() == 3)
            {
                ClearedThreeLine();
            }
            else if (FindObjectOfType<Grid>().GetnumberOfRowsThisTurn() == 4)
            {
                ClearedFourLine();
            }
            FindObjectOfType<Grid>().SetnumberOfRowsThisTurn(0);

            UpdateHighscore();
          
        }
    }

    void ClearedOneLine()
    {
        currentScore += scoreOneLine;
        LinesCleared++;
    }
    void ClearedTwoLine()
    {
        currentScore += scoreTwoLine;
        LinesCleared += 2;
    }
    void ClearedThreeLine()
    {
        currentScore += scoreThreeLine;
        LinesCleared += 3;
    }
    void ClearedFourLine()
    {
        currentScore += scoreFourLine;
        LinesCleared += 4;
    }

    public void UpdateHighscore()
    {
        if(currentScore> StartingHighscore1)
        {
            PlayerPrefs.SetInt("highscore3", StartingHighscore2);
            PlayerPrefs.SetInt("highscore2", StartingHighscore1);
            PlayerPrefs.SetInt("highscore1", currentScore);
        }
            else if(currentScore>StartingHighscore2)
              {
                PlayerPrefs.SetInt("highscore3", StartingHighscore2);
                PlayerPrefs.SetInt("highscore2", currentScore);
              }
            else if (currentScore> StartingHighscore3)
                {
                    PlayerPrefs.SetInt("highscore3", currentScore);
                }
    }

    

   

    string GetRandomTetermino()
    {
        int randomTetermino = Random.Range(1, 8);
        
        string randomTetrominoName = "Prefarbs/Tetermino_T";
        Debug.LogError(PlayerPrefs.GetInt("GameMode"));
        if (PlayerPrefs.GetInt("GameMode") == 1)
            while (!FiguresPool.Contains(randomTetermino))
                randomTetermino = Random.Range(1, 8);

        switch (randomTetermino)
        {
            case 1:
                randomTetrominoName = "Prefabs/J-Tetromino 1";
                break;
            case 2:
                randomTetrominoName = "Prefabs/L-Tetromino";
                break;
            case 3:
                randomTetrominoName = "Prefabs/Long-Tetromino";
                break;
            case 4:
                randomTetrominoName = "Prefabs/S-Tetromino";
                break;
            case 5:
                randomTetrominoName = "Prefabs/Square-Tetromino";
                break;
            case 6:
                randomTetrominoName = "Prefabs/T-Tetromino";
                break;
            case 7:
                randomTetrominoName = "Prefabs/Z-Tetromino";
                break;

        }
        return randomTetrominoName;
    }

    public void SpawnNextTetromino()
    {

        if (!gameStarted)
        {
            gameStarted = true;

            nextTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetermino(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
            previewTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetermino(), typeof(GameObject)), previewTetrominoPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;

        }
        else
        {
            previewTetromino.transform.localPosition = new Vector2(5.0f, 20.0f);
            nextTetromino = previewTetromino;
            nextTetromino.GetComponent<Tetromino>().enabled = true;

            previewTetromino = (GameObject)Instantiate(Resources.Load(GetRandomTetermino(), typeof(GameObject)), previewTetrominoPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;
        }

    }

   

    public void GameOver()
    {
        
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        UpdateHighscore();
        SceneManager.LoadScene("GameOver2");
        
    }

}
