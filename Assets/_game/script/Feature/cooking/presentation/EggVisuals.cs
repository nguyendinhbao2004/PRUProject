using Assets._game.script.Feature.cooking.domain;
using System.Collections;
using UnityEngine;
using static CookingEnums;

public class EggVisuals : MonoBehaviour
{
    [Header("3D Models")]
    // Kéo thả object 3D trứng sống vào đây
    [SerializeField] private GameObject _rawEggModel;
    // Kéo thả object 3D trứng chín vào đây
    [SerializeField] private GameObject _cookedEggModel;

    private void Awake()
    {
        // Đảm bảo khi mới sinh ra, các model đều tắt hết để tránh lỗi hiển thị
        if (_rawEggModel != null) _rawEggModel.SetActive(false);
        if (_cookedEggModel != null) _cookedEggModel.SetActive(false);
    }

    // Hàm di chuyển (Giữ nguyên)
    public IEnumerator MoveToTarget(Vector3 targetPosition, float speed)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    // Hàm cập nhật hiển thị theo trạng thái
    public void UpdateSpriteByState(EggState state)
    {
        // Bước 1: Tắt hết tất cả các model trước
        if (_rawEggModel != null) _rawEggModel.SetActive(false);
        if (_cookedEggModel != null) _cookedEggModel.SetActive(false);

        // Bước 2: Bật model tương ứng với trạng thái
        switch (state)
        {
            // Khi đang bay tới chảo hoặc đang nấu trên chảo -> Hiện trứng sống
            case EggState.MovingToPan:
            case EggState.Cooking:
                if (_rawEggModel != null) _rawEggModel.SetActive(true);
                break;

            // Khi đã ra đĩa -> Hiện trứng chín
            case EggState.Plated:
                if (_cookedEggModel != null) _cookedEggModel.SetActive(true);
                break;
        }
    }
}
