using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCell : MonoBehaviour
{
    public Image aaa;
    Image testImage_L;
    Image testImage_R;

    public int a;

    float xPos;
    float yPos;

    Image asdf;

    void Start()
    {
        print("스크립트 적용되었는지 확인용 코드");
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;

        for (int i = 0; i < a; i++)
        {
            testImage_L = Instantiate(aaa, this.transform);
            testImage_R = Instantiate(aaa, this.transform);



            aaa.name = "Left_" + i;

            testImage_L.name = "L_" + i;
            testImage_R.name = "R_" + i;

            testImage_L.transform.position = new Vector2(xPos - ((i + 1) * 120), yPos);
            testImage_R.transform.position = new Vector2(xPos + ((i + 1) * 120), yPos);
        }
    }

    void Update()
    {
        
    }
}
