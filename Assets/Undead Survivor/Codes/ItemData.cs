using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//CreateAssetMenu : Ŀ���� �޴��� ���� �����ϴ� �Ӽ�
[CreateAssetMenu(fileName = "Item", menuName = "Scriptble object/ItemData")]  //Scriptble Object : �پ��� �����͸� �����ϴ� ����(Data������ �ִ� ������Ʈ)
public class ItemData : ScriptableObject
{
    public enum ItemType {  Melee, Range, Glove, Shoe, Heal, Sickle }

    // �������� ���� �Ӽ����� ������ �ۼ��ϱ�
    [Header("# Main Info")]
    public ItemType itemType;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;


    [Header("# Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;


    [Header("# Weapon")]
    public GameObject projectile;
    public Sprite hand;


}


