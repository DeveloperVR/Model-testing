using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkinsCounter", menuName = "ScriptableObjects/SkinsCounter", order = 1)]
public class SkinsCounter : ScriptableObject
{
    [SerializeField] private int numberOfPlayersConnected;

    public int GetNumberOfPlayersConnected()
    {
        return numberOfPlayersConnected;
    }

    public void IncrementNumberOfPlayersConnected()
    {
        numberOfPlayersConnected++;
    }
    public void DecrementNumberOfPlayersConnected()
    {
        if (numberOfPlayersConnected > 0)
        {
            numberOfPlayersConnected--;
        }
    }
    public int SetNumberOfPlayersConnected(int number)
    {
        numberOfPlayersConnected = number;
        return numberOfPlayersConnected;
    }
}