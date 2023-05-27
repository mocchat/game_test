using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class swamp : MonoBehaviour
{
    public float player_speed;
    public float true_speed;
    // private BoxCollider2D coll;


    void Awake()
    {
        // coll = GetComponent<BoxCollider2D>();
    }

    /*
    private void Update()
    {
        float x_p = transform.position.x;
        float y_p = transform.position.y;
        float x_s = coll.size.x;
        float y_s = coll.size.y;
        float player_x = GameManager.instance.player.transform.position.x;
        float player_y = GameManager.instance.player.transform.position.y;

        if (x_p-0.5 <= player_x && player_x <= x_p+x_s-0.5 && y_p+0.5 >= player_y && y_p - y_s+0.5 <= player_y)
        {
            GameManager.instance.player.speed = player_speed - 1;
        }
        else
        {
            GameManager.instance.player.speed = player_speed;
        }
        
    }
    
    */

    private void Update()
    {        
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
            true_speed = player_speed - 1;
            GameManager.instance.player.speed = true_speed;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            true_speed = player_speed;
            GameManager.instance.player.speed = player_speed;
        }
    }

}
