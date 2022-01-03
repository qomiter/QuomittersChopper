using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{

    private void OnDestroy() 
    {
        //PlayerPrefs.SetInt("highscore", dodah.highScore);
        //PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

}
