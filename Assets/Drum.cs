using UnityEngine;
using System.Collections.Generic;

 class Drum : MonoBehaviour {
    public Multiplyer multiplyerHandler;
    public bool colision;
    public int drumKey;
    public bool keyDown;
    public KeyCode keybind;
    private Stack<Collider2D> colliding;
    public Multiplyer multiplyerHandle;

    // Use this for initialization
    void Start () {
        colision = false;
        colliding = new Stack<Collider2D>();
        keyDown = false;
        print(drumKey);
    }

    // Update is called once per frame
    void Update ()
    {
        bool getKeyr = Input.GetKey(keybind);
        if (getKeyr && !keyDown)
        { 
            keyDown = true;
            if (!colision)
            {
                multiplyerHandler.miss();
            }
            else
            {

               
                foreach (Collider2D col in colliding)
                {
                    if (col.tag == "beat")
                    {
                        multiplyerHandle.updateSeq(drumKey);
                      
                        Renderer[] something = col.transform.parent.GetComponents<Renderer>();
                        for (int i = 0; i < something.Length; i++)
                        {
                            something[i].enabled = false;
                        }

                    }
                    else if (col.tag == "rest")
                    {
                        multiplyerHandler.miss();
                    }
                }
               
            }
        }
        if (!getKeyr)
        {
            keyDown = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        colision = true;
        colliding.Push(col);

    }
    void OnTriggerExit2D(Collider2D col)
    {
        colision = false;
        colliding.Pop();
       
    }
  

   
}
