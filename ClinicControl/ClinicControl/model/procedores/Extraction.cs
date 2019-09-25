using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Extraction : ProcedoreBase, IProcedores
    {
        public Extraction(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
