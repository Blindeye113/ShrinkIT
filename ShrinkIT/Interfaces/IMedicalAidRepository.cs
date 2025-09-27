using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Interfaces;
public interface IMedicalAidRepository
{
    void AddMedicalAid(MedicalAid medicalAid);
    void UpdateMedicalAid(MedicalAid medicalAid);
    void DeleteMedicalAid(int medicalAidID);
    MedicalAid GetMedicalAid(int medicalAidID);
    List<MedicalAid> GetAllMedicalAids();
    MedicalAid GetMedicalAidByClientId(int clientId);
}
