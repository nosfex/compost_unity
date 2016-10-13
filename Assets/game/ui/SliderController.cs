using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public enum PanelID
{
    CATEGORY_PANEL = 0,
    ENERGY_PANEL,
    PRODUCTION_PANEL,
    HOUSING_PANEL,
    CONTEXTUAL_PANEL
}

public class SliderController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  {

   
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
                btn.onClick.AddListener( () => { addBuilding(btn.GetComponentInChildren<Text>().text); }  );
                btn.transform.SetParent(parent);
            }
        }      
    }

    // GH: Just add a building to the currently selected grid
    public void addBuilding(string buildingName)
    {
        GameManager.instance.Builder.addBuilding(buildingName);
    }
    
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        // GH: Lock the ui
        EventManager.ProcessLockCam(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // GH: Unlock the ui
        EventManager.ProcessLockCam(false);
    }
    // Update is called once per frame
    void Update () {
	
	}

    public void showSlider(bool show)
    {
        if (show)
        {   
            animController.SetTrigger("enter_trigger");
            enablePanel(PanelID.CATEGORY_PANEL);
        }
        else
        {
            animController.SetTrigger("exit_trigger");
            animController.ResetTrigger("enter_trigger");
            enablePanel(PanelID.CATEGORY_PANEL);
        }
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
