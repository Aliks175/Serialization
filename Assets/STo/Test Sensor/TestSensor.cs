using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class TestSensor : MonoBehaviour
{
    private AttitudeSensor attitudeSensor;
    private Gyroscope gyroscope;
    private Vector3 Vector3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"start");
        Invoke("Setup", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    private void Test()
    {
        //Geroscoup();
        Axemerometr();
    }

    private void Setup()
    {
        if (Gyroscope.current != null)
        {
            Debug.Log($" Active");
            gyroscope = Gyroscope.current;
            Debug.Log($" Nois {gyroscope.noisy}");
        }

        SetUpAxemerometr();
    }

    private void Geroscoup()
    {
        if (gyroscope != null)
        {
            Vector3 = gyroscope.angularVelocity.ReadValue();
            Debug.Log($"x - {Vector3.x}\t y - {Vector3.y}\t z - {Vector3.z}");

        }
        else
        {
            Debug.Log($"no Active");

        }
    }

    private void Axemerometr()
    {
        if(attitudeSensor != null)
        {
            Debug.LogError($"attitudeSensor.{attitudeSensor.attitude}");

        }
    }

    private void SetUpAxemerometr()
    {
         attitudeSensor = InputSystem.GetDevice<AndroidRotationVector>();

        if (attitudeSensor == null)
        {
            attitudeSensor = InputSystem.GetDevice<AndroidGameRotationVector>();
            if (attitudeSensor == null)
                Debug.LogError("AttitudeSensor is not available");
        }

        if (attitudeSensor != null)
            InputSystem.EnableDevice(attitudeSensor);

    }
}
