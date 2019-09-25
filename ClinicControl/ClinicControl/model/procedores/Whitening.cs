using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Whitening : ProcedoreBase, IProcedores
    {
        public Whitening(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
