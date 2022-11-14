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
            // �p��Z��
            float d = Vector3.Distance(transform.position, player.transform.position);

            // ��W�@�ӳ̪񪺤���A������p�N�O���U��
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = player;
            }
        }
        
        
        // �S�����ʿ�J�A�åB����w���ĤH�A�������V�ĤH
        if (focusEnemy)
        {
            var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
        
    }
    void Fire()
    {
        // ���ͥX�l�u
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }


    // �@���g���� Coroutine �禡
    IEnumerator KeepShooting()
    {

        while (true)
        {
            
            // �g��
            Fire();



            // �Ȱ� 0.5 ��
            yield return new WaitForSeconds(0.5f);
        }
    }
}
