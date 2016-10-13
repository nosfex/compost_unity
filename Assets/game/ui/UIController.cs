using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public SliderController slider;
    // Use this for initialization
    void Start()
    {
        EventManager.OnClicked += slider.showSlider;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
