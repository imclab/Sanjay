using UnityEngine;
using System.Collections;

public class plane{
	public GameObject planes;
	public Vector3 pos;
	public Vector3 dir;
	public float sp;
	public bool act;
}

public class Airplane : MonoBehaviour {	
	public GameObject airplane;	
	public plane[] pl = new plane[500];
	// Use this for initialization
	void Start () {	
		for(int i = 0;i<500;i++)
		{
			pl[i] = new plane();
			pl[i].pos = new Vector3(Random.Range(0,2000),
											 Random.Range(10,50),
											 Random.Range(0,2000));
			pl[i].dir = new Vector3(Random.value,Random.value,Random.value);
			pl[i].sp = Random.Range(1,5);
			pl[i].act = true;
			pl[i].planes = (GameObject)Instantiate(airplane,pl[i].pos,Quaternion.identity);			
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0;i<500;i++)
		{
			if(pl[i].act == true)
				pl[i].planes.transform.position -= pl[i].dir * 0.0001f;
			else 
				pl[i].planes.rigidbody.useGravity = false;
			
			if(pl[i].planes.transform.position.y < 2){
				pl[i].planes.rigidbody.useGravity = true;
				if(pl[i].planes.transform.position.y < 0.5)
					pl[i].act = false;
			}			
		}
	}
}
