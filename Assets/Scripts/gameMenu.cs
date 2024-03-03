using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMenu : MonoBehaviour
{
    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
