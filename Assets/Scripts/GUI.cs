using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	public Transform camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (camera.transform.position.x,camera.transform.position.y,0f);
	}
}
