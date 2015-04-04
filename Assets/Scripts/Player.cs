using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	private float Xaxis;
	private float Yaxis;
	public float playerMoveSpeed;
	private bool disableMove;

	public LayerMask Object;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D; 

	public enum playerDirection
	{
		isOnX,
		isOnY

	}

	public enum playerYdirection
	{
		isUp,
		isDown
	}

	public playerDirection direction;
	public playerYdirection Yside;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		disableMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		AxisXY ();

		movePlayer ();

		attack ();
	}

	void AxisXY()
	{
		Xaxis = Input.GetAxis ("Horizontal")*playerMoveSpeed*Time.deltaTime;
		Yaxis = Input.GetAxis ("Vertical")*playerMoveSpeed*Time.deltaTime;
	}


	void movePlayer()
	{
		if(!animator.GetBool ("attackUp") && !animator.GetBool ("attackDown") && !animator.GetBool ("attackRight") && !disableMove)
		{
			movement ();
		}
	}
	
	void movement ()
	{
		if (Xaxis != 0 && Yaxis == 0) {
			direction = playerDirection.isOnX;
			this.transform.Translate (new Vector2 (Xaxis, 0f));
			animator.SetBool ("walkRight", true);
			setWalkAnimationLeftOrRight ();
		}
		else {
			animator.SetBool ("walkRight", false);
		}
		if (Yaxis != 0 && Xaxis == 0) {
			direction = playerDirection.isOnY;
			this.transform.Translate (new Vector2 (0f, Yaxis));
			setWalkAnimationUpOrDown ();
		}
		else {
			animator.SetBool ("walkUp", false);
			animator.SetBool ("walkDown", false);
		}
		if (Yaxis != 0 && Xaxis != 0) {
			this.transform.Translate (new Vector2 (Xaxis, Yaxis));
			if (direction == playerDirection.isOnX) {
				animator.SetBool ("walkRight", true);
				setWalkAnimationLeftOrRight ();
			}
			else {
				setWalkAnimationUpOrDown ();
			}
		}
	}
	
	void attack()
	{
		if (Input.GetKeyDown (KeyCode.X)) 
		{
		
			if (direction == playerDirection.isOnX) 
			{
				animator.SetTrigger ("attackRight");
			}
			if (direction == playerDirection.isOnY) 
			{
				if (Yside == playerYdirection.isUp) 
				{
					animator.SetTrigger ("attackUp");
				}
				else if(Yside == playerYdirection.isDown) 
				{
					animator.SetTrigger ("attackDown");
				}
			}
		}
	}
	
	void setWalkAnimationLeftOrRight ()
	{
		if (Xaxis > 0) {
			//flip right
			this.transform.localScale = new Vector2 (1, 1);
		}
		else
			if (Xaxis < 0) {
				//flip left
				this.transform.localScale = new Vector2 (-1, 1);
			}
	}

	void setWalkAnimationUpOrDown ()
	{
		if (Yaxis > 0)
		{
			animator.SetBool("walkDown", false);
			animator.SetBool ("walkUp", true);
			Yside = playerYdirection.isUp;
		}
		else 
		{
			animator.SetBool ("walkUp", false);
			animator.SetBool ("walkDown", true);
			Yside = playerYdirection.isDown;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Hole")
		{
			disableMove = true;
			animator.SetTrigger("fall");
			Invoke("respawn",1f);
		}
	}

	private void respawn()
	{
		this.gameObject.SetActive (false);
		this.transform.position =  (new Vector2(8, 2));
		this.gameObject.SetActive (true);
		disableMove = false;
	}
}
