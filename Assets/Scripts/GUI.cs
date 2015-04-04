using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	public Transform camera;
	public float Xoffset;
	public float Yoffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (camera.transform.position.x - Xoffset,camera.transform.position.y-Yoffset,0f);
	}
}
