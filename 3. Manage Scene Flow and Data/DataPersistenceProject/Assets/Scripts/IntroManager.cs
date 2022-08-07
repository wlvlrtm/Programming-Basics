using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class IntroManager : MonoBehaviour 
{
    // Main Scene Load
    public void Main() {
        SceneManager.LoadScene(1);
    }


    // Control the Game Quit function 
    public void Exit() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
