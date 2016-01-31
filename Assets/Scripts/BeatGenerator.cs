using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Timers;

public class BeatGenerator : MonoBehaviour
{

  //  private GameObject prefab;
    public float x;
    public float y;
    public float y2;
    private float timer;
    public float BeatsPerMinute;
    private float secondsPerBeat;
    public AudioSource aud;
    public Multiplyer handler;
    // Use this for initialization
    void Start()
    {
        aud = GetComponent<AudioSource>();

        secondsPerBeat = 60f/BeatsPerMinute;
        timer = 0;
        /*  print("LoadLevel");
//        prefab = Instantiate(Resources.Load("beatBar", typeof(GameObject))) as GameObject;

        TextAsset bindata = Resources.Load("level1") as TextAsset;

        string loadData = bindata.text;

        int counter = 3;

        foreach (char c in loadData)
        {
            switch (c)
            {
                case '1':
                    createSingle(counter);
                    counter++;
                    break;

                case '2':
                    createDouble(counter);
                    counter++;
                    break;

                case '3':
                    createHold(counter);
                    counter++;
                    break;

            }
        }*/
    }


   

    void createSingle(float timer)
    {
        GameObject prefab = Instantiate(Resources.Load("beatBar", typeof(GameObject)), new Vector3(x, y, 0), Quaternion.identity) as GameObject;

        prefab.SendMessage("setSpeed", ( Mathf.Abs(y-y2) / (secondsPerBeat*4 - timer)));
    }


    // Update is called once per frame
    void Update()
    {
        if (aud.isPlaying)
        {
            timer += Time.deltaTime;
            float MissedTime = 0;
            if (timer > secondsPerBeat)
            {
                MissedTime = timer - secondsPerBeat;
                timer = 0;
                createSingle(MissedTime);
            }
        }
        else
        {
            print(" else");
            globalData.setScore(handler.score);
            print("score");
            globalData.setLast(Application.loadedLevelName);
            if (handler.score > 1000)
                Application.LoadLevel("win Screen");
            else
                Application.LoadLevel("lose Screen");
        }

    }
}
