using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
