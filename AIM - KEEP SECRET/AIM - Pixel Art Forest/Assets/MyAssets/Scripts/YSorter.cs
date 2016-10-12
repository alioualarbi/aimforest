using UnityEngine;
using System.Collections;

public class YSorter : MonoBehaviour {

	SpriteRenderer renderer;
	Transform player;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.y < transform.position.y)
			renderer.sortingLayerName = "Default";
		else
			renderer.sortingLayerName = "In Front";
	}
}
