using UnityEngine;
using System.Collections;

public class Switch1 : Switch {

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		generatePath ();
	}

	protected override void generatePath()
	{
		if (animator.GetBool ("activated") && !animator.GetBool("pressed")) 
		{
			Instantiate(path,new Vector3 (4,8,0f), Quaternion.identity);
			Instantiate(path,new Vector3 (5,9,0f), Quaternion.identity);
			animator.SetBool ("pressed",true);
		}
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			animator.SetTrigger ("activated");
		} 

	}
}
