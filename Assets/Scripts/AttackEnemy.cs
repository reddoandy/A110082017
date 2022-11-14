using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    private GameObject focusEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KeepShooting());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
        float miniDist = 9999;
        foreach (GameObject player in Player)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, player.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = player;
            }
        }
        
        
        // 沒有移動輸入，並且有鎖定的敵人，漸漸面向敵人
        if (focusEnemy)
        {
            var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
        
    }
    void Fire()
    {
        // 產生出子彈
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }


    // 一直射擊的 Coroutine 函式
    IEnumerator KeepShooting()
    {

        while (true)
        {
            
            // 射擊
            Fire();



            // 暫停 0.5 秒
            yield return new WaitForSeconds(0.5f);
        }
    }
}
