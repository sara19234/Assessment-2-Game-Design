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
        if (transform.position.y < -50)
        {
            //Debug.Log("Pain");
            Respawn();
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Thouched");
            Respawn();
            

            ////Transition to the second one when we want to do damage or something but prob with a game manager 
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win");
            //GameManager.Win = True
        }
    }

    private void Respawn()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
