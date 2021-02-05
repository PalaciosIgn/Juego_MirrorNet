using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 10;
    private TextMesh tm = null;
    private Text ui = null;

    public void Start()
    {
       rb = GetComponent<Rigidbody>();
        SetPlayerCaption("x");
        SetTitle("Titulo del juego");
    }
    public void Update()
    {
        //move
        float movH = CrossPlatformInputManager.GetAxis("Horizontal")*velocidad;
        float movV = CrossPlatformInputManager.GetAxis("Vertical")*velocidad;
       rb.AddForce(movH, 0, movV);
    }

    public void SetPlayerCaption(string caption)
    {
        if(tm == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).name == "Caption")
                {
                    tm = this.transform.GetChild(i).GetComponent<TextMesh>();
                }
            }
        }
        if (tm != null)
        {
            tm.text = caption;
        }
        else
        {
            tm.text = "err";
        }
    }
    public void SetTitle(string caption)
    {
        if (ui == null)
        {
            ui = GameObject.Find("txtTitle").GetComponent<Text>();
        }
        if (ui != null)
        {
            ui.text = caption;
        }
    }
}
