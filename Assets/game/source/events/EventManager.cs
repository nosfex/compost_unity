using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void ClickAction(bool clickedOnObject);
    public delegate void AddGridsAction(Grid selectedGrid);

    public static event ClickAction OnClicked;
    public static event AddGridsAction OnGridsAdded;

    public delegate void LockCamAction(bool lockCam);

    public static event LockCamAction OnLockCam;
    
    public static void ProcessClick(bool clickedOnObject)
    {
        OnClicked(clickedOnObject);
    }

    public static void ProcessGridAdd(Grid selectedGrid)
    {
        OnGridsAdded(selectedGrid);
    }


    public static void ProcessLockCam(bool lockCam)
    {
        OnLockCam(lockCam);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
