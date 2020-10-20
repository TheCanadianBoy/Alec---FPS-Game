using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Manager()
    {
        GameManager.Instance.LoadNewScene();     
    }

    public void Quit()
    {
        GameManager.Instance.Quit();
    }
}
