using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace MF.Game
{
    /// <summary>
    /// Excel�� �ҷ��ͼ� Note���� �����Ѵ�.
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
            //Excel�����͸� ������
            selectedEntity = GameManager.Instance.Data.SelectRandomOne();

            StartCoroutine(NoteSequence());

            //��ǲ �̺�Ʈ ����
            InputManager.Instance.inputEvent.AddListener(InputHandler);
        }

        void InputHandler(NoteTypes noteTypes)
        {
            Debug.Log("Key�Է� : " + noteTypes);

            if(currentNote != null)
            {
                if (currentNote.Age >= 1.9f && currentNote.Age <= 2.1f)
                {
                    if (currentNote.NoteType == noteTypes)
                    {
                        Debug.Log($"����!!! Ű�Է� {noteTypes} ��Ʈ {currentNote.NoteType}");
                    }
                    else
                    {
                        Debug.Log($"����!!! Ű�Է� {noteTypes} ��Ʈ {currentNote.NoteType}");
                    }
                }
                else
                {
                    Debug.Log($"����!!! �ð� �ȸ���");
                }

                currentNote.DestroyNote();
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

        //��Ʈ����
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
