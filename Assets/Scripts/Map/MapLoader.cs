using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RenderMap))]
public class MapLoader : MonoBehaviour
{
    private RenderMap _renderMap;
    private IFieldGenerator _fieldGenerator = new FieldGenerator();
    private Field _field;
    
    private void Awake()
    {
        _renderMap = GetComponent<RenderMap>();
    }

    public void SetSeed(int newSeed)
    {
        Random.InitState(newSeed);
    }

    public void LoadRandomMap(int RoadLenght = 25)
    {
        _field = _fieldGenerator.GenerateField(RoadLenght);
        _renderMap.ClearCells();
        _renderMap.RenderCells(_field.Road, Vector3.zero);
    }

    public void LoadSaveMap()
    {
        _renderMap.ClearCells();
        _renderMap.RenderCells(FieldSceneConnector.GetField().Road, Vector3.zero);
    }

    public void SaveField()
    {
        FieldSceneConnector.SaveField(_field);
    }
}
