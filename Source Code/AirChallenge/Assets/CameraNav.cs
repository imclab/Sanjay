using UnityEngine;
using System.Collections;

public class CameraNav : MonoBehaviour {
	public GameObject cam;
	// Use this for initialization
	void Start () {
	cam.transform.position = new Vector3(1000,30,1000);
	cam.transform.rotation = Quaternion.Euler(90,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up") && cam.transform.position.z < 2000)
				cam.transform.position -= new Vector3(0,0,5);
		if (Input.GetKeyDown ("down")&& cam.transform.position.z > 0)
			cam.transform.position += new Vector3(0,0,5);
		if (Input.GetKeyDown ("right")&& cam.transform.position.x < 2000)
			cam.transform.position -= new Vector3(5,0,0);
		if (Input.GetKeyDown ("left")&& cam.transform.position.x > 0)
			cam.transform.position += new Vector3(5,0,0);
		if (Input.GetKeyDown (KeyCode.D)&& cam.transform.position.y > 2)
			cam.transform.position -= new Vector3(0,2,0);
		if (Input.GetKeyDown (KeyCode.A)&& cam.transform.position.y < 100)
			cam.transform.position += new Vector3(0,2,0);
	}
}
