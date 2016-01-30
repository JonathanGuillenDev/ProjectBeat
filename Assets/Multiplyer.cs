using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Multiplyer : MonoBehaviour
{

    public int multiplyer;
    public int gauge;
    public Text mutliplyerText;
    public Text gaugeText;
    private bool[] buttonSeqHit;

	// Use this for initialization
	void Start ()
	{
        buttonSeqHit = new bool[] { false, false, false, false };
        multiplyer = 1;
	    gauge = 0;
	    gaugeText.text = gauge.ToString();
	    mutliplyerText.text = multiplyer.ToString();

	}
	
	// Update is called once per frame
	void Update () {
        gaugeText.text = gauge.ToString();
        mutliplyerText.text = multiplyer.ToString();
    }

    void successfulSeq()
    {
        gauge = gauge+ 25 - multiplyer;
        if (gauge > 100)
        {
            gauge = 0;
            multiplyer++;
        }
    }

    public void updateSeq(int button)
    {
        buttonSeqHit[button - 1] = true;

        if(buttonSeqHit[0] &&
            buttonSeqHit[1] &&
            buttonSeqHit[2] &&
            buttonSeqHit[3])
            buttonSeqHit= new bool[] {false, false, false, false};
    }
}
