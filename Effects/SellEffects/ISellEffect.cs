namespace SuperAutoPets;

public interface ISellEffect : IEffect
{
    void Apply(SellArgs args);
}

public class EmptySellEffect : ISellEffect
{
    public string EffectLog => "";

    public void Apply(SellArgs args) { }
}