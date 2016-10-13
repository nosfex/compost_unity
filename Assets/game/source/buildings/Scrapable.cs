using UnityEngine;
using System.Collections;

public class Scrapable : MonoBehaviour {


    Building building;
	// Use this for initialization
	void Start ()
    {
        building = this.transform.gameObject.GetComponent<Building>();
	}

    public void scrap()
    {
        GameManager.instance.Gold += building.price / 10;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
