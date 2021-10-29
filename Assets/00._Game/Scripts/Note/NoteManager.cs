using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace MF.Game
{
    /// <summary>
    /// Excel을 불러와서 Note생성 관리한다.
    /// </summary>
    public class NoteManager : Singleton<NoteManager>
    {
        GameDataEntity selectedEntity;

        [SerializeField]
        GameObject notePrefab;

        Note currentNote = null;
        Queue<Note> noteQueue = new Queue<Note>();

        private void Start()
        {
            //Excel데이터를 가져옴
            selectedEntity = GameManager.Instance.Data.SelectRandomOne();

            StartCoroutine(NoteSequence());

            //인풋 이벤트 구독
            InputManager.Instance.inputEvent.AddListener(InputHandler);
        }

        void InputHandler(NoteTypes noteTypes)
        {
            Debug.Log("Key입력 : " + noteTypes);

            if(currentNote != null)
            {
                if (currentNote.Age >= 1.9f && currentNote.Age <= 2.1f)
                {
                    if (currentNote.NoteType == noteTypes)
                    {
                        Debug.Log($"성공!!! 키입력 {noteTypes} 노트 {currentNote.NoteType}");
                    }
                    else
                    {
                        Debug.Log($"실패!!! 키입력 {noteTypes} 노트 {currentNote.NoteType}");
                    }
                }
                else
                {
                    Debug.Log($"실패!!! 시간 안맞음");
                }

                currentNote.DestroyNote();
            }

        }

        // 동기 함수, 비동기 함수
        // 동기 함수 => 함수가 호출되면.. 함수가 끝날때까지 멈춰있어... 

        // 유니티가 아닌 다른 비동기함수 => 보통은 다른 스레드로 돌려   CPU -> 메인스레드, 스레드1, 스레드2, ... 스레드 동기화 (멀티스레드 )
        // 유니티는 메인 스레드만 사용. 

        // int a = A();  <= 시간이 오래걸리는 애! 10GB 동영상을 다운받ㅇ(10분...).. 비동기함수..
        // A().Complete(() => {...}) => 콜백 방식
        // StartCoroutine(Co());    //코루틴(유니티방식)  => 리턴이 안되고, 끝나는 시점을 알수도 없음. 예외처리도 안됨
        // async void C(); => 리턴도 되, 끝나는 시점을 알수도 있음. 예외처리도 다됨!!

        IEnumerator NoteSequence()
        {
            foreach (var item in selectedEntity.Notes)
            {
                NoteTypes noteType = NoteTypeHelper.StringToNoteType(item);
                
                if(noteType != NoteTypes.None)
                {
                    Debug.Log($"CreateNote {noteType}");
                    CreateNote(noteType);
                }               

                yield return new WaitForSeconds(selectedEntity.term);
            }            
        }

        private void Update()
        {
            if (currentNote == null && noteQueue.Count > 0)
            {
                currentNote = noteQueue.Dequeue();
            }
        }

        //노트생성
        void CreateNote(NoteTypes noteType)
        {
            GameObject g = Instantiate(notePrefab);

            Note note = g.GetComponent<Note>();
            note.NoteType = noteType;

            note.SetDifficult(selectedEntity.difficult);

            noteQueue.Enqueue(note); 
        }

        public void DeathNote(Note note)
        {
            currentNote = null;
        }
    } 
}
