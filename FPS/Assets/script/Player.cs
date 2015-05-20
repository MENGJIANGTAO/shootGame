using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Transform m_transform;
    public int m_life = 5;

    private Transform m_camTransform;
    Vector3 m_camRot;
    float m_camHeight = 1.4f;

    CharacterController m_ch;

    private float m_moveSpeed = 10.0f;
    private float m_gravity = 2.0f;
    
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        m_ch = this.GetComponent<CharacterController>();
        m_camTransform = Camera.main.transform;
        Vector3 pos = m_transform.position;
        pos.y = m_camHeight;
        m_camTransform.position = pos;

        m_camTransform.rotation = m_transform.rotation;
        m_camRot = m_camTransform.eulerAngles;

        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_life < 0) 
        {
            return;
        }
        Control();
	}

    void Control()
    {
        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        m_camRot.x -= rv;
        m_camRot.y += rh;
        m_camTransform.eulerAngles = m_camRot;

        Vector3 camrot = m_camTransform.eulerAngles;
        camrot.x = 0;
        camrot.z = 0;
        m_transform.eulerAngles = camrot;

        float xm = 0.0f;
        float ym = 0.0f;
        float zm = 0.0f;

        ym -= m_gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            zm += m_moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zm -= m_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xm -= m_moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xm += m_moveSpeed * Time.deltaTime;
        }

        m_ch.Move(m_transform.TransformDirection(new Vector3(xm, ym, zm)));

        Vector3 pos = m_transform.position;
        pos.y += m_camHeight;
        m_camTransform.position = pos;
    }
}
