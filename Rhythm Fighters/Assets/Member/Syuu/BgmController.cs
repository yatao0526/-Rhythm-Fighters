using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    [SerializeField]
    private  AudioClip[] bgms=new AudioClip[3];
    AudioSource audioSource;// Musicals インターフェース
    public int gbmNum=1;
    // Update is called once per frame
    void Update()
    {
        gbmNum = this.GetComponent<CharacterSelectPlayersController>().stageNum;
        if (this.GetComponent<AudioSource>().clip != bgms[gbmNum])
        {

            this.GetComponent<AudioSource>().clip = bgms[gbmNum];
            this.GetComponent<AudioSource>().Play();
        }
    }
}
