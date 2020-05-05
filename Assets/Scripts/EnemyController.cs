using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotationSpeed;
   public  GameObject dust;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
    /*
     * Is Trigger property of Enemy is set on
     * when gameobject to which this script is attached collided OnTriggerEnter2D(Collider2D collision) is called
     * */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);  //destroy gameObject to which enemy has collided
            GameManager.instance.GameOver();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);    //ground se collision k bad enemy dikhega nahi but 2sec tak rahega
            GameManager.instance.IncrementScore();  //score increment karne k liye
            GameObject dustEffect= Instantiate(dust, transform.position, Quaternion.identity);  //dust particle ko instantiate kiya
            Destroy(dustEffect, 2f);
            Destroy(gameObject,3f);            //destroy gameObject (enemy here) after 3sec to which this script is attached
        }
    }
}
