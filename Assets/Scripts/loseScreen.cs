using UnityEngine;
using System.Collections;

public class loseScreen : MonoBehaviour {
    public SpriteRenderer ret;
    public SpriteRenderer menu;
	// Use this for initialization
	void Start () {
        menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            ret.enabled = !ret.enabled;
            menu.enabled = !menu.enabled;
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(ret.enabled)
            {
                Application.LoadLevel(globalData.getLast());
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
	}
}
