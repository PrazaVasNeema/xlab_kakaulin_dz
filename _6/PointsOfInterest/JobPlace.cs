public class JobPlace : BasePlace
{
    public JobPlace(Vector2D position, float moneyChangingRate) : base(position, moneyChangingRate);
    public void GetPromotion(float value)
    {
        moneyChangingRate += value;
    }
}