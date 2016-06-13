using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float tileSizeZ;

    private float scrollSpeed = -0.25f;
    private Vector3 startPosition;  // the starting position

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        // multiplying the time and the rate gives distance.  However, this distance will become
        // very large as the time increases.  We only want a tile to move at max a distance equal
        // to its length along the z axis.  Mathf.Repeat will yield a number between 0 and the maximum
        // z-axis size.  That's why the documentation says it is like modulo
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        // Debug.Log(newPosition);

        // so once we have the newPosition which is the amount the background should move (z displacement) in the
        // z axis then we move the transform
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
