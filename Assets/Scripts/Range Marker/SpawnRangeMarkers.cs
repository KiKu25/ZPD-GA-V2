using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRangeMarkers : MonoBehaviour {

    public GameObject rangeMarkerPref;
    public int minX;
    public int maxX;

    private float y = -37f;

	// Use this for initialization
	void Start () {
        GenRangeMarkers();
	}
	
    /// <summary>
    /// Generates Range Markers
    /// </summary>
	private void GenRangeMarkers()
    {
        GameObject go = new GameObject();
        go.name = "Range Markers";

        for (int i = minX; i <= maxX; i++)
        {
            if (i == 0 || i % 5 == 0)
            {
                GameObject temp = Instantiate(rangeMarkerPref, new Vector3(i, y, 0), Quaternion.identity);
                temp.transform.SetParent(go.transform);
            }
        }  
    }
}
