using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    //���� ������ ����(����, �ҷ�����) -����Ż �켭����ũ14+����
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;
    public GameObject uiNotice;
    enum Achive {UnlockPotato, UnlockBean}
    Achive[] achives;//���� �����͵��� �����ص� �迭 ���� �� �ʱ�ȭ
    WaitForSecondsRealtime wait;

    void Awake()
    {
        //Enum.GetValues �־��� �������� �����͸� ��� �������� �Լ�
        achives = (Achive[])Enum.GetValues(typeof(Achive));
        wait = new WaitForSecondsRealtime(5);
        if (!PlayerPrefs.HasKey("MyData"))
        {
            Init();
        }

    }

    //���� ������ �ʱ�ȭ �Լ� �ۼ�
    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);
        //���������� ������ ����
        foreach(Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
        
    }

    void Start()
    {
        UnlockCharacter();
    }

    //ĳ���� ��ư �ر��� ���� �Լ�
    void UnlockCharacter()
    {
        for(int index = 0; index < lockCharacter.Length; index++)
        {
            string achiveName = achives[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);
        }
    }
    void LateUpdate()
    {
        foreach(Achive achive in achives)
        {
            CheckAchive(achive);
        }
    }

    void CheckAchive(Achive achive)//���� �޼��� ���� �Լ� ���Ӱ� �ۼ�
    {
        bool isAchive = false;

        switch(achive)
        {
            case Achive.UnlockPotato:
                if(GameManager.instance.isLive)
                    isAchive = GameManager.instance.kill >= 10;
                break;
            case Achive.UnlockBean:
                isAchive = GameManager.instance.gameTime == GameManager.instance.maxGameTime;
                break;
        }

        if(isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0) //�ش� ������ ó�� �޼� �ߴٴ� ����, �ر� �ȵǾ�������
        {
            PlayerPrefs.SetInt(achive.ToString(), 1);

            for(int index = 0; index< uiNotice.transform.childCount; index++)
            {
                bool isActive = index == (int)achive; //�˸� â�� �ڽ� ������Ʈ�� ��ȸ�ϸ鼭 ������ ������ Ȱ��ȭ
                uiNotice.transform.GetChild(index).gameObject.SetActive(isActive);
            }

            StartCoroutine(NoticeRoutine());
        }

        IEnumerator NoticeRoutine()//�˸� â�� Ȱ��ȭ�ߴٰ� ���� �ð� ���� ��Ȱ��ȭ�ϴ� �ڷ�ƾ ����
        {
            uiNotice.SetActive(true);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);

            yield return wait;

            uiNotice.SetActive(false);
        }
    }
}
