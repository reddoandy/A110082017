using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currScene = SceneManager.GetActiveScene();
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int ecount = enemys.Length;
        if (ecount == 0)
        {
            if (currScene.buildIndex==0)
            {
                SceneManager.LoadScene(1);
            }
            else if(currScene.buildIndex==1)
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
