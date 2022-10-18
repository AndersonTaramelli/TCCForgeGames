using Cinemachine;
using UnityEngine;

public class Cam : MonoBehaviour
{
    
    [SerializeField] private UITouchPanel touchInput;

    private Vector2 _lookInput;

    [SerializeField] private float _touchSpeedSensibilityX = 3f;
    [SerializeField] private float _touchSpeedSensibilityY = 3f;

    private string _touchXMapTo = "Mouse X";
    private string _touchYMapTo = "Mouse Y";

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }


    private float GetInputAxis(string axisName)
    {
        _lookInput = touchInput.PlayerJoystickOutputVector();

        if (axisName == _touchXMapTo)
            return _lookInput.x / _touchSpeedSensibilityX;

        if (axisName == _touchYMapTo)
            return _lookInput.y / _touchSpeedSensibilityY;

        return Input.GetAxis(axisName);
    }
}
