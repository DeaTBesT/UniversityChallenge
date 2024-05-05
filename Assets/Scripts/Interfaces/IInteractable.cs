namespace Interfaces
{
    public interface IInteractable
    {
        bool TryInteract(IInteractor interactor);
        void FinishInteract(bool isSuccess);
    }
}