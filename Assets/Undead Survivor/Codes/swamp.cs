using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class swamp : MonoBehaviour
{
    public float player_speed;
    private float timer;
    private bool tim;


    private void Start()
    {
        player_speed = GameManager.instance.player.speed;
        tim = false;
        timer = 0;
    }
    private void Update()
    {
        if (tim == true)
        {
            timer += Time.deltaTime;
            if (timer > 1) 
            {
                tim = false;
                GameManager.instance.player.speed = player_speed;
                timer = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D o)
    {
        if (o.gameObject.name == "Player")
        {
            GameManager.instance.player.speed = player_speed-1;
            if (tim == false){
                tim = true;
            }
            else
            {
                timer = 0;
            }
        }
    }
}
