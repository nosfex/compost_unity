using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField]
    private BuildingFactory _builder;

    [SerializeField]
    private WorldClock _clock;

    public BuildingFactory Builder
    {
        get { return _builder; }
    }
    
    private int _gold = 100;
    void Awake()
    {       
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
	}

    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    void Start()
    {
        _builder = Instantiate<BuildingFactory>(_builder);
        _builder.transform.position = Vector3.zero;
        _builder.transform.SetParent(transform);
    }
	// Update is called once per frame
	void Update () { }
}
