using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.PackageManager.Requests;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int niveau = 1;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private int brickLayer = 10; 

    [SerializeField]
    private GameObject balle;
    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject YouWinUI;
    [SerializeField]
    private GameObject[] Object;

    [SerializeField]
    private bool present = true;

    public List<GameObject> bricks = new List<GameObject>();

    public Ball ball { get; private set; }
    public Barre barre { get; private set; }


//Fonction called before the start, on awake.   
    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

//Fonctions called at the start.   
    private void Start()
    {
        GameReset();
    }
//Update is called once per frame
    public void Update()
    {
        YouWin();
    }
//Remove game objects from "destroyonload" for save them when we restart the game.    
    private void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in Object)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
//Reset the score the lives count at 0.
    private void GameReset()
    {
        this.score = 0;
        this.lives = 0;
    }
//Restart the ball and the bar position.
    private void ResetLevel()
    {
        ball.ResetBall();
        barre.ResetBarre();
    }
//Activation of the winning UI.
    private void YouWin()
    {
        if(present == false)
        { 
        Destroy(balle);
        YouWinUI.SetActive(true);
        }
    }
//Bricks counter on the stage.
    public void Win()
    {
            if (bricks.Count == 0)
            {
               present = false;
            }
    }
//Activation of the game over UI.   
    private void GameOver()
    {
     Destroy(balle);
     GameOverUI.SetActive(true);
    }

    public void Dead()
    {
        lives--;
        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
//UI fonction for gange level.
    public void NextLevel(int niveau)
    {
        this.niveau = niveau;
        SceneManager.LoadScene("Niveau" + niveau);
    }
//UI foction for restart a current level.
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverUI.SetActive(false);
        YouWinUI.SetActive(false);
    }
//UI fonction for quit the game.
    public void QuitGame()
    {
        Application.Quit();
    }
    

}
