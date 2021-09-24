using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWork : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] buttonSound = new AudioClip[8]; // 8개

    int num;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(buttonSound[7], 1.0f); // 0 ~ 7 번 <- 8개
    }

    public void BWork(int a)
    {
        if (a == 0)
        {
            Destroy(gameObject);
        }
        else if(a == 1)
        {
            if (transform.position.x > 0 || transform.position.x < 30)
            {
                audio.PlayOneShot(buttonSound[a - 1], 1.0f);

                num += 1;
                GameObject aaa = GameObject.Find("NoteBarSet_1_" + num);

                Destroy(aaa);
            }

            print("성공");
        }

        Destroy(GameObject.Find("NoteBarSet_1_1"));
    }
}
