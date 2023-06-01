namespace SuperAutoPets;


public interface IShop : IEffect
{
    void Apply(ShopArgs args);
}

public class EmptyShopEffect : IShop
{
    public string EffectLog => string.Empty;

    public void Apply(ShopArgs args) { }
}
