using System;
using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] String[] audios;
    [SerializeField] TMP_Text signaltext;
    int currentaudio = 0;
    public void signal()
    {
        currentaudio++;
        signaltext.text = audios[currentaudio];
    }
}
