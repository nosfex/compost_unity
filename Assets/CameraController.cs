using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject currentFocus;

    float height = 30;
    private float heightRate = 10;

    public float BoundaryX = 0.1f;
    public float BoundaryY = 0.1f;
    
    float screenWidth = 0;
    float screenHeight = 0;


    GameObject previousSelected = null;
    // GH: Temp until I do mouse collision with the slider
    bool locked = false;
    // Use this for initialization
    void Start () {
        screenHeight = Screen.height;
        screenWidth = Screen.width;

	}

    // Update is called once per frame
    void Update()
    {
        // GH: Pc for now?
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit info = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out info, 100);
            if (hit)
            {

                if (previousSelected != null)
                {
                    previousSelected.transform.parent.GetComponent<Grid>().Selected = false;
                }
                GameObject grid = info.transform.gameObject;
                if (grid.tag == "Grid")
                {
                    // GH: Initialize the selector thingy?
                    previousSelected = currentFocus = grid;
                    grid.transform.parent.GetComponent<Grid>().Selected = true;
                    EventManager.ProcessClick();
                    locked = true;
                }
            }
            else
            {
                locked = false;

                if (previousSelected != null)
                {
                    previousSelected.transform.parent.GetComponent<Grid>().Selected = false;
                }
                if (currentFocus != null)
                {
                    currentFocus.transform.parent.GetComponent<Grid>().Selected = false;
                }

            }
        }
#endif

            if (currentFocus != null)
            {
                Vector3 xzPos = currentFocus.transform.position;
                xzPos.y = transform.position.y;

                transform.position = Vector3.MoveTowards(transform.position, xzPos, 0.3f);
                if (transform.position == xzPos)
                {
                    currentFocus = null;
                }
            }
            else
            {
                if (locked == false)
                {
#if UNITY_EDITOR
                    if (Input.mousePosition.x > screenWidth * (1.0f - BoundaryX))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 20 * Time.deltaTime, transform.position.y, transform.position.z), 0.3f);
                    }

                    if (Input.mousePosition.x < screenWidth * (BoundaryX))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 20 * Time.deltaTime, transform.position.y, transform.position.z), 0.3f);
                    }

                    if (Input.mousePosition.y > screenHeight * (1.0f - BoundaryY))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20 * Time.deltaTime), 0.3f);
                    }

                    if (Input.mousePosition.y < screenHeight * (BoundaryY))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 20 * Time.deltaTime), 0.3f);
                    }
#endif
                }
            }



#if UNITY_EDITOR
            float deltaHeight = 0;
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                height -= Input.GetAxis("Mouse ScrollWheel") * heightRate;
            }

            deltaHeight = 0 + height;

            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, deltaHeight, Time.deltaTime), transform.position.z);
#endif

        
    }
}
