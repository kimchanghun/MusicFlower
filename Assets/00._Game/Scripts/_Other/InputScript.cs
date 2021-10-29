using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    string z;
    string x;
    string c;

    public string value;

    void Start()
    {
        ReSetValue();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            z = "1";
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            x = "01";
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            c = "01";
        }
    }

    public IEnumerator CheckValue()
    {
        value = x + c + z;
        print(value);

        yield return new WaitForSeconds(0.5f);
        ReSetValue();
    }

    void ReSetValue()
    {
        z = "0";
        x = "0";
        c = "0";
    }
}
