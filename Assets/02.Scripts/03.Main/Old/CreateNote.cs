using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    public GameObject[] noteSet = new GameObject[8];

    public int noteTypeNum;
    public int noteCountNum;

    public float createTime;
    float createTimeCounte;

    bool createWork = true;

    void Start()
    {
        print("스크립트 적용되었는지 확인용 코드");
        createTimeCounte = createTime;
        CreateNoteSet(noteCountNum, noteTypeNum);
    }

    void Update()
    {
        createTimeCounte -= Time.deltaTime;

        if (createWork)
        {
            if(createTimeCounte <= 0)
            {
                noteCountNum = noteCountNum + 1;
                noteTypeNum = noteTypeNum + 1;

                CreateNoteSet(noteCountNum, noteTypeNum);

                createTimeCounte = createTime;
            }
            
            if (noteCountNum == 8)
            {
                createWork = false;
            }
            
        }
    }

    public void CreateNoteSet(int count, int type)
    {
        GameObject aaa = Instantiate(noteSet[type], this.transform);
        aaa.name = count + "_Note_" + type;
    }
}
