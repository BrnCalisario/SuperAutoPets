namespace SuperAutoPets;

public interface IEffect
{
    string EffectLog { get; }
}

public interface ISellEffect : IEffect
{
    void Apply(SellArgs args);
}

public interface IHurtEffect : IEffect
{
    void Apply(FightArgs args);
}

public interface IAttackEffect : IEffect
{
    void Apply(FightArgs args);
}

public interface IShop : IEffect
{
    void Apply(ShopArgs args);
}
