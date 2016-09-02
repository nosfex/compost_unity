using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void ClickAction();

    public delegate void AddGridsAction(Grid selectedGrid);
    public static event ClickAction OnClicked;
    public static event AddGridsAction OnGridsAdded;

    public static void ProcessClick()
    {
        OnClicked();
    }

    public static void ProcessGridAdd(Grid selectedGrid)
    {
        OnGridsAdded(selectedGrid);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
