using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    public class NecklaceBag : INecklaceBag
    {
        List<INecklace> _bagOfNecklaces = new List<INecklace>();  
        public INecklace this[int idx] => _bagOfNecklaces[idx];
        public decimal Price
        {
            get
            {
                //_stringOfPearls.Sum(x => x.Price);
                var price = 0M;
                foreach (var p in _bagOfNecklaces)
                {
                    price += p.Price;
                }
                return price;   
            }
        }

        public int Count() => _bagOfNecklaces.Count;    

        public override string ToString()
        {
            string sRet = $"My bag had the following necklaces\n";
            int c = 0;
            foreach (var item in _bagOfNecklaces)
            {
                sRet += $"Necklace nr {++c}:\n{item}\n";
            }
            return sRet;
        }

        #region Class Factory for creating an instance filled with Random data
        internal static class Factory
        {
            internal static NecklaceBag CreateRandomNecklaceBag(int NrOfNecklaces)
            {
                var rnd = new Random();
                var necklaceBag = new NecklaceBag();
                for (int i = 0; i < NrOfNecklaces; i++)
                {
                    necklaceBag._bagOfNecklaces.Add(Necklace.Factory.CreateRandomNecklace(rnd.Next(5,50)));
                }
                return necklaceBag;    
            }
         }
        #endregion

        #region Methods for writing a neclacebag to disk
        public string Write(string filename)
        {
            string fn = fname(filename);
            using (FileStream fs = File.Create(fn))
            using (TextWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(this);
            }
            return fn;    
        }
        static string fname(string name)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            documentPath = Path.Combine(documentPath, "ADOP", "Examples");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return Path.Combine(documentPath, name);
        }
        #endregion
    }
}
