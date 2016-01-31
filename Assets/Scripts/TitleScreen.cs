using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
    public Sprite mark;
    public SpriteRenderer story;
    public SpriteRenderer tut;
    public SpriteRenderer chal;
    public SpriteRenderer ex;
    private int counter;
    private SpriteRenderer[] list;
	// Use this for initialization
	void Start () {
        tut.enabled = false;
        chal.enabled = false;
        ex.enabled = false;
        counter = 0;
        list = new SpriteRenderer[]{story,tut,chal,ex};

	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.DownArrow)&& counter<3)
        {
            list[counter].enabled = false;
            counter++;
            list[counter].enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&&counter>0)
            {
            list[counter].enabled = false;
            counter--;
            list[counter].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            globalData.setPath(counter);
            globalData.setLast(Application.loadedLevelName);
            if (counter == 0)
            {
                Application.LoadLevel(6);
            }
            if (counter == 1)
            {
                Application.LoadLevel(2);
            }
            if (counter == 2)
            {
                Application.LoadLevel(3);
            }
                //load challenge mode
            if (counter == 3)
                Application.Quit();
        }

    }
}
