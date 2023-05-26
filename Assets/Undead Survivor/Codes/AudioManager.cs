using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;//� bgm����
    public float bgmVolum;//volum
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;

    [Header("#SFX")]
    public AudioClip[] sfxClips;//� bgm����
    public float sfxVolum;//volum
    public int channels;//�ٷ��� ȿ������ �� �� �ֵ��� ä�� ���� ���� ����
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx {Dead,Hit,LevelUp=3,Lose,Melee,Range=7,Select,Win}

    void Awake()
    {
        instance = this;
        Init();
    }
    
    void Init()
    {
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform; //������� ����ϴ� �ڽ� ������Ʈ ����
        bgmPlayer = bgmObject.AddComponent<AudioSource>();//AddComponent �Լ��� ������ҽ��� �����ϰ� ������ ����
        bgmPlayer.playOnAwake = false;//�⺻�� true
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolum;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform; //������� ����ϴ� �ڽ� ������Ʈ ����
        sfxPlayers = new AudioSource[channels];

        for(int index = 0;index<sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolum;
        }
    }

    public void PlayBgm(bool isPlay)
    {
        if(isPlay)
        {
            bgmPlayer.Play();
        }
        else 
        {
            bgmPlayer.Stop();
        }
    }
    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }


    //ȿ���� ��� �Լ�
    public void PlaySfx(Sfx sfx)
    {
        for(int index=0; index<sfxPlayers.Length;index++) 
        {
            //ä�� ������ŭ ��ȸ�ϵ��� ä���ε��� ���� Ȱ��
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            int ranIndex = 0;//���� ���
            if(sfx == Sfx.Hit || sfx ==Sfx.Melee)
            {
                ranIndex = Random.Range(0, 2);//ȿ������ 2�� �̻��� ���� ���� �ε����� ���ϱ�
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + ranIndex];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
