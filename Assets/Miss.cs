using UnityEngine;
using System.Collections;

public class Miss : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "beat")
            miss();
    }
    public void miss()
    {
        print("miss");
    }
}
