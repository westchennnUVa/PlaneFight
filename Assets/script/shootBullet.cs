using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {

	void Start () {
	
	}
    public float m_speed = 10.0f;

	void Update () {
        transform.Translate((Vector2.right) * Time.deltaTime * m_speed);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("enemy"))
        {
            UIMgr.s_nScore += 100;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
