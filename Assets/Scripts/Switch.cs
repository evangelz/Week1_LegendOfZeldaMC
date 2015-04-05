using UnityEngine;
using System.Collections;

public abstract class Switch : MonoBehaviour {

	public GameObject path;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected abstract void generatePath();
	
}
