using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void PlayGame(){
        Cursor.lockState = CursorLockMode.None;
        int active = SceneManager.GetActiveScene().buildIndex;
        if ( active < 2){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            } else if (active == 2)
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            } else {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        
    }
}
