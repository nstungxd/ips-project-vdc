
namespace IPS.Model
{
    public class DongBoModels
    {        
    }

    public class DongBoObjectLS
    {
        public DongBoObject DongBoObject { get; set; }
        public long LAN { get; set; }

        public DongBoObjectLS()
        {
            DongBoObject = new DongBoObject();
        }
    }

    //public class DongBoObject : IEqualityComparer<DongBoObject>
    public class DongBoObject
    {
        public string MA_DVI { get; set; }
        public long SO_ID { get; set; }
        public string MA { get; set; }
        public string SO_QD { get; set; }
        public long BT { get; set; }
        public long HANG { get; set; }
        public string MA_HT { get; set; }
        public long NAM { get; set; }
        public long DOT { get; set; }
        public string NHA { get; set; }


        #region IEqualityComparer<DongBoObject> Members

        //public bool Equals(DongBoObject x, DongBoObject y)
        //{
        //    if (x == null && y == null) return true;
        //    if (x == null)  return false;
        //    if (y == null) return false;
        //    return (x.SO_ID == y.SO_ID && x.MA_DVI == y.MA_DVI);
        //}

        //public int GetHashCode(DongBoObject obj)
        //{
        //    return obj.SO_ID.GetHashCode();
        //}

        #endregion
    }
}
