using UnityEngine;
using System.Collections;

public class MoveBG : MonoBehaviour {

    public Vector2 m_vecSpeed = Vector2.zero;

    MeshRenderer mr;


	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
       mr.material.mainTextureOffset += m_vecSpeed * Time.deltaTime;
    }
}
