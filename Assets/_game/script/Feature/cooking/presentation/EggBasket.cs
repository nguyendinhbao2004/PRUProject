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

        // Cờ kiểm tra xem có trứng đang được rán hay không
        private bool _isCooking = false;

        public void Interact()
        {
            // Chỉ cho phép spawn trứng mới khi không có trứng đang được rán
            if (_isCooking)
            {
                Debug.Log("Đang có trứng đang được rán, vui lòng chờ!");
                return;
            }

            SpawnEgg();
        }

        private void SpawnEgg()
        {
            // Đánh dấu đang có trứng được rán
            _isCooking = true;

            // Tạo trứng ngay tại vị trí rổ
            EggController newEgg = Instantiate(_eggPrefab, transform.position, Quaternion.identity);

            // Khởi chạy logic của trứng với callback khi hoàn thành
            newEgg.Initialize(_panInstance, _plateTransform, OnEggCookingCompleted);
        }

        // Callback được gọi khi trứng đã rán xong
        private void OnEggCookingCompleted()
        {
            _isCooking = false;
            Debug.Log("Trứng đã rán xong, có thể rán trứng mới!");
        }
    }
}