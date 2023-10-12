using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DiamondScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Dropdown options;
    private TMPro.TMP_Dropdown options2;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        options = GameObject.FindWithTag("Options").GetComponent<Dropdown>();
        options.value = 2;
        //GameObject.FindWithTag("Options").SetActive(false);
        options.gameObject.SetActive(false);

        Debug.Log("awake in diamond..");
        options2 = GameObject.FindWithTag("Jewels").GetComponent<TMPro.TMP_Dropdown>();
        options2.value = 1;
        //options.Show();
        //options.Hide();
        //options2.Hide();

    }
    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
        options.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("start in Diamond..");
        //options2.enabled = false;
        //options2.Show();
    }

    int count = 0;
    // Update is called once per frame
    void Update()
    {
        count++;
        if (count ==1000)
        {
            sr.enabled = true;
            //GameObject.FindWithTag("PlayerTag").GetComponent<SpriteRenderer>().enabled = true;
            //options.Hide();
            //GameObject.Instantiate(options);
            options.gameObject.SetActive(true);
            //options.Show();
        }
    }
}
