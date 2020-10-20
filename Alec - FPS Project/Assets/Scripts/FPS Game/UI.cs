using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text enemyCounter;

    void Update()
    {
        EnemyCounter();
    }

    public void EnemyCounter()
    {
        enemyCounter.text = "Enemies remaing : " + gameManager.enemyNb.ToString();
    }


}
