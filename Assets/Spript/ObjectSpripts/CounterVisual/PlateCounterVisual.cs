using System;
using System.Collections.Generic;
using UnityEngine;


public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlateCount _plateCount;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private Transform _plateVisualPrefab;
    private const float PLATE_OFFSETY = .1f;
    private List<GameObject> _plateVisualGameObjectList = new List<GameObject>();

    private void Start()
    {
        _plateCount.OnPlateSpawned += PlateCount_OnPlateSpawned;
        _plateCount.OnPlateRemoved += PlateCount_OnPlateRemoved;
    }

    private void PlateCount_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(_plateVisualPrefab, _counterTopPoint);
        plateVisualTransform.localPosition = new Vector3(0f, PLATE_OFFSETY * _plateVisualGameObjectList.Count ,0f);
        _plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
    private void PlateCount_OnPlateRemoved(object sender, EventArgs e)
    {
        GameObject plateGameObject = _plateVisualGameObjectList[_plateVisualGameObjectList.Count - 1];
        _plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }
}
