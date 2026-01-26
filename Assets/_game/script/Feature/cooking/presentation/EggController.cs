using Assets._game.script.Feature.cooking.domain.Egg;
using System;
using System.Collections;
using UnityEngine;
using static CookingEnums;
namespace Assets._game.script.Feature.cooking.presentation
{
	public class EggController: MonoBehaviour
	{

        [Header("Components")]
        [SerializeField] private EggVisuals _visuals;

        [Header("Settings")]
        [SerializeField] private EggConfig _config; // Cấu hình thời gian trong Inspector

        private EggEntity _eggEntity;

        // Cần tham chiếu đến Đĩa (Plate) - gán trong Inspector hoặc tìm kiếm
        [SerializeField] private Transform _plateTarget;

        // Callback khi trứng hoàn thành rán
        private Action _onCookingCompleted;

        public void Initialize(PanController pan, Transform platePosition, Action onCookingCompleted = null)
        {
            _eggEntity = new EggEntity(_config);
            _plateTarget = platePosition;
            _onCookingCompleted = onCookingCompleted;

            // Bắt đầu quy trình ngay khi được sinh ra
            StartCoroutine(CookingProcessRoutine(pan));
        }

        private IEnumerator CookingProcessRoutine(PanController pan)
        {
            // 1. Bay từ rổ đến chảo
            _eggEntity.ChangeState(EggState.MovingToPan);
            yield return _visuals.MoveToTarget(pan.GetCookingPosition(), _config.MoveSpeed);

            // 2. Đến chảo -> Hiện hình trứng sống -> Bắt đầu đếm 20s
            _eggEntity.ChangeState(EggState.Cooking);
            _visuals.UpdateSpriteByState(EggState.Cooking);

            // Chờ 20 giây (Thời gian nấu)
            yield return new WaitForSeconds(_config.CookingDuration);

            // 3. Hết 20s -> Bay sang đĩa
            _eggEntity.ChangeState(EggState.MovingToPlate);
            yield return _visuals.MoveToTarget(_plateTarget.position, _config.MoveSpeed);

            // 4. Đến đĩa -> Hoàn tất
            _eggEntity.ChangeState(EggState.Plated);
            _visuals.UpdateSpriteByState(EggState.Plated);

            // Thông báo đã hoàn thành rán
            _onCookingCompleted?.Invoke();

            // Logic game kết thúc hoặc cộng điểm ở đây...
        }
    }
}
