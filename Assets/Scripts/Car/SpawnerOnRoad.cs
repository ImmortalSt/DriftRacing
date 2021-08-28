using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOnRoad : MonoBehaviour
{
    [SerializeField] private MapLoader _map;
    [SerializeField] private float offset;

    private Transform target;

    public void SpawnOnRoad()
    {
        target = _map.transform.GetChild(0);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return null;
        transform.localEulerAngles = target.localEulerAngles;
        transform.position = target.position + target.forward * offset;
    }
}
