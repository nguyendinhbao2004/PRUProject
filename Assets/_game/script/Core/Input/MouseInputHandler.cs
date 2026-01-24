using UnityEngine;
using Core.Interfaces;

namespace Core.Inputs
{
    public class MouseInputHandler : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleClick();
            }
        }

        private void HandleClick()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Kiểm tra xem vật thể có Interface IInteractable không
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}