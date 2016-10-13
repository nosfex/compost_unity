using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Building : MonoBehaviour
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

    public bool lockTile;
    public int buildingMaxHealth;

    private bool powered = false;

    public void setData(BuildingData data)
    {
        #region strings
        this.area           = data.area;
        this.name           = data.name;
        this.description    = data.description;
        this.productionType = data.productionType;
        #endregion

        #region ints
        this.maxManPower    = data.maxManPower;
        this.price          = data.price;
        this.techLevel      = data.techLevel;
        this.maxProduction  = data.maxProduction;
        this.productionRate = data.productionRate;
        #endregion

        #region booleans
        this.requiresManPower   = data.requiresManPower;
        this.requiresPower      = data.requiresPower;
        #endregion

        #region arrays
        this.currency   = data.currency;
        this.upkeepCost = data.upkeepCost;
        this.functions  = data.functions;
        #endregion
    }
    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () { }
}
