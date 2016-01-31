using UnityEngine;
using System.Collections.Generic;
using System.Net;

public class Tutorial : MonoBehaviour
{


    public counter counterHandler;
    public speaker Sensei;
    public speaker punk;
    public string[] dialog ;
	// Use this for initialization
	void Start () {
        dialog = new string[6];
   
        dialog[0] = "Let not time slip by\n a heart beat \nshould not be skipped";
        dialog[1] = "Hit something on each beat.";
        dialog[2] = "A Sequence of four\n you will complete\n to exite the spirit\n and enlighten one self";
        dialog[3] = "Once I've hit each of\n the four I'll be better?";
        dialog[4] = "Careful not to hit \n the note \n of unharmouniousnes.";
        dialog[5] = "No hitting the X, Got it";

    }





    // Update is called once per frame
    void Update ()
    {

        int count = counterHandler.count;
        if (counterHandler.count >= 56)
        {
            Sensei.setDisabled(); 
            punk.setDisabled(); 

        }
        else
        { 
            
            if (count%8 == 0)
            {
                if (count%16 == 0)
                {

                    punk.setSpeech(dialog[(count/8) - 1]);
                }
                else
                { 
                    Sensei.setSpeech(dialog[(count/8) - 1]);
                    punk.setSpeech("");
                }
            }
        }
    }

}
