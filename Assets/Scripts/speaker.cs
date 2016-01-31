using UnityEngine;
using System.Collections;

public class speaker : MonoBehaviour
{

    // Use this for initialization

    public TextMesh speech;
    public objectGame dialogBubble;
    void Start()
    {
        speech.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSpeech(string talk)
    {
        speech.text = talk;
        speech.gameObject.SetActive(talk!="");
        dialogBubble.gameObject.SetActive(talk != "");

    }
    public void setDisabled()
    {
        gameObject.SetActive(false);
    }

}
