using System.Collections;
using System.Collections.Generic;
using Kawzar.Queens.Model;
using UnityEngine;

[CreateAssetMenu]
public class CardService : ScriptableObject
{
    public CardModel[] CardModels;

    public CardModel GetRandomCardModel()
    {
        int index = Random.Range(0, CardModels.Length);
        return CardModels[index];
    }
}
