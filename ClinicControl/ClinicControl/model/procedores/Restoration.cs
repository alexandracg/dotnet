using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Restoration : ProcedoreBase, IProcedores
    {
        public Restoration(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
