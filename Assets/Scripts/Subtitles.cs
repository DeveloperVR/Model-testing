using System;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSubtitles", menuName = "ScriptableObjects/Subtitles", order = 1)]
public class SubtitlesDB : ScriptableObject
{
    [SerializeField] private String subtitlesList;
    [SerializeField] private int TimeOfDisplay;

    public string GetSubtitles { get { return subtitlesList; } }
    public int GetTimeOfDisplay { get { return TimeOfDisplay; } }

}
