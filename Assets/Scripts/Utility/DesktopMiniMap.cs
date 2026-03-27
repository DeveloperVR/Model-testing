using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopMiniMap : MonoBehaviour
{
    public GameObject MiniMap;
    public RenderTexture miniMapTexture;
    public List<Sprite> Surface1Clues;
    private bool isPCPlayer;

    public void ActivateMiniMap()
    {
        MiniMap.SetActive(true);
    }

    public void SetMiniMapSprite()
    {
        MiniMap.GetComponent<RawImage>().texture = miniMapTexture;
    }

    public void SetClueSprite(int clueIndex)
    {
        if (clueIndex >= 0 && clueIndex < Surface1Clues.Count-1)
        {
            MiniMap.GetComponent<RawImage>().texture = Surface1Clues[clueIndex].texture;
        }
        else
        {
            Debug.LogWarning("Clue index out of range.");
        }
    }

    public void SetPlayerType(bool isPC)
    {
        isPCPlayer = isPC;
        if (isPCPlayer)
        {
            MiniMap.SetActive(true);
        }
        else
        {
            MiniMap.SetActive(false);
        }
    }
    
}
