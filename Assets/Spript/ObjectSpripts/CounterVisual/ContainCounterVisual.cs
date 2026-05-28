using System;
using UnityEngine;

public class ContainCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField] private ContainCount _containCount;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _containCount.OnPlayerGrabbedObject += OnPlayerGrabbedObject_Animator;
    }
    private void OnPlayerGrabbedObject_Animator(object sender, EventArgs e)
    {
        _animator.SetTrigger(OPEN_CLOSE);
    }
}
