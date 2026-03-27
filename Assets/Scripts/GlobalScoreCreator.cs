using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreCounter", menuName = "ScriptableObjects/ScoreCounter", order = 1)]
public class GlobalScoreCreator : ScriptableObject
{
    private int TreasureOnScreen;
    private int TreasurePicked;
    public int GetTreasureOnScreen()
    {
        return TreasureOnScreen;
    }

    public void SetTreasureOnScreen(int number)
    {
        TreasureOnScreen = number;
    }

    public void IncrementTreasureOnScreen()
    {
        TreasureOnScreen++;
    }
    public void DecrementTreasureOnScreen()
    {
        if (TreasureOnScreen > 0)
        {
            TreasureOnScreen--;
        }
    }
    public int GetTreasurePicked()
    {
        return TreasurePicked;
    }

    public void SetTreasurePicked(int number)
    {
        TreasurePicked = number;
    }
    public void IncrementTreasurePicked()
    {
        TreasurePicked++;
    }
    public void DecrementTreasurePicked()
    {
        if (TreasurePicked > 0)
        {
            TreasurePicked--;
        }
    }
}
