using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MF.Game
{
    public class Note : MonoBehaviour
    {
        NoteTypes noteType = NoteTypes.None;
        //노트 타입
        public NoteTypes NoteType {
            get => noteType;
            set
            {
                noteType = value;

                Bar_1.GetComponent<SpriteRenderer>().color
                    = GameManager.Instance.Properties.GetNoteColor(noteType);

                Bar_2.GetComponent<SpriteRenderer>().color
                    = GameManager.Instance.Properties.GetNoteColor(noteType);
            }                
        }

        public float DurationToDestination { get; private set; } = 2f;  //목적지까지 도달 시간
        public float Age { get; private set; } = 0f;

        [SerializeField]
        GameObject Bar_1;

        [SerializeField]
        GameObject Bar_2;
        
        Sequence bar1anim;
        Sequence bar2anim;

        // Start is called before the first frame update
        void Start()
        {
            //'바'들을 위치시킴
            Bar_1.transform.position = Points.Instance.SpawnPosition_1;
            Bar_2.transform.position = Points.Instance.SpawnPosition_2;

            //'바'들을 이동시킴
            bar1anim = DOTween.Sequence();
            Tween bar1Tween = Bar_1.transform
                .DOMove(Points.Instance.DestinationPosition, DurationToDestination)
                .SetEase(Ease.Linear);

            bar1anim.Append(bar1Tween);

            bar2anim = DOTween.Sequence();
            Tween bar2Tween = Bar_2.transform
                .DOMove(Points.Instance.DestinationPosition, DurationToDestination)
                .SetEase(Ease.Linear);

            bar2anim.Append(bar2Tween);
            bar2anim.Append(DOVirtual.DelayedCall(0.2f, DestroyNote));            
        }

        public void SetDifficult(float difficult)
        {
            if(difficult >= 0f)
            {
                DurationToDestination = DurationToDestination / difficult;
            }            
        }

        // Update is called once per frame
        void Update()
        {
            //나이는 계속 먹고 있는..
            Age += Time.deltaTime;  //1f 1초
        }

        public void DestroyNote()
        {
            NoteManager.Instance.DeathNote(this);

            bar1anim.Kill();
            bar2anim.Kill();

            //노트가 사라지는 애니메이션 연출
            Bar_1.transform.DOScale(1.5f, 0.2f);
            Bar_2.transform.DOScale(1.5f, 0.2f);

            Bar_1.GetComponent<SpriteRenderer>().DOFade(0f, 0.2f);
            Bar_2.GetComponent<SpriteRenderer>().DOFade(0f, 0.2f)
                .OnComplete(() =>
                {
                    if (gameObject != null)
                    {
                        Destroy(gameObject);                        
                    }
                });
        }
    } 
}
