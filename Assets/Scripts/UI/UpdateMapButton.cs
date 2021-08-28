using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMapButton : MonoBehaviour
{
    [SerializeField] private Text _seedInput;
    [SerializeField] private MapLoader _mapLoader;

    public void UpdateSeed()
    {
        if (int.TryParse(_seedInput.text, out var res))
            _mapLoader.SetSeed(res);
    }

}
