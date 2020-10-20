using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyNb = 0;
    public int reduceCounter = 1;
    [SerializeField] GameObject buttonSwitch;
    [SerializeField] GameObject buttonQuit;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<GameManager>();
                    singleton.name = "(Singleton) GameManager";
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
        enemyNb = 1;

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        buttonSwitch.gameObject.SetActive(false);
        buttonQuit.gameObject.SetActive(false);
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNb = enemies.Length;
        EnemyCountCheck();
    }

    public void EnemyKill()
    {
        enemyNb--;
        if(enemyNb == 0)
        {
            Time.timeScale = 0;
            buttonSwitch.gameObject.SetActive(true);
            buttonQuit.gameObject.SetActive(true);
        }
    }

    public void EnemyCountCheck()
    {
        if (enemyNb == 0)
        {
            buttonSwitch.gameObject.SetActive(true);
            buttonQuit.gameObject.SetActive(true);
            if(!SceneManager.GetSceneByName("Menu").isLoaded)
            {
                Cursor.visible = true;
            }
        }
    }


    public void LoadNewScene()
    {
        if (SceneManager.GetSceneByName("Menu").isLoaded)
        {
            SceneManager.LoadScene("SampleScene");
            Cursor.visible = false;
        }
        else if(SceneManager.GetSceneByName("SampleScene").isLoaded)
        {
            SceneManager.LoadScene("Scene2");
            Cursor.visible = true;
            Cursor.visible = false;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
        buttonSwitch.gameObject.SetActive(false);
        buttonQuit.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

}
