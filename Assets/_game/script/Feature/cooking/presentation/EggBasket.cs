using Core.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets._game.script.Feature.cooking.presentation
{
    public class EggBasket : MonoBehaviour, IInteractable
    {
        [Header("References")]
        [SerializeField] private EggController _eggPrefab; // Prefab quả trứng
        [SerializeField] private PanController _panInstance; // Kéo thả cái chảo vào đây
        [SerializeField] private Transform _plateTransform;  // Kéo thả vị trí cái đĩa vào đây

        public void Interact()
        {
            SpawnEgg();
        }

        private void SpawnEgg()
        {
            // Tạo trứng ngay tại vị trí rổ
            EggController newEgg = Instantiate(_eggPrefab, transform.position, Quaternion.identity);

            // Khởi chạy logic của trứng
            newEgg.Initialize(_panInstance, _plateTransform);
        }
    }
}