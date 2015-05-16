using UnityEngine;
using System.Collections;

public class enemys : MonoBehaviour {

    public float m_speed = 17;
    protected float m_rotspeed = 30;
    protected float m_timer = 1.5f;

    protected Transform m_transform;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMove();
	}

    protected void UpdateMove() {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0) {
            m_timer = 3;
            m_rotspeed = -m_rotspeed;
        }
        m_transform.Rotate(Vector3.up, m_rotspeed * Time.deltaTime, Space.World);
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
