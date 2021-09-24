using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteMove : MonoBehaviour
{
    [SerializeField]
    Transform dest;

    [SerializeField]
    float time;

    Tween moveTween = null;

    int noteNum;
    
    public GameObject note_R;
    public GameObject note_L;

    void Start()
    {
        //dest.transform.pos = new Vector3(0, -95, 0);
        noteNum = transform.childCount;

        if (noteNum == 2)
        {
            note_R.transform.DOMove(dest.position, time).SetEase(Ease.Linear).OnComplete(() => { EndWork(); });
            note_L.transform.DOMove(dest.position, time).SetEase(Ease.Linear).OnComplete(() => { EndWork(); });
        }
  
        //moveTween = transform.DOMove(dest.position, time).SetEase(Ease.Linear).OnComplete(EndWork());

        //transform.DOScale(2f, time);
        //transform.DOShakeRotation(time);
    }

    void EndWork()
    {
        if(moveTween.IsPlaying())
        {
            moveTween.Kill();
        }

        Destroy(note_L);
    }
}
