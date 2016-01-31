using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Multiplyer : MonoBehaviour
{

    public int multiplyer;
    public int gauge;
    public int score;
    public TextMesh mutliplyerText;
    public TextMesh gaugeText;
    public TextMesh ScoreText;
    private bool[] buttonSeqHit;
    public counter counterhandler;
    public int lastSeq;
    public AudioSource aud;
    public AudioClip AudioGoodMultiUp;
    public AudioClip AudioGoodSeq;
    public AudioClip AudioBad;

    // Use this for initialization
    void Start ()
	{
        aud = GetComponent<AudioSource>();
        buttonSeqHit = new bool[] { false, false, false, false };
        multiplyer = 1;
	    gauge = 0;
	    score = 0;
	    gaugeText.text = gauge.ToString()+ "%";
	    mutliplyerText.text = multiplyer.ToString()+"X";
	    ScoreText.text = ScoreText.ToString();
        lastSeq = 0;

	}
	
	// Update is called once per frame
	void Update () {
        gaugeText.text = gauge.ToString() + "%";
        mutliplyerText.text = multiplyer.ToString() + "X"; ;
	    ScoreText.text = score.ToString();
	}

    void successfulSeq()
    {
        score += 25 * multiplyer;
        gauge = gauge+ 25 - multiplyer+1;

        aud.Stop();
        if (gauge >= 100)
        {
            gauge = 25;
            multiplyer++;
            counterhandler.addRule();
            aud.clip = AudioGoodMultiUp;
        }
        else
        {
            aud.clip = AudioBad;
        }
        aud.Play();
        lastSeq = 0;

    }

    public void miss()
    {

        aud.Stop();
        aud.clip = AudioBad;
        aud.Play();

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
