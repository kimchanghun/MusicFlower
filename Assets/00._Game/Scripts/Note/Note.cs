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

        // Start is called before the first frame update
        void Start()
        {
            //'바'들을 위치시킴
            Bar_1.transform.position = Points.Instance.SpawnPosition_1;
            Bar_2.transform.position = Points.Instance.SpawnPosition_2;

            //'바'들을 이동시킴
            Bar_1.transform
                .DOMove(Points.Instance.DestinationPosition, DurationToDestination)
                .SetEase(Ease.Linear)
                .OnComplete(() => DestroyNote(0));

            Bar_2.transform
                .DOMove(Points.Instance.DestinationPosition, DurationToDestination)
                .SetEase(Ease.Linear)
                .OnComplete(() => DestroyNote(1));
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

        //수정 -> SoundPlay 스크립트 생성
        void DestroyNote(int a)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
            
            if(a == 0)
            {
                Color barColor = Bar_1.GetComponent<SpriteRenderer>().color;
                GameObject.Find("GameManager").GetComponent<SoundPlay>()
                    .SoundPlayWork(barColor, 0);
            }
        }
    } 
}
