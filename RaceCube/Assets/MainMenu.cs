using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	private GameObject carmera;
	private GameObject light;
	private GameObject cube;

	private bool startMoveCarmera = false;

	private float cross_x_min = 0;
	private float cross_x_max = 0;
	private float x = 0;
	private float y = 0;
	private float z = 0;

	private int gamestate = 0;
	private const int MAINMENU = 0;
	private const int GMAEING = 1;

	private Vector2 firstTouch = Vector2.zero;
	private Vector2 secondTouch = Vector2.zero;

	// Use this for initialization
	void Start ()
	{
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
	void Update ()
	{
//		if (startMoveCarmera) {
//			if (carmera.transform.position.y >= 10.0f) {
//				//startMoveCarmera = false;
//				return;
//			}
//			carmera.transform.Translate (Vector3.up * Time.deltaTime * 2);
//		} else {
//
//			x = cube.transform.position.x;
//			if (x < -1.0f) {     
//				x = -1.0f;     
//			} else if (x > 1.0f) {     
//				x = 1.0f;     
//			}
//			cube.transform.Translate (Vector3.forward * Time.deltaTime);
//			carmera.transform.Translate (Vector3.forward * Time.deltaTime);
//		}

		switch (gamestate) {
		case MAINMENU:
			{
				if (startMoveCarmera) {
					if (carmera.transform.position.y >= 10.0f) {
						//startMoveCarmera = false;
						gamestate = GMAEING;
						return;
					}
					carmera.transform.Translate (Vector3.up * Time.deltaTime * 2);
				}
			}
			break;
		case GMAEING:
			{
				x = cube.transform.position.x;
				y = cube.transform.position.y;
				z = cube.transform.position.z + 0.05f;
				//cube.transform.Translate (Vector3.forward * Time.deltaTime);
				//carmera.transform.Translate (Vector3.forward * Time.deltaTime * 5);
				//cube.transform.Translate (Vector3.forward * Time.deltaTime * 5);
				// -4。5


				float cam_z = carmera.transform.position.z + 0.05f;
				//Debug.Log(z);
				carmera.transform.position = new Vector3 (carmera.transform.position.x, carmera.transform.position.y, cam_z);
			}
			break;
		}
	}
	
	void OnGUI ()
	{
//		if (!startMoveCarmera) {
//			if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height - 100) * 0.5f, 150f, 100f), "Start Game")) {	
//				startMoveCarmera = true;
//			}
//			if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height + 200) * 0.5f, 150f, 100f), "Start Exit")) {
//				Application.Quit ();
//			}
//		} else
//		{
//			GUI.Label(new Rect(0,0,480,100),"Position is " + Input.acceleration);
//			GUI.Label(new Rect(0,20,480,100),"Position is " + cube.transform.position.ToString());
//		}
//
//		cube.transform.position = new Vector3 (Input.acceleration.x, Input.acceleration.y, cube.transform.position.z * Time.deltaTime);
	
		switch (gamestate) {
		case MAINMENU:
			{
				if (!startMoveCarmera) {
					if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height - 100) * 0.5f, 150f, 100f), "Start Game")) {	
						startMoveCarmera = true;
					}
					if (GUI.Button (new Rect ((Screen.width - 150) * 0.5f, (Screen.height + 200) * 0.5f, 150f, 100f), "Start Exit")) {
						Application.Quit ();
					}
				}
			}
			break;
		case GMAEING:
			{
				GUI.Label (new Rect (0, 0, 480, 100), "Position is " + Input.acceleration);
				GUI.Label (new Rect (0, 20, 480, 100), "Position is " + cube.transform.position.ToString ());
//				if (x < -1.0f) {     
//					x = -1.0f;     
//				} else if (x > 1.0f) {     
//					x = 1.0f;     
//				}
//				if (y <= 8.0f) {
//					y = 8.0f;
//				} else if (y > 16.0f) {
//					y = 16.0f;
//				}
				//cube.transform.position = new Vector3 (Input.acceleration.x, y, z);
				if (Event.current.type == EventType.MouseDown) {
					firstTouch = Event.current.mousePosition;
				}
				if (Event.current.type == EventType.MouseDrag) {
					secondTouch = Event.current.mousePosition;
					if (secondTouch.x < firstTouch.x) {
						//tran.Translate(Vector3.left*0.7f);
						Debug.Log("left");
						cube.transform.position = new Vector3 (x - 0.1f, y, z);
					}
					if (secondTouch.x > firstTouch.x) {
						Debug.Log("right");
						cube.transform.position = new Vector3 (x + 0.1f, y, z);
					}
					firstTouch = secondTouch;
				}
				x = cube.transform.position.x;
				y = cube.transform.position.y;
				cube.transform.Rotate (new Vector3 (0, 0, 0));
				cube.transform.position = new Vector3 (x, y, z);
			}
			break;
		}
	}
}
