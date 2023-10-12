using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayAudioController : MonoBehaviour
{
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(PlayAudio);
    }
    bool isPlay = false;
    void PlayAudio()
    {
        isPlay = !isPlay;
        AudioSource clip = myButton.GetComponent<AudioSource>();
        if (isPlay) clip.Play();
        else clip.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int count = 0;
    // Update is called once per frame
    void Update()
    {
        count++;
        if (count == 400)
        {
            myButton.gameObject.SetActive(false);
            Debug.Log("deactivate...");
        }
        if (count == 1000) myButton.gameObject.SetActive(true);
        Debug.Log("active...");
    }
}
