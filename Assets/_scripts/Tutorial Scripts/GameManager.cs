using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ScoreManager scoreManager;

    public GameObject player;
    public List<GameObject> targets = new List<GameObject>();
    float gameTimer;

    enum Gamestate { Start, Playing, GameOver };
    Gamestate gamestate;
    // Start is called before the first frame update
    void Start()
    {
        gamestate = Gamestate.Start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gamestate)
        {
            case Gamestate.Start:
                {
                    gameTimer = 0;
                    gamestate = Gamestate.Playing; 
                    break;
                }
            case Gamestate.Playing: 
                {
                    gameTimer += Time.deltaTime;

                    int seconds = Mathf.RoundToInt(gameTimer);
                    bool gameOver = true;

                    for (int i =0; i < targets.Count; i++)
                    {
                        if (targets[i].activeSelf == true)
                        {
                            gameOver = false;
                        }
                    }
                    if (gameOver)
                    {
                        gamestate = Gamestate.GameOver;

                        scoreManager.AddScoreToHighScores(seconds);
                        scoreManager.SaveScoresToFile();
                    }
                    break;
                }
            case Gamestate.GameOver: 
                {
                    Debug.Log("Game finished");

                    break;
                }

        }
    }
}
