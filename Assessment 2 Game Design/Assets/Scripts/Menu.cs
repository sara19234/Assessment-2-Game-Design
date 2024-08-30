using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Menu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;


    void OnMouseUp()
    { 
        if(isStart)
        {
            Application.LoadLevel(2);
        }
        if (isQuit)
        {
            Application.Quit(); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
