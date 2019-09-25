using ClinicControl.exceptions;
using System.Collections.Generic;

namespace ClinicControl.model.Clinic
{
    public class Patient
    {
        private List<ClinicProcedores> patientProcedores;
        private List<ClinicProcedores> procedoreAttended;
        public string Name { get; private set; }
        public int Id { get; private set; }

        public Patient(int id, string name)
        {
            this.Name = name;
            this.Id = id;

            patientProcedores = new List<ClinicProcedores>();
            procedoreAttended = new List<ClinicProcedores>();
        }

        public void RegisterProcedore(ClinicProcedores procedore)
        {
            bool verificationOne = patientProcedores.Contains(procedore);

            if (verificationOne == true)
            {
                throw new CheckInException("Paciente já está agendado neste procedimento!");
            }
            patientProcedores.Add(procedore);
        }

        public void ProcedoreAttended(ClinicProcedores procedore)
        {
            patientProcedores.Remove(procedore);
            procedoreAttended.Add(procedore);
        }

        public List<ClinicProcedores> GetAllPatientProcedores()
        {
            return patientProcedores;
        }

        public List<ClinicProcedores> GetAllProcedoresAttended()
        {
            return procedoreAttended;
        }
    }
}
