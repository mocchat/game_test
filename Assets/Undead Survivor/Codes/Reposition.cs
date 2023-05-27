using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        switch (transform.tag)
        {
            case "Ground":
                float diffx = playerPos.x - myPos.x;
                float diffy = playerPos.y - myPos.y;
                float dirX = diffx < 0 ? -1 : 1;
                float dirY = diffy < 0 ? -1 : 1;
                diffx = Mathf.Abs(diffx);
                diffy = Mathf.Abs(diffy);


                if (diffx > diffy)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffx < diffy)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                    transform.Translate(ran + dist * 2);
                }
                break;

            case "swamp":
                float diffxx = playerPos.x - myPos.x;
                float diffyy = playerPos.y - myPos.y;
                float dirXx = diffxx < 0 ? -1 : 1;
                float dirYy = diffyy < 0 ? -1 : 1;
                diffxx = Mathf.Abs(diffxx);
                diffyy = Mathf.Abs(diffyy);


                if (diffxx > diffyy)
                {
                    transform.Translate(Vector3.right * dirXx * 40);
                }
                else if (diffxx < diffyy)
                {
                    transform.Translate(Vector3.up * dirYy * 40);
                }
                break;
        }
    }
}
