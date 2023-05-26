using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HP�� �÷��̾� �ϴܿ� ��ġ ���� 
public class Follow : MonoBehaviour
{
    RectTransform rect;


    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        
        //WorldToScreenPoint : ���� ���� ������Ʈ ��ġ�� ��ũ�� ��ǥ�� ��ȯ
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
}
