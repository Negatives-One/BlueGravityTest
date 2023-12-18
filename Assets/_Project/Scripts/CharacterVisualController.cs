using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{
    #region References
    public Animator hatRenderer;
    public Animator hairRenderer;
    public Animator clothRenderer;
    #endregion References

    private VisualInfoSO currentVisual;
    [SerializeField] private string currentAnimation;
    private void Start()
    {

    }

    private void Update()
    {

    }

    private void UpdateVisual()
    {
        hatRenderer.runtimeAnimatorController = currentVisual.hat.controller;
        hairRenderer.runtimeAnimatorController = currentVisual.hair.controller;
        clothRenderer.runtimeAnimatorController = currentVisual.cloth.controller;
    }

    public void ChangeCurrentVisual(VisualInfoSO visualInfo)
    {
        currentVisual = visualInfo;
        UpdateVisual();
    }
}
