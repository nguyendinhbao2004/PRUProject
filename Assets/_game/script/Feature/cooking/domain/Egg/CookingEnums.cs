using UnityEngine;

public class CookingEnums
{
    public enum EggState
    {
        InBasket,       // Ở trong rổ
        MovingToPan,    // Đang bay tới chảo
        Cooking,        // Đang chiên (sống)
        MovingToPlate,  // Đang bay ra đĩa
        Plated          // Đã ở trên đĩa
    }
}
