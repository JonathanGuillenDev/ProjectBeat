using UnityEngine;
using System.Collections.Generic;

public class Drum : MonoBehaviour {
    public Miss miss;
    public bool colision;
    public int drumKey;
    private bool keyDown;
    public KeyCode keybind;
    private List<Collider2D> colliding;
    public Multiplyer multiplyerHandle;

    // Use this for initialization
    void Start () {
        colision = false;
        colliding = new List<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if (Input.GetKey(keybind) && !keyDown)
        {
            keyDown = true;
            if (!colision)
            {
                miss.miss();
            }
            else
            {

                bool hit = false;
                foreach (Collider2D col in colliding)
                {
                    print(col.name);
                    if (col.tag == "beat")
                    {
                        multiplyerHandle.updateSeq(drumKey);
                        hit = true;
                        Destroy(col.gameObject.transform.parent.gameObject);
                    }
                    else if (col.tag == "rest")
                    {
                        miss.miss();
                    }
                }
                if(hit)
                    colliding = new List<Collider2D>();
            }
        }
        if (!Input.GetKey(KeyCode.F))
        {
            keyDown = false;
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        colision = true;
        colliding.Add(col);

    }
    void OnTriggerExit2D(Collider2D col)
    {
        colision = false;
        colliding.Remove(col);
       
    }
  

   
}
