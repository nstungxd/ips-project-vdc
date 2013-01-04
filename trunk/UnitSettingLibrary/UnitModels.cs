using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnitSettingLibrary
{
    public class ChangeResultSettings
    {
        public ChangeResult ChangeResult { get; set; }
        public string Message { get; set; }

        public ChangeResultSettings()
        {
            ChangeResult = ChangeResult.ThanhCong;
        }
    }

    public class UnitShortModel
    {        
        public string Name { get; set; }
      
        public string ValueString { get; set; }

        public int ValueInt { get; set; }
    }
}
