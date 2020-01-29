using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaControl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameControl gameManager;
    private PickUPmanager pickUpManager;
    private int spawnPointIndex;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        pickUpManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PickUPmanager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            gameManager.setPlayerScore(1);
        }
        else if(other.tag == "Player2")
        {
            gameManager.setPlayerScore(2);
        }
        
        pickUpManager.resetSpawnPointStatus(spawnPointIndex);
        Destroy(this.gameObject);
    }
    public  void setSpawnPointIndex(int i)
    {
        spawnPointIndex = i;
    }
}
