namespace PearlNecklace
{
    public interface INecklace
    {
        public IPearl this[int idx] { get; }
        public decimal Price { get; }

        int Count();
        int Count(PearlType type);
        void Sort();
        public int IndexOf(IPearl pearl);
    }
}
