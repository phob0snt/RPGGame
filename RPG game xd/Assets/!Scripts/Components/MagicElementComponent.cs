using System.Collections.Generic;
using UnityEngine;

public class MagicElementComponent : EntityComponent
{
    [SerializeField] private List<MagicElement> _magicElement;

    public MagicElement GetRandomElement()
    {
        if (_magicElement == null || _magicElement.Count == 0)
        {
            Debug.LogError("Magic elements list is empty");
            return null;
        }

        int randomIndex = Random.Range(0, _magicElement.Count);
        return _magicElement[randomIndex];
    }
}