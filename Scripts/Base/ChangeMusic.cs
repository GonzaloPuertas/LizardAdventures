using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioSource musicToStop;
    public AudioSource musicToStop2;
    public AudioSource musicToPlay;
    public bool onTriggerMusic;
    public bool flag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTriggerMusic == true && flag == false)
        {
            ChangePlay();
            flag = true;
        }
    }

    public void ChangePlay()
    {
        if (musicToStop != null && musicToPlay != null)
        {
            musicToStop.Stop();
            musicToPlay.Play();
        }
        else if(musicToStop != null && musicToPlay != null)
        {
            musicToStop.Stop();
            musicToStop2.Stop();
            musicToPlay.Play();
        }
        
    }
}
