using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum PanelID
{
    CATEGORY_PANEL = 0,
    ENERGY_PANEL,
    PRODUCTION_PANEL,
    HOUSING_PANEL,
    CONTEXTUAL_PANEL
}

public class SliderController : MonoBehaviour {

   
    public RectTransform[] panels;
    private Animator animController;
    public Button baseBtn;
    JSONObject categoryJSON;

    void Awake()
    {
        animController = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {

        categoryJSON = new JSONObject(Resources.Load<TextAsset>("data/category_data").ToString());
        foreach (JSONObject jo in categoryJSON.GetField("buildings").list)
        {
            RectTransform parent = null;
            
            switch (jo.GetField("owner").str)
            {
               
                case "Energy":                   
                    parent = panels[(int)PanelID.ENERGY_PANEL];
                    break;

                case "Production":
                    parent = panels[(int)PanelID.PRODUCTION_PANEL];
                    break;
                case "Housing":
                    parent = panels[(int)PanelID.HOUSING_PANEL];
                    break;
            }
            foreach (JSONObject jj in jo.GetField("buildings").list)
            {
                Button btn = Instantiate(baseBtn);
                btn.GetComponentInChildren<Text>().text = jj.str;
                btn.transform.SetParent(parent);
            }
        }

           
   
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enterSlider()
    {
        animController.SetTrigger("enter_trigger");
        enablePanel(PanelID.CATEGORY_PANEL);
    }

    public void enablePanel(PanelID id)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].gameObject.SetActive(false);
        }
        panels[(int)id].gameObject.SetActive(true);
    }

    public void enableEnergy()      { enablePanel(PanelID.ENERGY_PANEL);  }
    public void enableProduction()  { enablePanel(PanelID.PRODUCTION_PANEL); }
    public void enableHousing()     { enablePanel(PanelID.HOUSING_PANEL); }
    public void enableContextual()  { enablePanel(PanelID.CONTEXTUAL_PANEL); }

}
