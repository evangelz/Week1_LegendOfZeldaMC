using UnityEngine;
using System.Collections;


public class EyeGore : MonoBehaviour {

	private Animator animator;

	public bool patrolMode;
	public float waitTime;
	public float speed;
	public float walkingTime;
	public float changeDirectionTime;
	public Transform startPoint;
	public Transform playerPosition;

	public Transform topY;
	public Transform botY;

	public enum enemyState
	{
		isRight,
		isLeft,
		isUp,
		isDown,
		isWaiting
	}

	public enum VisionOrientation
	{
		VisionX,
		VisionY
	}

	public enemyState enemyFaces;
	public VisionOrientation currentVision;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		patrolMode = true;
	}
	
	// Update is called once per frame
	void Update () {
		transformVisionPoints ();
		if (patrolMode) 
		{
			StartCoroutine (patrolState ());
		}
	}

	public IEnumerator patrolState()
	{

		if (enemyFaces == enemyState.isLeft) 
		{
			this.transform.Translate(new Vector2(-speed*Time.deltaTime,0));
			this.transform.localScale = new Vector2(1,1);
			animator.SetBool ("walkLeft",true);
			yield return new WaitForSeconds(walkingTime);
			wait ();
			if (enemyFaces == enemyState.isWaiting) 
			{
				animator.SetBool ("walkLeft",false);
				yield return new WaitForSeconds (waitTime);
				fireLaser ();
				animator.SetBool ("walkLeft",true);
			}
			goRight();
		}
		else if (enemyFaces == enemyState.isRight) 
		{
			this.transform.Translate(new Vector2(speed*Time.deltaTime,0));
			this.transform.localScale = new Vector2(-1,1);
			animator.SetBool ("walkLeft",true);
			yield return new WaitForSeconds(walkingTime);
			wait ();
			if (enemyFaces == enemyState.isWaiting) 
			{
				animator.SetBool ("walkLeft",false);
				yield return new WaitForSeconds (waitTime);
				fireLaser ();
				animator.SetBool ("walkLeft",true);
			}
			goLeft();

		}
		if (enemyFaces == enemyState.isUp) 
		{
			this.transform.Translate(new Vector2(0,speed*Time.deltaTime));
			animator.SetBool ("walkUp",true);
			yield return new WaitForSeconds(walkingTime);
			wait ();
			if (enemyFaces == enemyState.isWaiting) 
			{
				animator.SetBool ("walkUp",false);
				yield return new WaitForSeconds (waitTime);
				fireLaser ();
				animator.SetBool ("walkDown",true);
			}
			goDown();
		}
		else if (enemyFaces == enemyState.isDown) 
		{
			this.transform.Translate(new Vector2(0,-speed*Time.deltaTime));
			animator.SetBool ("walkDown",true);
			yield return new WaitForSeconds (waitTime);
			wait ();
			if (enemyFaces == enemyState.isWaiting) 
			{
				animator.SetBool ("walkDown",false);
				yield return new WaitForSeconds (waitTime);
				fireLaser ();
				animator.SetBool ("walkUp",true);
			}
			goUp();
		}

	}

	void chaseState()
	{
		if (enemyFaces == enemyState.isLeft) 
		{
			enemyFaces = enemyState.isLeft;
			this.transform.Translate(new Vector2(-speed*Time.deltaTime,0));
			this.transform.localScale = new Vector2(1,1);
			animator.SetBool ("walkLeft",true);
			animator.SetBool ("walkUp", false);
			animator.SetBool ("walkDown", false);
			StartCoroutine(changeDirectionDuringChase());
		}
		else if (enemyFaces == enemyState.isRight) 
		{
			this.transform.Translate(new Vector2(speed*Time.deltaTime,0));
			this.transform.localScale = new Vector2(-1,1);
			animator.SetBool ("walkLeft",true);
			animator.SetBool ("walkUp", false);
			animator.SetBool ("walkDown", false);
			StartCoroutine(changeDirectionDuringChase());
		}
		else if (enemyFaces == enemyState.isUp) 
		{
			this.transform.Translate(new Vector2(0,speed*Time.deltaTime));
			animator.SetBool ("walkUp",true);
			animator.SetBool ("walkLeft",false);
			animator.SetBool ("walkDown", false);
			StartCoroutine(changeDirectionDuringChase());
		}
		else if (enemyFaces == enemyState.isDown) 
		{
			this.transform.Translate(new Vector2(0,-speed*Time.deltaTime));
			animator.SetBool ("walkDown",true);
			animator.SetBool ("walkUp",false);
			animator.SetBool ("walkLeft",false);
			StartCoroutine(changeDirectionDuringChase());
		}

	}

	public IEnumerator changeDirectionDuringChase()
	{
		yield return new WaitForSeconds(changeDirectionTime);
		if (enemyFaces == enemyState.isRight || enemyFaces == enemyState.isLeft)
		{
			if (playerPosition.position.y > this.transform.position.y) 
			{
				enemyFaces = enemyState.isUp;
			} 
			else if (playerPosition.position.y < this.transform.position.y) 
			{
				enemyFaces = enemyState.isDown;
			} 
		}
		else if (enemyFaces == enemyState.isUp || enemyFaces == enemyState.isDown)
		{
			if (playerPosition.position.x < this.transform.position.x) 
			{
				enemyFaces = enemyState.isLeft;
			}
			else if (playerPosition.position.x > this.transform.position.x) 
			{
				enemyFaces = enemyState.isRight;
			}
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		/*if (other.tag == "Player") 
		{
			Debug.DrawLine (startPoint.position, playerPosition.position, Color.red);
			if (playerPosition.position.x < this.transform.position.x && enemyFaces == enemyState.isLeft) 
			{
				print ("ok");
				patrolMode = false;
				chaseState ();
			}
			else if(playerPosition.position.x>this.transform.position.x && enemyFaces == enemyState.isRight)
			{
				patrolMode = false;
				chaseState ();
			}
			else if(playerPosition.position.y>this.transform.position.y && enemyFaces == enemyState.isUp)
			{
				patrolMode = false;
				chaseState ();
			}
			else if (playerPosition.position.y<this.transform.position.y && enemyFaces == enemyState.isDown)
			{
				patrolMode = false;
				chaseState ();
			}
		} */
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			animator.SetBool ("walkUp",false);
			animator.SetBool ("walkLeft",false);
			animator.SetBool ("walkDown", false);
			patrolMode = true;
			if(playerPosition.position.y<topY.position.y && playerPosition.position.y>botY.position.y)
			{
				print ("hi");
			}
		}
	}

	void transformVisionPoints()
	{
		topY.position = new Vector2 (this.transform.position.x,this.transform.position.y+this.transform.localScale.y/2);
		botY.position = new Vector2 (this.transform.position.x,this.transform.position.y-this.transform.localScale.y/2);
	}

	void fireLaser ()
	{

	}	

	void goRight()
	{
		enemyFaces = enemyState.isRight;
	}

	void goLeft()
	{
		enemyFaces = enemyState.isLeft;
	}

	void goUp()
	{
		enemyFaces = enemyState.isUp;
	}

	void goDown()
	{
		enemyFaces = enemyState.isDown;
	}

	void wait()
	{
		enemyFaces = enemyState.isWaiting;
	}
}
