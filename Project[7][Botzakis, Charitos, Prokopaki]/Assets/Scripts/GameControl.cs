using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public float timeLeft = 45.0f;
    public float bootsDuration = 5.0f;
    private bool isPaused;
    private bool P1_Buffed, P2_Buffed;
    private PlayerManager playerManager;
    private int P1_Score, P2_Score;
    private SCManager sceneManager;
    public GameObject sp1, sp2;
    private bool gameOver;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        sceneManager = GetComponent<SCManager>();
    }
    void Start()
    {
        P1_Score = 0;
        P2_Score = 0;
        P1_Buffed = false;
        P2_Buffed = false;
        isPaused = false;
        gameOver = false;
        resumeGame();
    }
  
    void Update()
    {
        if (!gameOver)
        {
            setPause();
            if (!isPaused)
            {
                playerManager.playerMovement();
                timerHandler();

            }
        }  

    }
    #region PAUSE CONTROL

    private void pauseGame()
    {
        isPaused = true;
        print("paused");
        Time.timeScale = 0; //set timescale to 0
        UImanager.Instance.setPausePanel(isPaused);
    }
    public void resumeGame()
    {
        
        isPaused = false;
        print("resumed");
        Time.timeScale = 1; //set timescale to 1
        UImanager.Instance.setPausePanel(isPaused);
    }

    private void setPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();
        }
        
    }

    #endregion
    private void disableControls()
    {
        gameOver = true;
        Time.timeScale = 0;
    }
    public void timerHandler()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {

            //  sceneManager.loadGameOver();
            UImanager.Instance.setGameOverPanel(P1_Score, P2_Score);
            disableControls();
            timeLeft = 45.0f;
        }
        UImanager.Instance.setTimer(timeLeft);
    }

    public void setPlayerScore(int index)
    {
        if (index == 1)
        {
            P1_Score++;
            //Ui updates go here
            UImanager.Instance.updatePlayerScore(index, P1_Score);
        }
        if (index == 2)
        {
            P2_Score++;
            //UI Updates go here
            UImanager.Instance.updatePlayerScore(index, P2_Score);
        }
        
        print(P1_Score);
        print(P2_Score);
    }

    public void speedBuff(int i, bool b)
    {
        if(i == 1 && !b)
        {
            b = true;
            playerManager.bootsSpeed(i);
            bootsDuration -= Time.deltaTime;
            if(bootsDuration <= 0)
            {
                b = false;
                playerManager.resetSpeed(i);
            }
           
        }
        if(i == 2 && !b)
        {
            b = true;
            playerManager.bootsSpeed(i);
            bootsDuration -= Time.deltaTime;
            if (bootsDuration <= 0)
            {
                b = false;
                playerManager.resetSpeed(i);
            }
        }
    }
  
    public IEnumerator enableSpeedP1()
    {
        if(!P1_Buffed)
        playerManager.bootsSpeed(1);
        P1_Buffed = true;
        //ui goes here
        print("speed BOOST");
        yield return new WaitForSeconds(5f);
        print("back to default");
        P1_Buffed = false;
        playerManager.resetSpeed(1);
        //ui goes here
    }
    public IEnumerator enableSpeedP2()
    {
        if(!P2_Buffed)
        playerManager.bootsSpeed(2);
        P2_Buffed = true;
        //ui goes here
        yield return new WaitForSeconds(5f);
        print("back to default");
        P2_Buffed = false;
        playerManager.resetSpeed(2);
        //ui goes here
    }
    public void enableSpeed(int index)
    {
        if (index == 1)
            StartCoroutine(enableSpeedP1());
        else if (index == 2)
            StartCoroutine(enableSpeedP2());
    }
}
