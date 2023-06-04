using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    private bool rotate;
    private float timer;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rotate = false;
        timer = 0;

    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per >= 0)
        {
            rigid.velocity = dir * 15f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -100 || per >= 100)
        {
            if (collision.CompareTag("Enemy") && per >= 100)
            {
                rigid.velocity = new Vector2(0, 0);
                rotate = true;
            }
            return;
        }


        per--;

        if (per < 0)
        {
            rigid.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area") || per == -100 || per >= 100)
        {
            return;
        }

        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (rotate == true)
        {
            Rotate();
            timer += Time.deltaTime;
            if (timer > per / 50)
            {
                timer = 0;   
                gameObject.SetActive(false);
            }
        }
    }

    void Rotate()
    {
        rigid.rotation += 30;
    }
}
