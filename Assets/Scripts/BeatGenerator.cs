using UnityEngine;
using System.Collections;
using System.Timers;

public class BeatGenerator : MonoBehaviour
{

  //  private GameObject prefab;
    public float y;
    public float y2;
    private float timer;
    public float BeatsPerMinute;
    private float secondsPerBeat;
    // Use this for initialization
    void Start()
    {
       
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
        GameObject prefab = Instantiate(Resources.Load("beatBar", typeof(GameObject)), new Vector3(-1.9f, y, 0), Quaternion.identity) as GameObject;

        prefab.SendMessage("setSpeed", ( Mathf.Abs(y-y2) / (secondsPerBeat*4 - timer)));
    }


    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        float MissedTime = 0;
        if (timer > secondsPerBeat)
        {
            MissedTime = timer - secondsPerBeat;
            timer = 0;
            createSingle(MissedTime);
        }
    }
}
