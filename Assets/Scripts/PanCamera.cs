using UnityEngine;
using System.Collections;

public class PanCamera : MonoBehaviour {
    public int speed;
    private bool go;
    public Transform bound;
	// Use this for initialization
	void Start () {
        go = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        if(transform.position.x>bound.position.x)
        {
            go = false;
            if (Application.loadedLevelName.Equals("opening"))
                Application.LoadLevel("titlepage");
            if (globalData.getLast().Equals("titlepage"))
                Application.LoadLevel("tutorialStage");
            else if (globalData.getLast().Equals("tutorialStage"))
                Application.LoadLevel("challangeStage");
            else
                Application.LoadLevel("titlepage");
        }
        if(Input.GetKey(KeyCode.Return))
        {
            if (Application.loadedLevelName.Equals("opening"))
                Application.LoadLevel("titlepage");
            if (globalData.getLast().Equals("titlepage"))
                Application.LoadLevel("tutorialStage");
            else if (globalData.getLast().Equals("tutorialStage"))
                Application.LoadLevel("challangeStage");
            else
                Application.LoadLevel("titlepage");
        }
	
	}
    
}
