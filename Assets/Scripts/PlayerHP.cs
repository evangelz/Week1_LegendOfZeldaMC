using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour {
	
	public int startingHealth;
	public int healthPerHeart;
	private int currentHealth;
	private int maxHealth;

	public GUITexture heartGUI;
	
	private ArrayList hearts = new ArrayList();
	
	
	private Transform health;
	public int maxHeartsPerRow;
	
	
	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
		AddHearts (startingHealth / healthPerHeart);
	}
	
	public void AddHearts(int numberOfHearts)
	{
		health = new GameObject ("Health").transform;
		for (int i = 0; i<numberOfHearts; i++)
		{
			GameObject instance = Instantiate (heartGUI, new Vector3 (i/1.5f, 0f, 0f), Quaternion.identity) as GameObject;
			
			/*int y = Mathf.FloorToInt(hearts.Count/maxHeartsPerRow);
			int x = hearts.Count - y*maxHeartsPerRow;*/
			
			instance.transform.SetParent (health);
		}
		maxHealth += number*healthPerHeart;
	}
	
	public void ModifyHealth(int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
	}
}
