using System;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Recourses : MonoBehaviour
{
    private RecoursesContainer currentRecourses = new RecoursesContainer();
    private RecoursesContainer recoursesPerTick = new RecoursesContainer();

    [Space] [SerializeField] public bool isPlayerControlled;
    [SerializeField] private TextMeshProUGUI moneyUI;
    [SerializeField] private TextMeshProUGUI foodUI;
    [SerializeField] private TextMeshProUGUI woodUI;
    [SerializeField] private TextMeshProUGUI mineralsUI;

    public bool CheckResources(RecoursesContainer _recoursesToCheck) =>
        currentRecourses.Money >= _recoursesToCheck.Money && currentRecourses.Food >= _recoursesToCheck.Food &&
        currentRecourses.Wood >= _recoursesToCheck.Wood &&
        currentRecourses.Minerals >= _recoursesToCheck.Minerals;

    private void Start()
    {
        FindObjectsByType<Tile>(FindObjectsSortMode.None)
            .Where(x => x.currentTileState == (isPlayerControlled ? TileState.Occupied : TileState.Enemy)).ToList()
            .ForEach(x => AddToRecoursesPerTick(x.currentTile.recoursesPerTick));
    }

    public bool TryTakeResources(RecoursesContainer _recoursesContainer)
    {
        if (currentRecourses > _recoursesContainer)
        {
            currentRecourses -= _recoursesContainer;
            UpdateUI();
            return true;
        }

        return false;
    }
    
    public void AddResources(RecoursesContainer _recourseseToAdd)
    {
        currentRecourses += _recourseseToAdd;
        UpdateUI();
    }

    /// <summary>
    /// Changes the amount of Recourses added every [tickTime]
    /// </summary>
    /// <param name="_recoursesToAdd">The amount of recourses that will be added to the recourses per tick (can be negative)</param>
    public void AddToRecoursesPerTick(RecoursesContainer _recoursesToAdd)
    {
        recoursesPerTick += _recoursesToAdd;
    }

    public void HandleTick()
    {
        AddResources(recoursesPerTick);
    }

    public void UpdateUI()
    {
        moneyUI.text = currentRecourses.Money.ToString();
        foodUI.text = currentRecourses.Food.ToString();
        woodUI.text = currentRecourses.Wood.ToString();
        mineralsUI.text = currentRecourses.Minerals.ToString();
    }
}