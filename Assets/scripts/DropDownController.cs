using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour
{
    TMP_Dropdown DropList;
    // Start is called before the first frame update
    void Start()
    {
        DropList = GetComponent<TMP_Dropdown>();
        DropList.ClearOptions();
        //add item..
        List<string> items = new List<string>();
        items.Add("Test1"); items.Add("Lab3Scene"); items.Add("Lab4Scene");
        DropList.AddOptions(items);
        DropList.onValueChanged.AddListener(delegate { DropItemSelected(DropList); });
        //DropItemSelected(DropList);
    }

    void DropItemSelected(TMP_Dropdown DL)
    {
        int index = DL.value;
        Debug.Log("item selected:" + DL.options[index].text);
        SceneManager.LoadScene(DL.options[index].text);
        
    }
}
