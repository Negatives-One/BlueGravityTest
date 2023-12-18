using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{
    #region References
    public Animator hatAnimator;
    public Animator hairAnimator;
    public Animator clothAnimator;
    public Animator bodyAnimator;
    #endregion References

    private VisualInfo _currentVisual;
    [SerializeField] private string currentAnimation = "StandDown";

    [Button]
    private void PlayAnimation(string animName)
    {
        currentAnimation = animName;
        bodyAnimator.Play(animName);
        hatAnimator.Play(animName);
        hairAnimator.Play(animName);
        clothAnimator.Play(animName);
    }

    private void UpdateVisual()
    {
        hatAnimator.runtimeAnimatorController = _currentVisual.hat.controller;
        hairAnimator.runtimeAnimatorController = _currentVisual.hair.controller;
        clothAnimator.runtimeAnimatorController = _currentVisual.cloth.controller;
    }

    public void ChangeCurrentVisual(VisualInfo visualInfo)
    {
        _currentVisual = visualInfo;
        UpdateVisual();
    }
}
