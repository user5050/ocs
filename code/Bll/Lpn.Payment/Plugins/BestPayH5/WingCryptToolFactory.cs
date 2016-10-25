 
using Kulv.YCF.Payment.Wing.H5ForM; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulv.YCF.Payment.Wing
{
    public class WingCryptToolFactory
    {
        public static CryptTool GetCryptTool(bool isOld = true)
        {
            if (isOld)
            {
               
                     
                        return new CryptTool();
                
            }
            else {
                return new H5Util();
            }
        }
    }
}
