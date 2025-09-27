using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Domain;
public class MedicalAid
{
    public int MedicalAidID { get; set; }
    public int ClientID { get; set; } // Foreign key to Client
    public string MedicalAidName { get; set; }
    public string MedicalAidNumber { get; set; }
}
