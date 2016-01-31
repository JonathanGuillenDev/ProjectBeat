using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Multiplyer : MonoBehaviour
{
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
	    gauge = 0;
	    score = 0;
	    gaugeText.text = gauge.ToString()+ "%";
	    mutliplyerText.text = counterhandler.getRuleCount().ToString()+"X";
	    ScoreText.text = ScoreText.ToString();
        lastSeq = 0;

	}
	
	// Update is called once per frame
	void Update () {
        gaugeText.text = gauge.ToString() + "%";
        mutliplyerText.text = counterhandler.getRuleCount().ToString() + "x"; ;
	    ScoreText.text = score.ToString();
	}

    void successfulSeq()
    {
        score += 25 * counterhandler.getRuleCount();
        gauge = gauge+ 25 - counterhandler.getRuleCount() + 1;

        aud.Stop();
        if (gauge >= 100)
        {
            gauge = 25;
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
        if (counterhandler.getRuleCount() < 1)
        {
            counterhandler.addRule();
        }
    }

    private void degradeGauge()
    {
        if (counterhandler.getRuleCount() > 1)
        {
            gauge -= counterhandler.getRuleCount();
            if (gauge < 0)
            {
                miss();
                gauge = 100 - counterhandler.getRuleCount();
            }
        }
    }

    public void updateSeq(int button)
    {
        score += 15* counterhandler.getRuleCount();

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
