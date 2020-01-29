using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    
    public bool isStunned = false;
    private PlayerManager pManager;
    private GameControl gameCtrl;
    // Start is called before the first frame update
    private void Awake()
    {
        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        pManager = gameCtrl.gameObject.GetComponent<PlayerManager>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
      

      //  if(isStunned)
       // {
        //    StartCoroutine(waitForStun());
      //  }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player2")
        {
            Debug.Log("hit");
            isStunned = true;
        }
    }

    IEnumerator waitForStun()
    {
        pManager.rb2.isKinematic = true;
        gameCtrl.sp1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameCtrl.sp1.gameObject.SetActive(false);
        gameCtrl.sp2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        gameCtrl.sp2.gameObject.SetActive(false);
        isStunned = false;
        pManager.rb2.isKinematic = false;
        
    }
}
