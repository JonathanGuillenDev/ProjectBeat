using UnityEngine;
using System.Collections;

public class beatMove : MonoBehaviour {
    public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
