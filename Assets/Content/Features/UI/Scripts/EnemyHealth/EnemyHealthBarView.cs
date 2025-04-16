using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarView : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private Camera _camera;
    
    private void Awake()=> _camera = Camera.main;

    private void Update()
    {
        if(_camera!=null)
            transform.LookAt(transform.position + _camera.transform.forward);
    }

    public void SetHealth(float current, float max)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}
