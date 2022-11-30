public abstract class BasePlace
{
    public readonly Vector2D m_position;
    public float moneyChangingRate;

    public BasePlace(Vector2D position, float moneyChangingRate)
    {
        m_position = position;
        this.moneyChangingRate = moneyChangingRate;
    }
}