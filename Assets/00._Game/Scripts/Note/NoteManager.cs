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

        private void Start()
        {
            //Excel�����͸� ������
            selectedEntity = GameManager.Instance.Data.SelectRandomOne();

            StartCoroutine(NoteSequence());
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
                
                CreateNote(noteType);

                yield return new WaitForSeconds(selectedEntity.term);
            }            
        }

        //��Ʈ����
        void CreateNote(NoteTypes noteType)
        {
            GameObject g = Instantiate(notePrefab);

            Note note = g.GetComponent<Note>();
            note.NoteType = noteType;

            note.SetDifficult(selectedEntity.difficult);
        }
    } 
}
