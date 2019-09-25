using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Graft : ProcedoreBase, IProcedores
    {
        public Graft(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
