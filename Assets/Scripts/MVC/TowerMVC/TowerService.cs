using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TowerSO;

namespace TowerMVC
{
    public class TowerService : MonoGenericSingleton<TowerService>
    {
        [SerializeField] private List<TowerView> towerViews;
        [SerializeField] private TowerScriptableObjectList towerList;

        private TowerModel towerModel;
        private TowerView towerView;
        private TowerController towerController;
        private TowerScriptableObject tower;
        private List<TowerController> towerControllers = new List<TowerController>();

        private void Start()
        {
            CreateTowers();
        }

        private void CreateTowers()
        {
            for(int i = 0; i < towerViews.Count; i++)
            {
                CreateNewTower(i);
            }
        }

        private void CreateNewTower(int i)
        {
            tower = towerList.towers[i];
            towerView = towerViews[i];
            towerModel = new TowerModel(tower);
            towerController = new TowerController(towerModel, towerView);
            towerControllers.Add(towerController);
        }
    }
}

