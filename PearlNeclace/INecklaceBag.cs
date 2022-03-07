namespace PearlNecklace
{
    public interface INecklaceBag
    {
        public INecklace this[int idx] { get; }
        public decimal Price { get; }
        int Count();
    }
}
