using ClinicControl.interfaces;

namespace ClinicControl.model.procedores
{
    public class Channel : ProcedoreBase, IProcedores
    {
        public Channel(string code) : base(code)
        {

        }

        public string GetCode()
        {
            return base.code;
        }
    }
}
