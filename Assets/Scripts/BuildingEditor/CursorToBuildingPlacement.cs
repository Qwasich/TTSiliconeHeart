using TTSH.SaveSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TTSH.Building
{
    [RequireComponent(typeof(UIBuildingSelector))]
    [RequireComponent(typeof(TargetTilemapAdapter))]
    public class CursorToBuildingPlacement : MonoBehaviour
    {
        [SerializeField] private InputAction m_MouseLeftClick;
        [SerializeField] private InputAction m_MouseRightClick;
        [Tooltip("При проверке коллизии с другими постройками, на сколько следует уменьшить область проверки")]
        [SerializeField] private Vector2 m_CollisionModifier = new(0.1f, 0.1f);

        private UIBuildingSelector m_BSelector;
        private TargetTilemapAdapter m_TTAdapter;
        private GameObject m_TiedBuilding;

        #region Unity

        private void Awake()
        {
            m_BSelector = GetComponent<UIBuildingSelector>();
            m_TTAdapter = GetComponent<TargetTilemapAdapter>();
            m_MouseLeftClick.performed += ctx => PlaceBuilding(ctx);
            m_MouseRightClick.performed += ctx => CancelBuilding(ctx);
        }

        private void Update()
        {

            if (m_TiedBuilding) MoveBuildingToCursor();
        }


        private void OnDisable()
        {
            DisableClicking();
        }
        #endregion

        /// <summary>
        /// Создать здание, хранящееся в указателе
        /// </summary>
        public void CreateBuilding()
        {
            if (!m_BSelector.ChosenBuilding) return;
            m_TiedBuilding = Instantiate(m_BSelector.ChosenBuilding);
            EnableClicking();
        }

        private void MoveBuildingToCursor()
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            m_TiedBuilding.transform.position = m_TTAdapter.SnapVectorToGrid(pos);
        }

        private void PlaceBuilding(InputAction.CallbackContext context)
        {
            if (IsOverlappingBuilding()) return;
            m_TiedBuilding = null;
            Singleton_SaveLoad.Instance.SaveAll();
            DisableClicking();
        }

        private void CancelBuilding(InputAction.CallbackContext context)
        {
            DropBuilding();
        }

        /// <summary>
        /// Уничтожает постройку, которую еще не поставили
        /// </summary>
        public void DropBuilding()
        {
            if (m_TiedBuilding) Destroy(m_TiedBuilding);
            DisableClicking();
        }

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

        private bool IsOverlappingBuilding()
        {
            BoxCollider2D buildcol = m_TiedBuilding.GetComponent<BoxCollider2D>();
            Vector2 castpos = (Vector2)m_TiedBuilding.transform.position + buildcol.offset;
            Collider2D[] col = Physics2D.OverlapBoxAll(castpos, buildcol.size - m_CollisionModifier, 0f);
            if (col.Length > 1) return true;
            return false;
        }
    }
}
