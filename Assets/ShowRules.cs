using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShowRules : MonoBehaviour
{
    public void ShowMainMenu() 
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
