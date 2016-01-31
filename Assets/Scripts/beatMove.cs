using UnityEngine;
using System.Collections;

public class beatMove : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
