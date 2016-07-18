using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    GameObject currentFocus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()  
    {
        // GH: Pc for now?
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit info = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out info, 100);
            if (hit)
            {
                if (info.transform.gameObject.tag == "Grid")
                {
                    // GH: Initialize the selector thingy?
                    //transform.LookAt(info.transform);
                    currentFocus = info.transform.gameObject;
                    EventManager.ProcessClick();
                }
            }

        }

        if (currentFocus != null)
        {
            Vector3 xzPos = currentFocus.transform.position;
            xzPos.y = transform.position.y;

            transform.position = Vector3.MoveTowards(transform.position, xzPos, 0.3f);

          
        }

    }
}
