using UnityEngine;
using System.Collections.Generic;

public class Miss : MonoBehaviour
{

    public Multiplyer multiplyerHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.tag == "beat")
        {
            bool ParentHidden = false;
            Renderer[] something = col.transform.parent.GetComponents<Renderer>();
            for (int i = 0; i < something.Length; i++)
            {
                ParentHidden = !something[i].enabled;
            }

            if (!ParentHidden)
            {
                multiplyerHandler.miss();
            }
        }
            
                
           
        
    }
}
