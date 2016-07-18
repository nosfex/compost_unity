﻿using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    public static void ProcessClick()
    {
        OnClicked();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
