﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // All scripts have these functions, Awake() was added, but commenting these are it's not required for the Start Scene  - Vineet

    /*void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void  GoToPlay()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void GoToTest()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartSceneVince", LoadSceneMode.Single);
    }
    
    public void quitGame()
    {
        #if UNITY_STANDALONE
        Application.Quit();
        #endif

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
