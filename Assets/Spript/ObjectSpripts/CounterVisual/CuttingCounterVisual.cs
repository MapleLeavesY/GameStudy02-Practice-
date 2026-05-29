using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";
    [SerializeField] private CuttingCount _cuttingCount;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _cuttingCount.OnCut += CuttingCount_Oncut;
    }
    private void CuttingCount_Oncut(object sender, EventArgs e)
    {
        _animator.SetTrigger(CUT);
    }
}
