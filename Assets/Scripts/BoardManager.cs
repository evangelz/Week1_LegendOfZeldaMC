using UnityEngine;
using System;
using System.Collections.Generic;

	public class BoardManager : MonoBehaviour
	{

		
		
		public int columns;                                        
		public int rows;                                           
		public GameObject[] room1;                      
		
		private Transform boardHolder;                               
		private List <Vector3> gridPositions = new List <Vector3> ();  
		public GameObject[] blocks;
		public GameObject[] trap;

		void InitialiseList ()
		{
			gridPositions.Clear ();
			for(int x = 0; x < columns; x++)
			{
				for(int y = 0; y< rows; y++)
				{
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}
		
		
		//Sets up the outer walls and floor (background) of the game board.
		void BoardSetup ()
		{
			boardHolder = new GameObject ("Board").transform;
			for(int x = 0; x < columns; x++)
			{
				
				for(int y = 0; y < rows; y++)
				{
						GameObject toInstantiate = room1[x*20+y];
						GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
						instance.transform.SetParent (boardHolder);
				}
			}
		}
		
		

		
		

		public void SetupScene ()
		{

			BoardSetup ();
			
			InitialiseList ();
			generateObjects ();
			generateTrap ();
		}

		void generateObjects ()
		{
			Instantiate (blocks[0],new Vector3 (3,4,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (3,6,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (4,6,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (5,4,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (5,6,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (6,4,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (7,4,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (7,6,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (8,5,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (9,4,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (9,7,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (10,3,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (10,6,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (10,7,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (11,5,0f), Quaternion.identity);
			Instantiate (blocks[0],new Vector3 (12,4,0f), Quaternion.identity);
			Instantiate (blocks[1],new Vector3 (12,6,0f), Quaternion.identity);
			Instantiate (blocks[1],new Vector3 (12,7,0f), Quaternion.identity);
			Instantiate (blocks[2],new Vector3 (3,7,0f), Quaternion.identity);
			Instantiate (blocks[2],new Vector3 (11,6,0f), Quaternion.identity);
		}
		
		void generateTrap()
		{
			Instantiate (trap[0],new Vector3 (3,3,0f), Quaternion.identity);
			Instantiate (trap[0],new Vector3 (3,5,0f), Quaternion.identity);
			
		}	


	}
