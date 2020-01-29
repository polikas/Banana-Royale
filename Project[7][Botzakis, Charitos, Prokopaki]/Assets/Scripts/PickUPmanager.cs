using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPmanager : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] pickUps;
    public bool spawned, spawnedPickup;
    private int spawnIndex, spawnIndex_1, spawnIndex_2;
    private bool arenaFull;
    private void Awake()
    {
        initialiseSpawns();
    }
    void Start()
    {
        spawnedPickup = false;
        spawned = false;
        arenaFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!arenaFull)
        {
            if (!spawned)
            {
                StartCoroutine(spawnHandler());
                spawned = true;
            }
            if (!spawnedPickup)
            {
                StartCoroutine(powerUpHandler());
                spawnedPickup = true;
            }
        }
        else
        {
            
        }
        
    }
    private void initialiseSpawns()
    {
        for(int i = 0; i < spawnPos.Length;i++)
        {
            spawnPos[i].tag = "empty";
           
        }
    }
    IEnumerator spawnHandler()
    {
        checkArena();
        if (arenaFull)
            StopCoroutine(spawnHandler());
       // do
      //  {
            if (arenaFull)
            {
                spawned = true;
               // break;
            }
            spawnIndex = Random.Range(0, 8);
        // } while (spawnPos[spawnIndex].tag == "spawned");
        // int pickUpIndex = Random.Range(0, 1);
        if (spawnPos[spawnIndex].tag == "empty")
        {

            GameObject tempBanana = Instantiate(pickUps[0], spawnPos[spawnIndex].position, spawnPos[spawnIndex].rotation);

            tempBanana.GetComponent<BananaControl>().setSpawnPointIndex(spawnIndex); //set spawn index in the banana script

            spawnPos[spawnIndex].tag = "spawned";
            print("PICKUP");
        }
        yield return new WaitForSeconds(2.5f);
        spawned = false;
    }
    IEnumerator powerUpHandler()
    {
        checkArena();
        if (arenaFull)
            StopCoroutine(powerUpHandler());
      //  do
      //  {
            if (arenaFull)
            {
                spawnedPickup = true;
              //  break;
            }
            spawnIndex_1 = Random.Range(0,8);
        //spawnIndex_2 = Random.Range(4, 8);          
        //  } while (spawnPos[spawnIndex_1].tag == "spawned"); //&& spawnPos[spawnIndex_2].tag == "spawned");
   
        //spawnPos[spawnIndex_2].tag = "spawned";
        if (spawnPos[spawnIndex_1].tag == "empty")
        {
            GameObject tempPowerUp = Instantiate(pickUps[1], spawnPos[spawnIndex_1].position, spawnPos[spawnIndex_1].rotation); //pickup 1 spawn

            tempPowerUp.GetComponent<powerUpControll>().setSpawnPointIndex(spawnIndex_1);

            // tempPowerUp = Instantiate(pickUps[1], spawnPos[spawnIndex_2].position, spawnPos[spawnIndex_2].rotation); //pickup 2 spawn

            //  tempPowerUp.GetComponent<powerUpControll>().setSpawnPointIndex(spawnIndex_2);
            spawnPos[spawnIndex_1].tag = "spawned";
            print("ai sixtiri");
        }

        yield return new WaitForSeconds(10f);
        spawnedPickup = false;
    }
    public void resetSpawnPointStatus(int i)
    {
        spawnPos[i].tag = "empty";
    }
    private void checkArena()
    {
        int counter = 0;
        for(int i = 0; i < spawnPos.Length; i++)
        {
            if(spawnPos[i].tag == "spawned")
            {
                counter++;
            }
        }
        if(counter == spawnPos.Length)
        {
            arenaFull = true;
            print(arenaFull);
        }
    }
}
