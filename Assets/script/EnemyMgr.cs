using UnityEngine;
using System.Collections;

public class EnemyMgr : MonoBehaviour {


    public GameObject m_preEnemy = null;
    public float m_fTine = 2.0f;

	void Start () {
        InvokeRepeating("StartCreate", m_fTine, m_fTine);
	}
	

	void StartCreate () {
        StartCoroutine(Create());
	}

    IEnumerator Create() {
        float fY = Random.Range(-4.0f,4.0f); 

        Vector3 vec = new Vector3(m_preEnemy.transform.position.x,
                                    fY,
                                    m_preEnemy.transform.position.z);
        
        Instantiate(m_preEnemy,vec,m_preEnemy.transform.rotation);
        yield return null;
    }

}
