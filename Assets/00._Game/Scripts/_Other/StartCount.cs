using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    AudioSource audio;
    public AudioClip countEffectSound;

    Text countText;

    IEnumerator Start()
    {
        GameObject noteManagerObject = GameObject.Find("NoteManager");
        noteManagerObject.SetActive(false);

        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        countText = GameObject.Find("Text").GetComponent<Text>();

        audio.PlayOneShot(countEffectSound);
        countText.text = "3";

        yield return new WaitForSeconds(0.9f);
        countText.text = "2";

        yield return new WaitForSeconds(1f);
        countText.text = "1";

        yield return new WaitForSeconds(1f);
        countText.text = "Go";

        yield return new WaitForSeconds(1f);
        noteManagerObject.SetActive(true);
        Destroy(countText);

        GetComponent<InputScript>().CheckValue();
    }

    void Update()
    {
        
    }
}
