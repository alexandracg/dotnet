using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Implant : ProcedoreBase, IProcedores
    {
        public Implant(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
