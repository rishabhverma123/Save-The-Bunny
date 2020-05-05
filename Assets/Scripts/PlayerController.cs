using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rd;
    float xInput;
    public float moveSpeed; 
    Vector2 newPosition;    //variable of type vector2 can store two value x & y.
    public float xPostionLimit=2.5f;    //variable to limit movement of rabbit within game screen



    /*
     * Awake() function is called before start() in lifecycle
     * initialization of variable or taking referrence is better done in Awake()
     * */
   
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Normal update activity is done under update() function
     * FixedUpdate() is better to update any Physics property.
     * Since movement of player is physics hence done in Ficxedupdate() here.
     * */
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
         
         xInput = CrossPlatformInputManager.GetAxis("Horizontal");  //this give value between -1 and +1 depending upon location of rabbit 
                                               //take input from keyboard and tell left or right key is pressed
         newPosition = transform.position;   //gives current position
           
         newPosition.x = newPosition.x + xInput * moveSpeed; //changes position depending upon input and control its speed

        //Mathf.clamp() limit movement of newpostion.x variable(rabbit movement) b/w -xPostionLimit and +xPostionLimit
        newPosition.x = Mathf.Clamp(newPosition.x, -xPostionLimit, xPostionLimit);
         rd.MovePosition(newPosition);


    }

}
