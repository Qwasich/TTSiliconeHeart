using UnityEngine;
using UnityEngine.Tilemaps;

namespace TTSH.Building
{
    public class TargetTilemapAdapter : MonoBehaviour
    {
        [Tooltip("Целевой тайлмап, с котороым будем сравнивать и брать характеристики")]
        [SerializeField] private Tilemap m_TargetTilemap;
        [Tooltip("Дополнительный вектор, добавляемый к позиции мыши.")]
        [SerializeField] private Vector2 m_SnappingOffset;

        /// <summary>
        /// Возвращает вектор клетки, ближайшей к нашей мышке
        /// </summary>
        /// <param name="inputPos">Входной вектор, например позиция мыши</param>
        /// <returns>Вектор Клетки</returns>
        public Vector2 SnapVectorToGrid(Vector2 inputPos)
        {
            //Vector2 snapPos = (Vector2Int)m_TargetTilemap.WorldToCell(inputPos) + m_SnappingOffset;
            float x = (Mathf.Floor((inputPos.x + m_SnappingOffset.x) / m_TargetTilemap.cellSize.x) + 0.5f) * m_TargetTilemap.cellSize.x - (m_SnappingOffset.x / m_TargetTilemap.cellSize.x);
            float y = (Mathf.Floor((inputPos.y + m_SnappingOffset.y) / m_TargetTilemap.cellSize.y) + 0.5f) * m_TargetTilemap.cellSize.y - (m_SnappingOffset.y / m_TargetTilemap.cellSize.y);

            return new(x, y);
        }
    }
}
