using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpControll : MonoBehaviour
{
    private GameControl gameManager;
    private PickUPmanager pickUpManager;
    private int spawnPointIndex;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        pickUpManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PickUPmanager>();
    }




    private void OnTriggerEnter(Collider other)
    {
        //int powerUpIndex = Random.Range(0, 1);
        if(other.tag == "Player1")
        {
            //gameManager.speedBuff(1, bootsUp);
            // if(powerUpIndex == 0)
            //StartCoroutine(gameManager.enableSpeedP1());
            gameManager.enableSpeed(1);              
        }
        else if(other.tag == "Player2")
        {
            //gameManager.speedBuff(2, bootsUp);
            //StartCoroutine(gameManager.enableSpeedP2());
            gameManager.enableSpeed(2);
        }
  
        pickUpManager.resetSpawnPointStatus(spawnPointIndex);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    public void setSpawnPointIndex(int i)
    {
        spawnPointIndex = i;
    }
}
