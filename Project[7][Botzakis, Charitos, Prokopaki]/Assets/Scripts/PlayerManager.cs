using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody rb1;
    public Rigidbody rb2;
    private float speed1 , speed2;
    public GameObject player1, player2;
    public Animator animator;
    public Animator animator2;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float horizontalMove2 = 0f;
    float verticalMove2 = 0f;
    public GameObject projectile;
    int playerIndex = 0;

    private void Awake()
    {

    }

    private void Start()
    {
        speed1 = 3.0f;
        speed2 = 3.0f;
    }

    void Update()
    {
        //fireBoomerang(playerIndex);
    }
    public void playerMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        animator.SetFloat("HorizontalSpeedPlayer1", Mathf.Abs(horizontalMove));
        animator.SetFloat("VerticalSpeedPlayer1", Mathf.Abs(verticalMove));

        //Player 1
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            movement.Normalize();
            rb1.velocity = movement * speed1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb1.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            movement.Normalize();
            rb1.velocity = movement * speed1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb1.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
            movement.Normalize();
            rb1.velocity = movement * speed1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb1.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
            movement.Normalize();
            rb1.velocity = movement * speed1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb1.velocity = Vector3.zero;
        }

        //Player2
        horizontalMove2 = Input.GetAxis("P2_Horizontal");
        verticalMove2 = Input.GetAxis("P2_Vertical");

        animator2.SetFloat("HorizontalSpeedPlayer2", Mathf.Abs(horizontalMove2));
        animator2.SetFloat("VerticalSpeedPlayer2", Mathf.Abs(verticalMove2));

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 movement = new Vector3(horizontalMove2, 0.0f, verticalMove2);
            animator2.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            movement.Normalize();
            rb2.velocity = movement * speed2;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb2.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 movement = new Vector3(horizontalMove2, 0.0f, verticalMove2);
            animator2.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            movement.Normalize();
            rb2.velocity = movement * speed2;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb2.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 movement = new Vector3(horizontalMove2, 0.0f, verticalMove2);
            movement.Normalize();
            rb2.velocity = movement * speed2;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb2.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 movement = new Vector3(horizontalMove2, 0.0f, verticalMove2);
            movement.Normalize();
            rb2.velocity = movement * speed2;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb2.velocity = Vector3.zero;
        }
    }
    /*
    public void fireBoomerang(int i)
    {
        if (i == 1 && Input.GetKeyDown(KeyCode.Space))
        {
           if(animator.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                GameObject boomerang = Instantiate(projectile, player1.transform.position, Quaternion.identity);
                boomerang.GetComponent<Rigidbody>().AddForce(-transform.right * 3.0f, ForceMode.Impulse);
            }
           else
            {
                GameObject boomerang = Instantiate(projectile, player1.transform.position, Quaternion.identity);
                boomerang.GetComponent<Rigidbody>().AddForce(transform.right * 3.0f, ForceMode.Impulse);
            }
        }
        if (i == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            if (animator.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                GameObject boomerang = Instantiate(projectile, player1.transform.position, Quaternion.identity);
                boomerang.GetComponent<Rigidbody>().AddForce(-transform.right * 3.0f, ForceMode.Impulse);
            }
            else
            {
                GameObject boomerang = Instantiate(projectile, player1.transform.position, Quaternion.identity);
                boomerang.GetComponent<Rigidbody>().AddForce(transform.right * 3.0f, ForceMode.Impulse);
            }
        }
    }
    */
    public void bootsSpeed(int i)
    {
        if(i == 1)
        {
            speed1 += 3.0f;
        }
        else if(i == 2)
        {
            speed2 += 3.0f;
        }
    }

    public void resetSpeed(int i)
    {
        if(i == 1)
        {
            speed1 = 3.0f;
        }
        if (i == 2)
        {
            speed2 = 3.0f;
        }

    }


    /*
    #region playersMovement
    public void playerMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;

        //Player 1
        if (Input.GetKey(KeyCode.A))
        {
            
            // player1.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            player1.transform.position = new Vector3(player1.transform.position.x - speed * Time.deltaTime,
            player1.transform.position.y,
            player1.transform.position.z);
            //StartCoroutine(renderMonkey1());
        }
       

        if (Input.GetKey(KeyCode.S))
        {
         
            player1.transform.position = new Vector3(player1.transform.position.x,
            player1.transform.position.y,
            player1.transform.position.z - speed * Time.deltaTime);
            //StartCoroutine(renderMonkey1());
        }
      

        if (Input.GetKey(KeyCode.W))
        {
         
            player1.transform.position = new Vector3(player1.transform.position.x,
               player1.transform.position.y,
               player1.transform.position.z + speed * Time.deltaTime);
  
           // StartCoroutine(renderMonkey1());
        }
      

        if (Input.GetKey(KeyCode.D))
        {
           
            player1.transform.position = new Vector3(player1.transform.position.x + speed * Time.deltaTime,
              player1.transform.position.y,
              player1.transform.position.z);
            //StartCoroutine(renderMonkey1());
        }
       
        //Player 2

        if (Input.GetKey(KeyCode.LeftArrow))
            player2.transform.position = new Vector3(player2.transform.position.x - speed * Time.deltaTime, 
                player2.transform.position.y,
                player2.transform.position.z);

        if (Input.GetKey(KeyCode.DownArrow))
            player2.transform.position = new Vector3(player2.transform.position.x, 
                player2.transform.position.y, 
                player2.transform.position.z - speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            player2.transform.position = new Vector3(player2.transform.position.x, 
                player2.transform.position.y,
                player2.transform.position.z + speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            player2.transform.position = new Vector3(player2.transform.position.x + speed * Time.deltaTime,
                player2.transform.position.y, 
                player2.transform.position.z);
    }
    #endregion
    */

}
