using System;
using System.Collections.Generic;
using System.Linq;
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
}
