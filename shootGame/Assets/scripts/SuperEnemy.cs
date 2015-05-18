using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : enemys
{

    public Transform m_rocket;
    protected float m_fireTime = 2;
    protected Transform m_player;

    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            m_player = obj.transform;
        }
    }
    protected override void UpdateMove()
    {
        m_fireTime -= Time.deltaTime;
        if (m_fireTime <= 0)
        {
            m_fireTime = 2;
            if (m_player != null)
            {
                Vector3 relative = m_transform.position - m_player.position;
                Instantiate(m_rocket, m_transform.position, Quaternion.LookRotation(relative));
            }
        }
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
