using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Drum : MonoBehaviour {
    public bool colision;
    public int drumKey;
    public bool keyDown;
    public KeyCode keybind;
    private Stack<Collider2D> colliding;
    public Multiplyer multiplyerHandle;
    public AudioSource aud;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    private AudioClip[] clips;
    private bool waitForEnd;
    private bool doubleTap;
    private Vector3 pos;

    // Use this for initialization
    void Start () {
        colision = false;
        colliding = new Stack<Collider2D>();
        keyDown = false;
        aud = GetComponent<AudioSource>();
        clips = new AudioClip[]{ clip1, clip2, clip3, clip4 };
        waitForEnd = false;
        doubleTap = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        bool getKeyr = Input.GetKey(keybind);
        if (getKeyr && !keyDown)
        { 
            keyDown = true;
            if (!colision && !waitForEnd)
            {
                multiplyerHandle.miss();
            }
            else
            {
                foreach (Collider2D col in colliding)
                {

                    if (col.tag == "beatStart")
                    {
                        switchClip();
                        aud.Play();
                    }
             
                    /*|| (drumKey == 1 && col.tag == "spacer")*/
                    if (col.tag == "beat" )
                    {

                        multiplyerHandle.updateSeq(drumKey);
                        switchClip();
                        aud.Play();
                       
                        Renderer[] something = col.transform.parent.GetComponents<Renderer>();
                        for (int i = 0; i < something.Length; i++)
                        {
                            something[i].enabled = false;
                        }
                    }
                    else if (col.tag == "rests")
                    {
                        multiplyerHandle.miss();

                        Renderer[] something = col.transform.parent.GetComponents<Renderer>();
                        for (int i = 0; i < something.Length; i++)
                        {
                            something[i].enabled = false;
                        }
                    }
                }
               
            }
        }
        if (!getKeyr)
        {
            keyDown = false;
        }
        if (keyDown)
        {
            transform.Translate(new Vector3(0,-.02f,0),Space.World);
        }
        else
        {
            if (!pos.Equals(transform.position))
            {
                transform.position = pos;
            }
        }
    }
    void switchClip()
    {
        aud.Stop();
        aud.clip = clips[Random.Range(0, clips.Length-1)];
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        colision = true;
        colliding.Push(col);

    }
    void OnTriggerExit2D(Collider2D col)
    {
        colision = false;
        if (col.tag == "BeatEnd" && waitForEnd)
        {

            multiplyerHandle.miss();
        }
        colliding.Pop();
       
    }
  

   
}
