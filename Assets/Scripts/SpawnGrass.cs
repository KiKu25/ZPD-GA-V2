using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour {

    //Public variables
    public Vector2 startingCoords;

    public float xOffset;

    public GameObject grassGO;

    public int numberOfTiles;
    //Private variables
    private Vector2 currentCoords;

	// Use this for initialization
	void Start () {
        GenGrass();
	}

    private void GenGrass()
    {
        GameObject parent = new GameObject();
        parent.name = "Grass Parent";

        currentCoords = startingCoords;

        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject child = Instantiate(grassGO, new Vector3(currentCoords.x, currentCoords.y, 0), Quaternion.identity);
            child.transform.SetParent(parent.transform);
            currentCoords.x += xOffset;
        }
    }
}
