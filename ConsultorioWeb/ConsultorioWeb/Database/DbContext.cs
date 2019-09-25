using ConsultorioWeb.Models;
using System.Collections.Generic;

namespace ConsultorioWeb.Database
{
    public class DbContext
    {
        public static List<Procedure> procedures = new List<Procedure>();

        public static List<Patient> patient = new List<Patient>();

        public static List<Attendance> attendances = new List<Attendance>();
    }
}
