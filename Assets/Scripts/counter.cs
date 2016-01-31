using UnityEngine;
using System.Collections.Generic;

public class counter : MonoBehaviour {
    public int count;
    public Rules rules;
    public Sprite g;
    public Sprite r;
    public Sprite b;
    public Sprite y;

    // Use this for initialization
    void Start () {
        count = 1;
        rules = new Rules();
        rules.addRule();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    int spotToInt(string name)
    {
        switch (name)
        {
            case "spot1":
                return 1;
            case "spot2":
                return 2;
            case "spot3":
                return 3;
            case "spot4":
                return 4;
            default:
                return 0;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "spot1")
        {
            count++;
            //if (count % 2 == 0)
              //  rules.addRule();
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "beat" || col.tag == "beatStart" || col.tag == "beatDouble")
        {
            
            if (rules.getRulesForBeat(spotToInt(col.name), count))
            {
                addRest(col.name,col.transform.parent.gameObject);
            }
        }
       
    }
    void addRest(string name, GameObject parent)
    {
       
         
        GameObject spot = parent.transform.FindChild(name).gameObject;
        spot.tag = "rests";
        if(spot.transform.parent.FindChild("spot1").tag=="rests"&& spot.transform.parent.FindChild("spot2").tag == "rests" && spot.transform.parent.FindChild("spot3").tag == "rests" && spot.transform.parent.FindChild("spot4").tag == "rests")
        {
            spot.transform.parent.FindChild("spot1").tag = "beat";
            spot.transform.parent.FindChild("spot2").tag = "beat";
            spot.transform.parent.FindChild("spot3").tag = "beat";
            spot.transform.parent.FindChild("spot4").tag = "beat";

        }
        SpriteRenderer rend = spot.GetComponent<SpriteRenderer>();
        if (name == "spot1")
            rend.sprite = g;
        else if (name == "spot2")
            rend.sprite = r;
        else if (name == "spot3")
            rend.sprite = b;
        else if (name == "spot4")
            rend.sprite = y;
                   
            
    }

    public void addRule()
    {
        rules.addRule();
    }

    public void removeRule()
    {
        rules.removeRule();
    }

    public class Rules
    {
        public static int maxLimit = 16;
        Stack<Rule> rules;

        public Rules()
        {
            rules = new Stack<Rule>();
        }

        public bool addRule()
        {

            Rule newRule = new Rule(8);
            int count = 1;

            while (rules.Contains(newRule) && count < maxLimit)
            {
                newRule = new Rule(8);
                count++;
            }

            if (rules.Contains(newRule))
            {
                return false;
            }
            rules.Push(newRule);
            return true;
        }

        public Rule removeRule()
        {
            return rules.Pop();
        }

        public bool getRulesForBeat(int button, int beatNum)
        {
           // print(beatNum.ToString());
          //  print("BEAT:" +beatNum.ToString() + "Cout:" +countRulesForBeat(button, beatNum).ToString());
            return countRulesForBeat(button, beatNum) > 0;
        }

        private int countRulesForBeat(int button, int beatNum)
        {
            int count = 0;
            foreach (var x in rules)
            {
                if ((beatNum % x.hitSpace == 0) && button == x.button) count++;
            }
            return count;
        }
    }


    public class Rule
    {

        public int button { get; set; }
        public int hitSpace { get; set; }

        public Rule(int b, int h)
        {
            button = b;
            hitSpace = h;
        }

        public Rule(int beat)
        {

            button = Random.Range(1, 5);
            hitSpace = Random.Range(3, beat + 1);
        }

        public override bool Equals(object obj)
        {
            if (typeof(Rule) == obj.GetType())
            {
                Rule temp = (Rule)obj;

                return (button == temp.button && hitSpace == temp.button);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return button + hitSpace * 10;
        }

    }
}
