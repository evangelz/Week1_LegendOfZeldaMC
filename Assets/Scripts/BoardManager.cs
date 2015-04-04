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
			
		}
	}
