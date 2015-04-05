using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization
	void Start () {
		Instantiate (enemy, new Vector3 (5,15,0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
