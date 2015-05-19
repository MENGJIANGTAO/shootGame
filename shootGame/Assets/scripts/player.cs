using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class player : MonoBehaviour {

    public float m_speed = 3.0f;
    public Transform m_bullets;
    public AudioClip m_shootClip;
    public Transform m_explosionFX;

    protected AudioSource m_audio;
    protected Transform m_transform;
    private float m_bulletRate = 0.10f;
    public float m_life = 2.0f;
	// Use this for initiaization
	void Start () {
        m_transform = this.transform;
        m_audio = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float move_v = 0.0f;
        float move_h = 0.0f;

        m_bulletRate -= Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move_v -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move_v += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move_h += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move_h -= m_speed * Time.deltaTime;
        }
        if (m_bulletRate <= 0)
        {
            m_bulletRate = 0.1f;
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(m_bullets, m_transform.position, m_transform.rotation);
                m_audio.Play();
            }
        }

        this.m_transform.Translate(new Vector3(move_h, 0, move_v));
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerBullets") != 0)
        {
            m_life -= 1;
            Debug.Log("sub one blood.");
        }

        if (m_life <= 0) {
            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
