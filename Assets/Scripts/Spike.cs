using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	private float speed;
	public float axis;
	public Transform target;
	private float waitTime;

	private BoxCollider2D boxCollider;
	public Transform rightSensor;
	public Transform leftSensor;

	public enum currentState
	{
		active,
		inactive,
		retract
	}

	public currentState trapState;
	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		waitTime = 0;
		speed = 0.2f;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		trapState = currentState.inactive;
	}
	
	// Update is called once per frame
	void Update () {
		detectPlayer ();
		Invoke("trapMovement",waitTime);
	}

	void trapMovement ()
	{
		if (trapState == currentState.active) {
			StartCoroutine (move (speed * axis));
		}
		else
			if (trapState == currentState.retract) {
				StartCoroutine (move (speed * axis * -1));
			}
	}

	void detectPlayer()
	{
		if (target.position.y - this.transform.position.y > 0 && target.position.y - this.transform.position.y < 1 && !(trapState == currentState.active))
		{
			trapState = currentState.active;
			if ((target.position.x < rightSensor.transform.position.x + this.transform.position.y )&& target.position.x > this.transform.position.x) 
			{
				axis = 1;
			} 
			else if (target.position.x < this.transform.position.x)
			{
				trapState = currentState.active;
				axis = -1;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Block" || other.gameObject.tag == "Wall") {
			if (trapState == currentState.active) {
				trapState = currentState.retract;
				speed = 0.1f;
				waitTime = 3;
			} else {
				waitTime = 0;
				speed = 0.2f;
				trapState = currentState.inactive;

			}
		} 
	}

	public IEnumerator move(float speed)
	{
		this.transform.Translate (new Vector2 (speed, 0f));
		yield return null;
	}
}
