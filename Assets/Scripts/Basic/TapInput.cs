using UnityEngine;


namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class TapInput : MonoBehaviour
    {
        [SerializeField] private SliderHeightBuild _sliderHeightBuild;
        [SerializeField] private KeyCode _buildKey;
        [SerializeField] private float _speedResponse;

        
        private bool _build;
        private float _hieght;
        
        #region Singleton

            public static TapInput Instance { get; private set; }

            private void Awake()
            {
                if (Instance != null && Instance != this) {
                    Destroy(gameObject);
                } else {
                    Instance = this;
                }
            }

        #endregion
        
        private void Update()
        {
            
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                _build = touch.phase switch
                {
                    TouchPhase.Began => true,
                    TouchPhase.Ended => false,
                    _ => _build
                };
            }
            else
            {
                _build = Input.GetKey(_buildKey);
            }   
            
            if (_build)
            {
                _sliderHeightBuild.Show();
                _hieght = Mathf.Lerp(_hieght, _sliderHeightBuild.Value(), _speedResponse * Time.deltaTime);
            }
            else
            {
                _sliderHeightBuild.Hide();
                _sliderHeightBuild.ResetValue();
                _hieght = 0;
            }
        }

        public bool IsBuild()
        {
            return _build;
        }
        public float GetHieghtBuild()
        {
            return _hieght;
        }
    }
}