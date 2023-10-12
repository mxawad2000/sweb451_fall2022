using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    Dropdown options;
    Text optCounter;
    InputField energyField ;
    Button energyButton;
    int count2 = 0;
    bool playFlag = false;
    int energyLevel = 10;
    private void Awake()
    {
        //retrieve reference to the Dropdown UI element.
        options = GameObject.FindGameObjectWithTag("Options").GetComponent<Dropdown>();
        optCounter = GameObject.FindGameObjectWithTag("OptionsCounter").GetComponent<Text>();
        energyField = GameObject.FindGameObjectWithTag("EnergyLevel").GetComponent<InputField>();
        energyField.gameObject.SetActive(false);
        //if (GameObject.Find("EnergyButton") == null) Debug.Log("NULL");
        //energyButton = GameObject.Find("EnergyButton").GetComponent<Button>();
        
    }
    public void onClick()
    {
        count2++;
        GameObject gObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string name = gObj.name;
        if (name == "PlayAudioButton")
        {
            Button b = gObj.GetComponent<Button>();
            playFlag = !playFlag;
            if (playFlag) b.GetComponent<AudioSource>().Play();
            else b.GetComponent<AudioSource>().Stop();
        }
        if(count2 %2 == 0)
        {
            if (!options.IsActive()) options.gameObject.SetActive(true);
        }
    }
    public void onClick(Button b)
    {
        energyField.gameObject.SetActive(true);
        if (this.energyButton == null) energyButton = b;
    }
    int count = 1;
    public void onItemSelected(Dropdown myList)
    {
        count++;
        GameObject gObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string name = gObj.name;
        Debug.Log("item clicked:" + myList.options[myList.value].text);
        if (count == 3) myList.gameObject.SetActive(false);
        this.optCounter.text = "Options Counter:" + count;
        myList.RefreshShownValue();
    }

    public void HandleInputField(InputField field)
    {
       
        field.gameObject.SetActive(false);
        if(int.TryParse(field.text,out energyLevel))
        {
            this.energyButton.GetComponentInChildren<Text>().text = "Energy Level:" + field.text;
        }
    }
    public void HandleToggleField(Toggle field)
    {
        if (field.isOn) energyLevel *= 2;
        else energyLevel /= 2;
        this.energyButton.GetComponentInChildren<Text>().text = "Energy Level:" + energyLevel;

    }
    // Start is called before the first frame update
    void Start()
    {
        //options.RefreshShownValue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
