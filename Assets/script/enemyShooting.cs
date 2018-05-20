using UnityEngine;
using System.Collections;

public class enemyShooting : MonoBehaviour {

    public float m_speed = 5.0f;

	void Start () {
	
	}
    public int m_nAP = 1;
	void Update () {
        transform.Translate((Vector2.left) * Time.deltaTime * m_speed);

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            col.transform.GetComponent<controlPlayer>().OnHit(m_nAP);
            Destroy(gameObject);
        }
    }
}
