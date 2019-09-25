using System;

namespace ClinicControl.model.procedores
{
    public abstract class ProcedoreBase
    {
        protected string code;

        public ProcedoreBase(string code)
        {
            this.code = code;
        }
    }
}
