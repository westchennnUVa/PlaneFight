using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour
{

    public GameObject enemy;

    float nowTime;
    public float enemyRate;
    float currentTime;


    void Update()
    {
        if (Time.time > nowTime)
        {
            nowTime = Time.time + enemyRate;
            Instantiate(enemy, new Vector3(500, Random.Range(-20, 280), 0), Quaternion.identity);
        }


    }
}