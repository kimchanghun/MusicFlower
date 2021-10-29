using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace MF.Game
{
    /// <summary>
    /// Excel�� �ҷ��ͼ� Note���� �����Ѵ�.
    /// </summary>
    public class NoteManager : Singleton<NoteManager>
    {
        public enum GameResults
        {
            Condition_A,    //�ſ� ����
            Condition_B,    //����
            Fail            //�Ǹ�
        }

        public class SuccessEvent : UnityEvent<bool> { }
        public class GameoverEvent : UnityEvent<GameResults> { }

        GameDataEntity selectedEntity;

        [SerializeField]
        GameObject notePrefab;

        Note currentNote = null;
        Queue<Note> noteQueue = new Queue<Note>();

        int successCount = 0;
        public int SuccessCount => successCount;

        GameResults gameResult = GameResults.Fail;
        public GameResults GameResult => gameResult;

        bool noteSequenceOver = false;
        bool gameOver = false;

        public SuccessEvent successEvent = new SuccessEvent();
        public GameoverEvent gameoverEvent = new GameoverEvent();

        private void Start()
        {
            //Excel�����͸� ������
            selectedEntity = GameManager.Instance.Data.SelectRandomOne();

            StartCoroutine(NoteSequence());

            //��ǲ �̺�Ʈ ����
            InputManager.Instance.inputEvent.AddListener(InputHandler);

            successCount = 0;
            noteSequenceOver = false;
            gameOver = false;
        }

        void InputHandler(NoteTypes noteTypes)
        {
            Debug.Log("Key�Է� : " + noteTypes);

            //�Ҹ�
            AudioClip clip = GameManager.Instance.Properties.GetNoteAudio(noteTypes);
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

            if (currentNote != null)
            {
                if (currentNote.Age >= 1.9f && currentNote.Age <= 2.1f)
                {
                    if (currentNote.NoteType == noteTypes)
                    {
                        Debug.Log($"����!!! Ű�Է� {noteTypes} ��Ʈ {currentNote.NoteType}");
                        successCount++;
                        currentNote.DestroyNote(true);

                        return;
                    }
                    else
                    {
                        Debug.Log($"����!!! Ű�Է� {noteTypes} ��Ʈ {currentNote.NoteType}");
                    }
                }
                else
                {
                    Debug.Log("����!!! �ð� �ȸ���");
                }                

                currentNote.DestroyNote(false);
                
            }
        }

        // ���� �Լ�, �񵿱� �Լ�
        // ���� �Լ� => �Լ��� ȣ��Ǹ�.. �Լ��� ���������� �����־�... 

        // ����Ƽ�� �ƴ� �ٸ� �񵿱��Լ� => ������ �ٸ� ������� ����   CPU -> ���ν�����, ������1, ������2, ... ������ ����ȭ (��Ƽ������ )
        // ����Ƽ�� ���� �����常 ���. 

        // int a = A();  <= �ð��� �����ɸ��� ��! 10GB �������� �ٿ�ޤ�(10��...).. �񵿱��Լ�..
        // A().Complete(() => {...}) => �ݹ� ���
        // StartCoroutine(Co());    //�ڷ�ƾ(����Ƽ���)  => ������ �ȵǰ�, ������ ������ �˼��� ����. ����ó���� �ȵ�
        // async void C(); => ���ϵ� ��, ������ ������ �˼��� ����. ����ó���� �ٵ�!!

        IEnumerator NoteSequence()
        {
            foreach (var item in selectedEntity.Notes)
            {
                NoteTypes noteType = NoteTypeHelper.StringToNoteType(item);
                
                if(noteType != NoteTypes.None)
                {
                    CreateNote(noteType);
                }               

                yield return new WaitForSeconds(selectedEntity.term);
            }

            noteSequenceOver = true;
        }

        //��Ʈ����
        void CreateNote(NoteTypes noteType)
        {
            GameObject g = Instantiate(notePrefab);

            Note note = g.GetComponent<Note>();
            note.NoteType = noteType;

            note.SetDifficult(selectedEntity.difficult);

            noteQueue.Enqueue(note); 
        }

        private void Update()
        {
            if (gameOver)
                return;

            if(currentNote == null)
            {
                if(noteQueue.Count > 0)
                {
                    currentNote = noteQueue.Dequeue();
                }
            }

            //��Ʈ�� �� �������, ��Ʈ ť�� ����ְ�, ���� ��Ʈ�� �׾�����(null).. ��� ��Ʈ�� ��!            
            if (noteSequenceOver && noteQueue.Count == 0 && currentNote == null)    
            {
                gameOver = true;
                GameOver();
            }
        }

        void GameOver()
        {
            Debug.Log($"���� ��!!! ��Ʈ ���� ���� : {successCount}");

            GameResults result = GameResults.Fail;
            if(successCount >= selectedEntity.condition_1)
            {
                result = GameResults.Condition_A;
            }
            else if(successCount >= selectedEntity.condition_2)
            {
                result = GameResults.Condition_B;
            }

            gameoverEvent.Invoke(result);
        }

        public void DeathNote(Note note, bool success)
        {
            successEvent.Invoke(success);
            currentNote = null;
        }
    } 
}
