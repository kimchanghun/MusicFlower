using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] sound = new AudioClip[8];

    Color[] barColor = new Color[7];

    bool colorCheck;

    void Start()
    {
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        barColor[0] = new Color(0.9960784f, 0.1803922f, 0.1803922f, 1);
        barColor[1] = new Color(1, 1, 0, 1);
        barColor[2] = new Color(0.1803922f, 0.6039216f, 0.9960784f, 1);
        barColor[3] = new Color(0.509804f, 0.9803922f, 0.345098f, 1);
        barColor[4] = new Color(0.9803922f, 0.8f, 0.1803922f, 1);
        barColor[5] = new Color(0.8f, 0.1803922f, 0.9803922f, 1);
        barColor[6] = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        
    }

    public void SoundPlayWork(Color a, int ok)
    {
        if(ok == 0)
        {
            if (a == barColor[0])
            {
                audio.PlayOneShot(sound[0]);
            }
            else if (a == barColor[1])
            {
                audio.PlayOneShot(sound[1]);
            }
            else if (a == barColor[2])
            {
                audio.PlayOneShot(sound[2]);
            }
            else if (a == barColor[3])
            {
                audio.PlayOneShot(sound[3]);
            }
            else if (a == barColor[4])
            {
                audio.PlayOneShot(sound[4]);
            }
            else if (a == barColor[5])
            {
                audio.PlayOneShot(sound[5]);
            }
            else if (a == barColor[6])
            {
                audio.PlayOneShot(sound[6]);
            }
        }
        else
        {
            audio.PlayOneShot(sound[7]);
        }
    }
}
