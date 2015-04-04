﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class polygonGenerator : MonoBehaviour {

	public List<Vector3> newVertices = new List<Vector3>();

	public List<int> newTriangles = new List<int>();

	public List<Vector2> newUV = new List<Vector2>();

	private Mesh mesh;

	private float tUnit = 0.25f;
	private Vector2 tStone = new Vector2 (0,0);
	private Vector2 tGrass = new Vector2 (0,1);

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;

		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		newVertices.Add (new Vector3 (x, y, z));
		newVertices.Add (new Vector3 (x + 1, y, z));
		newVertices.Add (new Vector3 (x + 1, y-1, z));
		newVertices.Add (new Vector3 (x, y-1, z));

		newTriangles.Add (0);
		newTriangles.Add (1);
		newTriangles.Add (3);
		newTriangles.Add (1);
		newTriangles.Add (2);
		newTriangles.Add (3);

		newUV.Add (new Vector2 (tUnit * tStone.x, tUnit * tStone.y + tUnit));
		newUV.Add (new Vector2 (tUnit * tStone.x+tUnit, tUnit * tStone.y + tUnit));
		newUV.Add (new Vector2 (tUnit * tStone.x +tUnit, tUnit * tStone.y));
		newUV.Add (new Vector2 (tUnit * tStone.x, tUnit * tStone.y));

		mesh.Clear ();
		mesh.vertices = newVertices.ToArray ();
		mesh.triangles = newTriangles.ToArray ();
		mesh.Optimize ();
		mesh.RecalculateNormals ();



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
