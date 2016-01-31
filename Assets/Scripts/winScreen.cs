using UnityEngine;
using System.Collections;

public class winScreen : MonoBehaviour {

    // Use this for initialization
    public Sprite alt;
	void Start () {
	    if(globalData.getPath()==2)
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.sprite = alt;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Return))
        {
            if(globalData.getPath()==0)
            {
                if (globalData.getLast().Equals("tutorialStage"))
                { Application.LoadLevel(7); }  //load cutscenes
                else if(globalData.getLast().Equals("challangeStage"))
                {
                    Application.LoadLevel("credits");
                }
            }
            else
                Application.LoadLevel(1);
        }
	}
}
