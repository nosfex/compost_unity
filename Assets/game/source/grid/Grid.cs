using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {


    private bool powerable = false;
    private bool powered = false;
    private bool selected = false;

    public bool Powered
    {
        get { return powered; }
        set { powered = value; }
    }

    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }

    public static int NORMAL    = 0x00;
    public static int WATER     = 0x01;
    public static int MINERAL   = 0x02;

    private int type = NORMAL;


    void Awake()
    {
        this.GetComponentInChildren<Renderer>().material = Resources.Load<Material>("materials/grid/grid_diffuse");
    }
    // Use this for initialization
    void Start () {

        
      
	}
	
	// Update is called once per frame
	void Update ()
    {
     
	}
}
