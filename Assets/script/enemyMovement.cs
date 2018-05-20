using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    public GameObject m_goPreBullet = null;
    public Transform m_tfFirePoint = null;
    public float m_speed = 5.0f;
    float nowTime;
    float currentTime;
    public float enemyRate;

    IEnumerator Fire()
    {
        GameObject goTemp = Instantiate(m_goPreBullet, m_tfFirePoint.position, m_tfFirePoint.rotation) as GameObject;
        yield return goTemp;
    }

	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime*m_speed);
        if (Time.time > nowTime)
        {
            nowTime = Time.time + enemyRate;
            StartCoroutine("Fire");
            StopCoroutine("Fire");
        }
	}
}
