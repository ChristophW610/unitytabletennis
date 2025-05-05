using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void startMenu() {
        SceneManager.LoadScene("menu");
    }

    public void startResult() {
        SceneManager.LoadScene("result");
    }

    public void quit() {

        Application.Quit();
    
    }
}
