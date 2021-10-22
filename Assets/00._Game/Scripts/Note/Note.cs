using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MF.Game
{
    public class Note : MonoBehaviour
    {
        NoteTypes noteType = NoteTypes.None;
        //��Ʈ Ÿ��
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

        public float DurationToDestination { get; private set; } = 2f;  //���������� ���� �ð�
        public float Age { get; private set; } = 0f;

        [SerializeField]
        GameObject Bar_1;

        [SerializeField]
        GameObject Bar_2;

        // Start is called before the first frame update
        void Start()
        {
            //'��'���� ��ġ��Ŵ
            Bar_1.transform.position = Points.Instance.SpawnPosition_1;
            Bar_2.transform.position = Points.Instance.SpawnPosition_2;

            //'��'���� �̵���Ŵ
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
            //���̴� ��� �԰� �ִ�..
            Age += Time.deltaTime;  //1f 1��
        }

        //���� -> SoundPlay ��ũ��Ʈ ����
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
