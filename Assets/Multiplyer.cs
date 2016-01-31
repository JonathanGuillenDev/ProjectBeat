using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Multiplyer : MonoBehaviour
{

    public int multiplyer;
    public int gauge;
    public int score;
    public Text mutliplyerText;
    public Text gaugeText;
    public Text ScoreText;
    private bool[] buttonSeqHit;
    public counter counterhandler;
    public int lastSeq;

    // Use this for initialization
	void Start ()
	{
        buttonSeqHit = new bool[] { false, false, false, false };
        multiplyer = 1;
	    gauge = 0;
	    score = 0;
	    gaugeText.text = gauge.ToString();
	    mutliplyerText.text = multiplyer.ToString();
	    ScoreText.text = ScoreText.ToString();
        lastSeq = 0;

	}
	
	// Update is called once per frame
	void Update () {
        gaugeText.text = gauge.ToString();
        mutliplyerText.text = multiplyer.ToString();
	    ScoreText.text = score.ToString();
	}

    void successfulSeq()
    {
        score += 25 * multiplyer;

        gauge = gauge+ 25 - multiplyer+1;
        if (gauge >= 100)
        {
            gauge = 25;
            multiplyer++;
            counterhandler.addRule();
        }
        lastSeq = 0;
    }

    public void miss()
    {
        counterhandler.removeRule();
        multiplyer --;
        if (multiplyer <= 1)
        {
            multiplyer = 1;
            counterhandler.addRule();
        }
    }

    private void degradeGauge()
    {
        if (multiplyer > 1)
        {
            gauge -= multiplyer;
            if (gauge < 0)
            {
                miss();
                gauge = 100 - multiplyer;
            }
        }
    }

    public void updateSeq(int button)
    {
        score += 15*multiplyer;

        buttonSeqHit[button - 1] = true;
        lastSeq++;
        if (buttonSeqHit[0] &&
            buttonSeqHit[1] &&
            buttonSeqHit[2] &&
            buttonSeqHit[3])
        {
            buttonSeqHit = new bool[] { false, false, false, false };
            successfulSeq();
        }

        if (lastSeq < 4)
        {
            degradeGauge();
        }
            

    }
}
