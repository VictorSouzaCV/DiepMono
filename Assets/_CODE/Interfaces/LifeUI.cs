using DiepMono.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DiepMono.UI
{
    [RequireComponent(typeof(IDamageable))]
    public class LifeUI : MonoBehaviour
    {
        [SerializeField] Canvas lifeCanvas;
        [SerializeField] Image lifeBar;
        Damageable damageable;

        void Start()
        {
            damageable = GetComponent<IDamageable>().GetDamageComponent();
            damageable.OnDamageTaken.AddListener(ReduceLife);
        }

        void ReduceLife()
        {
            if (!lifeCanvas.enabled)
                lifeCanvas.enabled = true;
            lifeBar.fillAmount = damageable.CurrentLife / damageable.MaxLife;
        }
    } 
}
