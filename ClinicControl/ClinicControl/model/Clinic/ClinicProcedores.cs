using System;

namespace ClinicControl.model.Clinic
{
    public class ClinicProcedores
    {
        public Type ProcedoreType { get; private set; }
        public string Name { get; private set; }
        public int Id { get; private set; }

        public ClinicProcedores(Type type, string name, int id)
        {
            this.ProcedoreType = type;
            this.Name = name;
            this.Id = id;
        }
    }
}
