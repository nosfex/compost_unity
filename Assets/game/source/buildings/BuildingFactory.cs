using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingData
{
    public string description;
    public string[] currency;
    public string[] functions;
    public int[] upkeepCost;
    public bool requiresPower = false;
    public bool requiresManPower = false;
    public int maxManPower = 0;
    public int price = 0;
    public string area = "N4";
    public int techLevel = 0;
    public string productionType;
    public int productionRate = 1;
    public int maxProduction = 1000;
    public string name;
    public bool lockTile;
    public int buildingMaxHealth;
}

public class BuildingFactory : MonoBehaviour
{

    public List<Building> buildingsRef;
    Dictionary<string, BuildingData> buildings = new Dictionary<string, BuildingData>();
	// Use this for initialization
	void Start ()
    {
        // GH: Parse our building data, and store it in our dict for further usage
        JSONObject buildingsJSON = new JSONObject(Resources.Load<TextAsset>("data/buildings_data").ToString());
        foreach (JSONObject jo in buildingsJSON.GetField("buildings").list)
        {
            BuildingData bd = new BuildingData();
            #region strings

            bd.description      = jo.GetField("description").str;
            bd.name             = jo.GetField("name").str;
            bd.area             = jo.GetField("area").str;
            bd.productionType   = jo.GetField("productionType").str;

            #endregion

            #region ints
            bd.maxManPower          = (int)jo.GetField("maxManPower").i;
            bd.price                = (int)jo.GetField("price").i;
            bd.techLevel            = (int)jo.GetField("techLevel").i;
            bd.productionRate       = (int)jo.GetField("productionRate").i;
            bd.maxProduction        = (int)jo.GetField("maxProduction").i;
            bd.buildingMaxHealth    = (int)jo.GetField("buildingMaxHealth").i;
            #endregion

            #region arrays
            bd.currency = new string[jo.GetField("currency").list.Count];
            int idx = 0;
            foreach (JSONObject jj in jo.GetField("currency").list)
            {
                bd.currency[idx++] = jj.str;
            }

            idx = 0;

            bd.upkeepCost = new int[jo.GetField("upkeepCost").list.Count];
            foreach (JSONObject jj in jo.GetField("upkeepCost").list)
            {
                bd.upkeepCost[idx++] = (int)jj.i;
            }

            idx = 0;
            bd.functions = new string[jo.GetField("functions").list.Count];
            foreach (JSONObject jj in jo.GetField("functions").list)
            {
                bd.functions[idx++] = jj.str;
            }
            #endregion

            #region booleans
            bd.requiresManPower     = jo.GetField("requiresManPower").b;
            bd.lockTile             = jo.GetField("lockTile").b;
            bd.requiresPower        = jo.GetField("requiresPower").b;
            #endregion

            buildings.Add(bd.name, bd);

        }
	}

    public Building addBuilding(string name)
    {
        Debug.Log(buildings[name]);
        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
