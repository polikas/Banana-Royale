using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    protected static UImanager instance;
    public GameObject pausePanel,gameOverPanel;
    public Text timeHolder, P1_Score_Text, P2_Score_Text, gameOverText;
    

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }


    public void setTimer(float i)
    {
        timeHolder.text = "Time Left: " + i.ToString("F0");
    }

    public static UImanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UImanager)FindObjectOfType(typeof(UImanager));
                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(UImanager) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
    public void updatePlayerScore(int playerIndex, int score)
    {
        if(playerIndex == 1)
        {
            P1_Score_Text.text = score.ToString();
        }
        else if (playerIndex == 2)
        {
            P2_Score_Text.text = score.ToString();
        }
    }
    public void setPausePanel(bool b)
    {
        if (b)
            pausePanel.SetActive(b);
        else
            pausePanel.SetActive(b);
    }
    public void setGameOverPanel(int P1, int P2)
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        timeHolder.gameObject.SetActive(false);
        if(P1 > P2)
        {
            gameOverText.color = Color.green;
            gameOverText.text = "Player 1 WINS!";
        }
        else if ( P1 == P2)
        {
            gameOverText.color = Color.cyan;
            gameOverText.text = "IT'S A DRAW!!! Stand down!";
        }
        else if (P1 < P2)
        {
            gameOverText.color = Color.red;
            gameOverText.text = "Player 2 WINS!";
        }
    }
}
