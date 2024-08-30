using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When loading and unloading scenes
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    public void MainScene()
    {
        // Load the next scene after current scene
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Game start!");
    }

    public void TestScene()
    {
        SceneManager.LoadScene("Base Scene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Load The next scene after the next scene after current scene
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void Quit()
    {
        // Closes the game
        Application.Quit();
    }

    /*void OnMouseUp()
    { 
        if(isStart)
        {
            // Click the start button to load the first level
            Application.LoadLevel(1);
        }
        if (isQuit)
        {
            // Click to exit the game
            Application.Quit(); 
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
