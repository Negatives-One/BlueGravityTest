using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterVisualController : MonoBehaviour
{
    #region References

    [SerializeField] private CharacterController characterController;
    public Animator hatAnimator;
    public SpriteRenderer hatSpriteRenderer;
    public Image uiHatSprite;
    public Animator hairAnimator;
    public SpriteRenderer hairSpriteRenderer;
    public Image uiHairSprite;
    public Animator clothAnimator;
    public SpriteRenderer clothSpriteRenderer;
    public Image uiClothSprite;
    public Animator bodyAnimator;

    [SerializeField] private EquipableInfoSO underpants;
    #endregion References

    [FormerlySerializedAs("_currentVisual")] [SerializeField] private CharacterVisualInfoSO currentCharacterVisual;
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
        if (currentCharacterVisual.hat == null)
        {
            hatSpriteRenderer.enabled = false;
            uiHatSprite.gameObject.SetActive(false);
        }
        else
        {
            hatSpriteRenderer.enabled = true;
            uiHatSprite.gameObject.SetActive(true);
            uiHatSprite.sprite = currentCharacterVisual.hat.worldSprite;
            hatAnimator.runtimeAnimatorController = currentCharacterVisual.hat.controller;
        }
        
        if (currentCharacterVisual.hair == null)
        {
            hairSpriteRenderer.enabled = false;
            uiHairSprite.gameObject.SetActive(false);
        }
        else
        {
            hairSpriteRenderer.enabled = true;
            uiHairSprite.gameObject.SetActive(true);
            uiHairSprite.sprite = currentCharacterVisual.hair.worldSprite;
            hairAnimator.runtimeAnimatorController = currentCharacterVisual.hair.controller;
        }

        if (currentCharacterVisual.cloth == null)
        {
            clothAnimator.runtimeAnimatorController = underpants.controller;
            uiClothSprite.sprite = underpants.worldSprite;
        }
        else
        {
            clothAnimator.runtimeAnimatorController = currentCharacterVisual.cloth.controller;
            uiClothSprite.sprite = currentCharacterVisual.cloth.worldSprite;
        }
    }

    public void ChangeCurrentVisual(CharacterVisualInfoSO characterVisualInfoSo)
    {
        currentCharacterVisual = characterVisualInfoSo;
        UpdateVisual();
    }
}
