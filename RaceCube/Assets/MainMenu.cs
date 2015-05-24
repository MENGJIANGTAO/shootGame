using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	private GameObject carmera;
	private GameObject light;
	private GameObject cube;

	private bool startMoveCarmera = false;

	private float cross_x_min = 0;
	private float cross_x_max = 0;
	private float x = 0;
	private float y = 0;
	private float z = 0;
	// Use this for initialization
	void Start () {
		carmera = GameObject.Find ("Camera");
		light = GameObject.Find ("Light");
		cube = GameObject.Find ("Cube");
		x = cube.transform.position.x;
		y = cube.transform.position.y;
		z = cube.transform.position.z;
		cross_x_min = -1;
		cross_x_max = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoveCarmera) 
		{
			if(carmera.transform.position.y>=10.0f)
			{
				//startMoveCarmera = false;
				return ;
			}
			carmera.transform.Translate(Vector3.up * Time.deltaTime*2);
		}

		x = cube.transform.position.x;
		if(x < -1.0f){     
			x = -1.0f;     
		}else if(x > 1.0f){     
			x = 1.0f;     
		}
	}
	
	void OnGUI()
	{
		if (!startMoveCarmera) {
			if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height - 100) * 0.5f, 150f, 100f), "Start Game")) {	
				startMoveCarmera = true;
			}
			if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height + 200) * 0.5f, 150f, 100f), "Start Exit")) {
				Application.Quit ();
			}
		} else
		{
			GUI.Label(new Rect(0,0,480,100),"Position is " + Input.acceleration);
			GUI.Label(new Rect(0,20,480,100),"Position is " + cube.transform.position.ToString());
		}

		cube.transform.position = new Vector3 (Input.acceleration.x, y, z);
	}
}
