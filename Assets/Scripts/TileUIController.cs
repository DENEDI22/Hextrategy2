using System;
using System.Linq;
using DefaultNamespace.Utilities;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TileUIController : MonoBehaviour
    {
        private Tile m_selectTile;
        [SerializeField] private GameObject selectionVFX;
        [SerializeField] private Vector3 selctionOffset;
        [SerializeField] private ArcArrangement arcArrangement;
        [SerializeField] private TextMeshProUGUI tileInformation;
        [SerializeField] private float maxDistanceOfClickToCloseMenu = 3f;

        public bool IsUIMenuActive { get; private set; }

        public void SelectTile(Tile _tileToSelect)
        {
            m_selectTile = _tileToSelect;
            selectionVFX.SetActive(true);
            selectionVFX.transform.position = _tileToSelect.transform.position + selctionOffset;
        }

        public void HandleClick(InputAction.CallbackContext _ctx)
        {
            if (!_ctx.started) return;
            if (IsUIMenuActive)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (!Physics.Raycast(ray, out RaycastHit hit)) CloseMenu();
                else if (Vector3.Distance(hit.point, m_selectTile.transform.position) > maxDistanceOfClickToCloseMenu)
                    CloseMenu();
            }
            else OpenMenu();
        }

        public void RemoveSelection()
        {
            if (!IsUIMenuActive)
            {
                m_selectTile = null;
                selectionVFX.SetActive(false);
            }
        }

        public void ShowTileInformation()
        {
            tileInformation.text = string.Empty;
            tileInformation.text += "Every second \n";
            tileInformation.text += m_selectTile.currentTile.recoursesPerTick.Money != 0
                ? $"Money: {m_selectTile.currentTile.recoursesPerTick.Money} \n"
                : String.Empty;
            tileInformation.text += m_selectTile.currentTile.recoursesPerTick.Food != 0
                ? $"Food: {m_selectTile.currentTile.recoursesPerTick.Food} \n"
                : string.Empty;
            tileInformation.text += m_selectTile.currentTile.recoursesPerTick.Wood != 0
                ? $"Wood: {m_selectTile.currentTile.recoursesPerTick.Wood} \n"
                : string.Empty;
            tileInformation.text += m_selectTile.currentTile.recoursesPerTick.Minerals != 0
                ? $"Minerals: {m_selectTile.currentTile.recoursesPerTick.Minerals} \n"
                : string.Empty;
            tileInformation.text += "To occupy \n";
            if (m_selectTile.currentTileState == TileState.Neutral)
            {
                tileInformation.text += m_selectTile.currentTile.recoursesToDevelop.Money != 0
                    ? $"Money: {m_selectTile.currentTile.recoursesToDevelop.Money} \n"
                    : String.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToDevelop.Food != 0
                    ? $"Food: {m_selectTile.currentTile.recoursesToDevelop.Food} \n"
                    : string.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToDevelop.Wood != 0
                    ? $"Wood: {m_selectTile.currentTile.recoursesToDevelop.Wood} \n"
                    : string.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToDevelop.Minerals != 0
                    ? $"Minerals: {m_selectTile.currentTile.recoursesToDevelop.Minerals} \n"
                    : string.Empty;
            }
            else
            {
                tileInformation.text += m_selectTile.currentTile.recoursesToOccupy.Money != 0
                    ? $"Money: {m_selectTile.currentTile.recoursesToOccupy.Money} \n"
                    : String.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToOccupy.Food != 0
                    ? $"Food: {m_selectTile.currentTile.recoursesToOccupy.Food} \n"
                    : string.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToOccupy.Wood != 0
                    ? $"Wood: {m_selectTile.currentTile.recoursesToOccupy.Wood} \n"
                    : string.Empty;
                tileInformation.text += m_selectTile.currentTile.recoursesToOccupy.Minerals != 0
                    ? $"Minerals: {m_selectTile.currentTile.recoursesToOccupy.Minerals} \n"
                    : string.Empty;
            }
        }

        public void ShowInfoToBuild(TileInformation _tileInformation)
        {
            tileInformation.text = string.Empty;
            tileInformation.text += $"To build a {_tileInformation.tileName} you need:\n";
            tileInformation.text += _tileInformation.recoursesToDevelop.Money != 0
                ? $"Money: {_tileInformation.recoursesToDevelop.Money} \n"
                : String.Empty;
            tileInformation.text += _tileInformation.recoursesToDevelop.Food != 0
                ? $"Food: {_tileInformation.recoursesToDevelop.Food} \n"
                : string.Empty;
            tileInformation.text += _tileInformation.recoursesToDevelop.Wood != 0
                ? $"Wood: {_tileInformation.recoursesToDevelop.Wood} \n"
                : string.Empty;
            tileInformation.text += _tileInformation.recoursesToDevelop.Minerals != 0
                ? $"Minerals: {_tileInformation.recoursesToDevelop.Minerals} \n"
                : string.Empty;
            tileInformation.text += "You are going to earn every second: \n";
            tileInformation.text += _tileInformation.recoursesPerTick.Money != 0
                ? $"Money: {_tileInformation.recoursesPerTick.Money} \n"
                : String.Empty;
            tileInformation.text += _tileInformation.recoursesPerTick.Food != 0
                ? $"Food: {_tileInformation.recoursesPerTick.Food} \n"
                : string.Empty;
            tileInformation.text += _tileInformation.recoursesPerTick.Wood != 0
                ? $"Wood: {_tileInformation.recoursesPerTick.Wood} \n"
                : string.Empty;
            tileInformation.text += _tileInformation.recoursesPerTick.Minerals != 0
                ? $"Minerals: {_tileInformation.recoursesPerTick.Minerals} \n"
                : string.Empty;
        }

        public void OpenMenu()
        {
            IsUIMenuActive = true;
            ShowTileInformation();
            arcArrangement.gameObject.SetActive(true);
            arcArrangement.ClearButtons();
            if (m_selectTile.currentTileState == TileState.Occupied)
            {
                foreach (var tileInformation in m_selectTile.currentTile.availableBuildings)
                {
                    arcArrangement.AddButton(tileInformation.tileName, out Button thisButton);
                    thisButton.onClick.AddListener(() => m_selectTile.Build(tileInformation, true));
                    thisButton.onClick.AddListener(() => this.CloseMenu());
                    thisButton.GetComponent<ButtonEvents>().OnPointerEnterEvent
                        .AddListener(() => ShowInfoToBuild(tileInformation));
                    thisButton.GetComponent<ButtonEvents>().OnPointerExitEvent.AddListener(ShowTileInformation);
                }
            }
            else
            {
                arcArrangement.AddButton("Occupy", out Button thisButton);
                if (m_selectTile.neighbours.Any(x => x.currentTileState == TileState.Occupied))
                {
                    thisButton.onClick.AddListener(() => m_selectTile.Occupy(true));
                    thisButton.onClick.AddListener(() => this.CloseMenu());
                }
                else
                {
                    thisButton.interactable = false;
                }
            }
        }

        public void CloseMenu()
        {
            IsUIMenuActive = false;
            arcArrangement.gameObject.SetActive(false);
        }
    }
}