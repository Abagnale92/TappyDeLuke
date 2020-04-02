using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {
public static GameManager Instance;
public void OnClickGame()
    {
        
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }    

}
