using UnityEngine;

public class NPCSeller : MonoBehaviour, IInteractable
{
    [SerializeField] private StoreItemsSO myItems;
    private StoreItemsSO _changedItems;
    public void OpenStore()
    {
        _changedItems = Instantiate(myItems);
        StoreManager.Instance.CreateStoreItems(_changedItems);
    }

    public void OnInteract()
    {
        OpenStore();
    }
}
