using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    Renderer renderer;



    void Start()
    {
       // Renderer.Material.color = Color.black;


        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }
    void OnMouseEnter()
    {
        // Renderer.Material.color = Color.red;

        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        //  Renderer.Material.color = Color.black;

        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
