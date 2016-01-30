using UnityEngine;
using System.Collections;

public class Drum4 : MonoBehaviour {
    public Miss miss;
    public bool colision;
	// Use this for initialization
	void Start () {
        colision = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!colision&&Input.GetKeyDown(KeyCode.J))
            miss.miss();
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        colision = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        colision = false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "beat" && Input.GetButtonDown("Jump"))
        {
            Destroy(col.gameObject.transform.parent.gameObject);
          
            Destroy(GameObject.Find("New Game Object"));
            
        }
            if (col.tag == "rest" && Input.GetKeyDown(KeyCode.J))
                miss.miss();
    }
    
}
