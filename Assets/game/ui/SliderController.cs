using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour {

    void Awake()
    {
        GetComponent<Animator>().Stop();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enterSlider()
    {

        GetComponent<Animator>().Play("on_enter_slider");
    }


}
