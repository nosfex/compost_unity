using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {


    private Building building;
    // GH: Can the tile be powered?
    private bool powerable = false;
    private bool powered = false;
    // GH: Is the tile selected?
    private bool selected = false;

    public Building Building
    {
        get { return building;  }
        set { building = value;  }
    }

    public bool Powered
    {
        get { return powered; }
        set { powered = value; }
    }

    public bool Selected
    {
        get { return selected; }
        set
        {
            selected = value;
            if (selected)
            {
                render.material = Resources.Load<Material>("materials/grid/grid_outline");
            }
            else
            {
                render.material = Resources.Load<Material>("materials/grid/grid_diffuse");
            }
        }
    }

    // GH: Tile type
    public static int NORMAL    = 0x00;
    public static int WATER     = 0x01;
    public static int MINERAL   = 0x02;

    private int type = NORMAL;

    private Renderer render;

    void Awake()
    {

        render = this.GetComponentInChildren<Renderer>();
        render.material = Resources.Load<Material>("materials/grid/grid_diffuse");
    }
    // Use this for initialization
    void Start () {

        
      
	}
	
	// Update is called once per frame
	void Update ()
    {
     
	}
}
