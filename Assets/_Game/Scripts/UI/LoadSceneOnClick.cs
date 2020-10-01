using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    //Loads scene based on index
	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
    public void LoadAdditionalSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex,LoadSceneMode.Additive);
    }
}
