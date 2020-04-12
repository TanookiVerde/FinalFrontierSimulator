using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipDirection : MonoBehaviour
{
    private const float NOTACTIVE_FADE = 0.2f;
    public List<CanvasGroup> arrows;

    public void SetAxisState(Vector2 axis)
    {
        arrows[(int)ArrowType.RIGHT].alpha = axis.x > 0 ? 1f : NOTACTIVE_FADE;
        arrows[(int)ArrowType.LEFT].alpha = axis.x < 0 ? 1f : NOTACTIVE_FADE;
        arrows[(int)ArrowType.FRONT].alpha = axis.y > 0 ? 1f : NOTACTIVE_FADE;
        arrows[(int)ArrowType.BACK].alpha = axis.y < 0 ? 1f : NOTACTIVE_FADE;
    }
    public void SetVerticalState(bool up, bool down)
    {
        arrows[(int)ArrowType.UP].alpha = up ? 1f : NOTACTIVE_FADE;;
        arrows[(int)ArrowType.DOWN].alpha = down ? 1f : NOTACTIVE_FADE;;
    }
}
public enum ArrowType
{
    LEFT, RIGHT, FRONT, UP, DOWN, BACK
}
