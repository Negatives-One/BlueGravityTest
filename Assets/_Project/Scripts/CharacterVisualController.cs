using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterVisualController : MonoBehaviour
{
    #region References

    [SerializeField] private CharacterController characterController;
    public Animator hatAnimator;
    public Animator hairAnimator;
    public Animator clothAnimator;
    public Animator bodyAnimator;
    #endregion References

    [FormerlySerializedAs("_currentVisual")] [SerializeField] private CharacterVisualInfo currentCharacterVisual;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsSide = Animator.StringToHash("isSide");
    private static readonly int IsFront = Animator.StringToHash("isFront");
    private static readonly int IsBack = Animator.StringToHash("isBack");

    private void Update()
    {
        bodyAnimator.SetBool(IsWalking, characterController.isWalking);
        bodyAnimator.SetBool(IsSide, characterController.lastLookingDir == CharacterController.LookingDirection.Side);
        bodyAnimator.SetBool(IsFront, characterController.lastLookingDir == CharacterController.LookingDirection.Front);
        bodyAnimator.SetBool(IsBack, characterController.lastLookingDir == CharacterController.LookingDirection.Back);
        
        clothAnimator.SetBool(IsWalking, characterController.isWalking);
        clothAnimator.SetBool(IsSide, characterController.lastLookingDir == CharacterController.LookingDirection.Side);
        clothAnimator.SetBool(IsFront, characterController.lastLookingDir == CharacterController.LookingDirection.Front);
        clothAnimator.SetBool(IsBack, characterController.lastLookingDir == CharacterController.LookingDirection.Back);
        
        hairAnimator.SetBool(IsWalking, characterController.isWalking);
        hairAnimator.SetBool(IsSide, characterController.lastLookingDir == CharacterController.LookingDirection.Side);
        hairAnimator.SetBool(IsFront, characterController.lastLookingDir == CharacterController.LookingDirection.Front);
        hairAnimator.SetBool(IsBack, characterController.lastLookingDir == CharacterController.LookingDirection.Back);
        
        hatAnimator.SetBool(IsWalking, characterController.isWalking);
        hatAnimator.SetBool(IsSide, characterController.lastLookingDir == CharacterController.LookingDirection.Side);
        hatAnimator.SetBool(IsFront, characterController.lastLookingDir == CharacterController.LookingDirection.Front);
        hatAnimator.SetBool(IsBack, characterController.lastLookingDir == CharacterController.LookingDirection.Back);
    }

    [Button]
    private void PlayAnimation(string animName)
    {
        bodyAnimator.Play(animName);
        hatAnimator.Play(animName);
        hairAnimator.Play(animName);
        clothAnimator.Play(animName);
    }

    private void UpdateVisual()
    {
        hatAnimator.runtimeAnimatorController = currentCharacterVisual.hat.controller;
        hairAnimator.runtimeAnimatorController = currentCharacterVisual.hair.controller;
        clothAnimator.runtimeAnimatorController = currentCharacterVisual.cloth.controller;
    }

    public void ChangeCurrentVisual(CharacterVisualInfo characterVisualInfo)
    {
        currentCharacterVisual = characterVisualInfo;
        UpdateVisual();
    }
}
