using Portname.CDGamesTestTask;
using UnityEngine;
using UnityEngine.UI;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Slider))]
    [DisallowMultipleComponent]
    public class SliderHeightBuild : MonoBehaviour
    {
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        private Slider _slider;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public float Value()
        {
            return Mathf.Lerp(_minValue, _maxValue, _slider.value);
        }
        public void ResetValue()
        {
            _slider.value = 0.5f;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
}