using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxControl : MonoBehaviour
{
    private Vector3 dwn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("awake");
  
    }

    // Update is called once per frame
    void Update()
    {
        //  des = this.transform.position;
        // // dirChecker.transform.forward = dirVect;
        //  dirChecker.transform.position = des - dirVect;
        
        Vector3 down = this.transform.TransformDirection(-Vector3.right) * 1f;
        Debug.DrawRay(this.transform.position, down, Color.green);

        dwn = this.transform.TransformDirection(-Vector3.right); //this creates error, because of the sphere's nature, 
                                                                 //the object gets rotated constantly ! ! !

        if (Physics.Raycast(this.transform.position, dwn, 1f))
        {
            print("kaaati");
        }
    }
}
