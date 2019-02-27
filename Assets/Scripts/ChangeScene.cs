using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public string leveltoload;

    public void LoadNewScene()
    {
    	SceneManager.LoadScene(leveltoload);
    }
}
