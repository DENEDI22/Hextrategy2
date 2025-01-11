using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerFieldCursorRaycaster : MonoBehaviour
    {
        [SerializeField] private TileUIController tileUI;
        public void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                tileUI.SelectTile(hit.collider.GetComponent<Tile>());
            }
            else
            {
                tileUI.RemoveSelection();
            }
        }
    }
}