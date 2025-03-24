using TTSH.SaveSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TTSH.Building
{
    public class CursorToBuildingDeletion : MonoBehaviour
    {
        [Tooltip("Размер коллизии при поиске объектов на снос")]
        [SerializeField] private Vector2 m_CastingVector = new(0.2f, 0.2f);

        [SerializeField] private InputAction m_MouseLeftClick;
        [SerializeField] private InputAction m_MouseRightClick;


        #region Unity

        private void Awake()
        {
            m_MouseLeftClick.performed += ctx => DeleteBuilding(ctx);
            m_MouseRightClick.performed += ctx => CancelDeletion(ctx);
        }

        private void OnDisable()
        {
            DisableClicking();
        }
        #endregion

        private void EnableClicking()
        {
            m_MouseLeftClick.Enable();
            m_MouseRightClick.Enable();
        }

        private void DisableClicking()
        {
            m_MouseLeftClick.Disable();
            m_MouseRightClick.Disable();
        }

        /// <summary>
        /// Начать снос зданий
        /// </summary>
        public void StartDeletion() => EnableClicking();

        /// <summary>
        /// Прекратить снос зданий
        /// </summary>
        public void StopDeletion() => DisableClicking();

        private void DeleteBuilding(InputAction.CallbackContext context)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Collider2D col = Physics2D.OverlapBox(pos, m_CastingVector, 0f);
            if (col)
            {
                DestroyImmediate(col.gameObject);
                Singleton_SaveLoad.Instance.SaveAll();
                DisableClicking();
            }
        }

        private void CancelDeletion(InputAction.CallbackContext context)
        {
            DisableClicking();
        }
    }
}
