﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class player : MonoBehaviour {

    public float m_speed = 3.0f;
    public Transform m_bullets;
    protected Transform m_transform;
    private float m_bulletRate = 0.10f;
	// Use this for initiaization
	void Start () {
        m_transform = this.transform;
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
            }
        }

        this.m_transform.Translate(new Vector3(move_h, 0, move_v));
	}
}
