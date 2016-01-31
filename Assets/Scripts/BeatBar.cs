using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class BeatBar : MonoBehaviour
{
    public float speed;
    public AudioSource aud;
    // Use this for initialization
    void Start () {
       
    }

    void setSpeed(float s)
    {
        speed = s;
    }

    // Update is called once per frame
    void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

}
