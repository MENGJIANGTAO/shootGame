using UnityEngine;
using System.Collections;

public class enemys : MonoBehaviour {

    public float m_speed = 5;

    private float m_life = 1.0f;

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
        if (m_transform.position.z < -26) {
            Destroy(this.gameObject);
            Debug.Log("Enemy down.");
        }
        m_timer -= Time.deltaTime;
        if (m_timer <= 0) {
            m_timer = 3;
            m_rotspeed = -m_rotspeed;
        }
        m_transform.Rotate(Vector3.up, m_rotspeed * Time.deltaTime, Space.World);
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other){
        if (other.tag.CompareTo("PlayerBullets") == 0) {
            bullets bullet = other.GetComponent<bullets>();
            if (bullet != null) {
                m_life -= bullet.m_power;

                if (m_life <= 0) {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.tag.CompareTo("Player") == 0)
        {
            Debug.Log("hit the player body.");
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}
