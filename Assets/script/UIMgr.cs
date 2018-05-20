using UnityEngine;
using System.Collections;

public class UIMgr : MonoBehaviour
{

    private Ray m_ray;
    private RaycastHit m_hit;
    public Camera m_UICamera;
    public GameObject m_goPlay = null;
    public GameObject m_goPause = null;
    public GameObject m_goGameOver = null;
    public TextMesh m_textScore = null;
    public static bool s_bGameOver = false;
    public static int s_nScore = 0;

    void Start(){
            m_textScore.text=0.ToString(); 
        }

    void Update()
    {
        if (s_bGameOver){
                    if (!m_goGameOver.activeSelf)
                    {
                        m_goGameOver.SetActive(true);
                    }
                }

        m_textScore.text = s_nScore.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            m_ray = m_UICamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(m_ray, out m_hit))
            {
                if (m_hit.transform.tag.Equals("pause"))
                {
                    Time.timeScale = 0;

                    m_goPause.SetActive(false);
                    m_goPlay.SetActive(true);

                }
                else if (m_hit.transform.tag.Equals("play"))
                {
                    Time.timeScale = 1;
                    m_goPlay.SetActive(false);
                    m_goPause.SetActive(true);
                }else if (m_hit.transform.tag.Equals("Renew"))
                {
                    s_bGameOver = false;
                    s_nScore = 0;
                    Application.LoadLevel(0);
                }
            }
        }
    }
}
