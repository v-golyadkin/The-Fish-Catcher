using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private Fish _fishPrefab;
    [SerializeField] private Fish.FishType[] _fishTypes;

    private void Awake()
    {
        for(int i = 0; i < _fishTypes.Length; i++)
        {
            int counter = 0;
            while(counter < _fishTypes[i].fishCount)
            {
                Fish fish = UnityEngine.Object.Instantiate<Fish>(_fishPrefab);
                fish.Type = _fishTypes[i];
                fish.ReserFish();
                counter++;
            }
        }
    }
}
