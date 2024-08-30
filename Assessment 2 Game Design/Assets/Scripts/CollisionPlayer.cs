using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{SceneManager.GetActiveScene().name}");
    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Thouched");
            SceneManager.LoadScene(0, LoadSceneMode.Single);

            ////Transition to the second one when we want to do damage or something but prob with a game manager 
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }

    private void Respawn()
    {

    }
}
