using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Tratament : ProcedoreBase, IProcedores
    {
        public Tratament(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
