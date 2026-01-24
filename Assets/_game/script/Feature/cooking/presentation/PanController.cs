using UnityEngine;
using System.Collections;

namespace Assets._game.script.Feature.cooking.presentation
{
	public class PanController: MonoBehaviour
	{
            [SerializeField] private Transform _cookingPoint; // Điểm trứng sẽ nằm trên chảo

            // Trả về vị trí để trứng bay tới
            public Vector3 GetCookingPosition()
            {
                return _cookingPoint.position;
            }
        
    }
}