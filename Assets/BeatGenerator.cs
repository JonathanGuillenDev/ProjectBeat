using UnityEngine;
using System.Collections;

public class BeatGenerator : MonoBehaviour
{

  //  private GameObject prefab;
    public float distance;
    // Use this for initialization
    void Start()
    {

        print("LoadLevel");
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
        }
    }


    void createHold(int count)
    {
     //   print("HOLD" + ((float)count * distance).ToString());
    }

    void createDouble(int count)
    {
        print("DOUBLE" + ((float)count * distance).ToString());
    }

    void createSingle(int count)
    {
        print("SINGLE" + ((float)count * distance).ToString());

        GameObject prefab = Instantiate(Resources.Load("beatBar", typeof(GameObject)), new Vector3(-2, count * distance, 0), Quaternion.identity) as GameObject;
        //Instantiate(prefab, new Vector3(-2, count * distance, 0), Quaternion.identity);


    }


    // Update is called once per frame
    void Update()
    {

    }
}
