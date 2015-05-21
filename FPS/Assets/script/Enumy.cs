using UnityEngine;
using System.Collections;

public class Enumy : MonoBehaviour {


    Transform m_transform;
    Player m_player;
    NavMeshAgent m_agent; //AI group
    float m_movSpeed = 10.0f;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_agent = GetComponent<NavMeshAgent>();

        m_agent.SetDestination(m_player.m_transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        m_agent.SetDestination(m_player.m_transform.position);
        MoveTo();
	}

    void MoveTo()
    {
        float speed = m_movSpeed * Time.deltaTime;
        m_agent.Move(m_transform.TransformDirection(new Vector3(0,0,speed)));
    }
}
