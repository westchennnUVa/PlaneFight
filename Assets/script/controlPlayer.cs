using UnityEngine;
using System.Collections;

public class controlPlayer : MonoBehaviour {

	// Use this for initialization
    public GameObject m_goPreBullet = null;
    public Transform m_tfFirePoint = null;
    public float m_speed = 10.0f;

    IEnumerator Fire()
    {
        if (Time.timeScale != 0)
        {
            GameObject goTemp = Instantiate(m_goPreBullet, m_tfFirePoint.position, m_tfFirePoint.rotation) as GameObject;
            yield return goTemp;
        }
    }
    public int m_MaxHP = 100;
    public int m_nHP = 100;
    public Transform m_tfHP = null;
  

    IEnumerator ChangeColor(){
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnHit(int nAP) {
        m_nHP -= nAP;

        m_tfHP.localScale = new Vector3((float)m_nHP / m_MaxHP, m_tfHP.localScale.y, m_tfHP.localScale.z);

        StartCoroutine("ChangeColor");

        if (m_nHP <= 0) {
            UIMgr.s_bGameOver = true;

            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left) * Time.deltaTime * m_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right) * Time.deltaTime * m_speed);
        } if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector2.up) * Time.deltaTime * m_speed);
        } if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down) * Time.deltaTime * m_speed);
        } if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Fire");
            StopCoroutine("Fire");
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals("enemy"))
		{
			m_nHP = 0;
			m_tfHP.localScale = new Vector3((float)m_nHP / m_MaxHP, m_tfHP.localScale.y, m_tfHP.localScale.z);
			Destroy(gameObject);
		}
	}
	

}
