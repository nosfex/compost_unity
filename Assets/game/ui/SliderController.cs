using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour {


    private Animator animController;
    void Awake()
    {
        animController = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enterSlider()
    {
        //GetComponent<Animator>().Play("on_enter_slider");
        animController.SetTrigger("enter_trigger");
    }


}
