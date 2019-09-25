using ClinicControl.exceptions;
using ClinicControl.model.Clinic;
using ClinicControl.model.procedores;
using System;
using System.Collections.Generic;

namespace ClinicControl
{
    class Program
    {
        private static List<Patient> patients;
        private static List<ClinicProcedores> procedores;
        static void Main(string[] args)
        {
            patients = new List<Patient>();
            procedores = new List<ClinicProcedores>();
            CreateProcidore();

            int option = 0;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                if (option == 0) break;

                DoActionMenu(option);
                Console.ReadLine();
            } while (true);
        }

        static void DoActionMenu(int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    {
                        CreatePatient();
                    }
                    break;
                case 2:
                    {
                        GetPatientById();
                    }
                    break;
                case 3:
                    {
                        RegisterProcedore();
                    }
                    break;
                case 4:
                    {
                        Attendance();
                    }
                    break;
            }

            Console.WriteLine("Enter para voltar");
        }

        private static void Attendance()
        {
            try
            {
                GetAllPatient();
                Console.Write("Digite o código do paciente: ");
                int patientId = int.Parse(Console.ReadLine());

                Patient patient = patients.Find(p => p.Id == patientId);
                Console.Clear();

                if (patient.GetAllPatientProcedores().Count == 0)
                {
                    throw new CheckInException("O passiente não está cadastrado em nenhum procedimento!");
                }
                else
                {
                    Console.WriteLine($"{patient.Name} está cadastrada nos sequintes procedimentos: ");
                    foreach (var procedore in patient.GetAllPatientProcedores())
                    {
                        Console.WriteLine($"{procedore.Id} -    {procedore.Name}");
                    }
                    Console.WriteLine("0 -    Sair");
                    Console.Write("Digite o código do procedimento a ser realizado: ");

                    int procedoreId = int.Parse(Console.ReadLine());

                    if (procedoreId != 0)
                    {
                        Console.Clear();
                        ClinicProcedores attendance = procedores.Find(cP => cP.Id == procedoreId);
                        patient.ProcedoreAttended(attendance);
                        Console.WriteLine($"{patient.Name} realizou o {attendance.Name} com sucesso!");
                    }
                }
            }
            catch (CheckInException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private static void GetPatientById()
        {
            GetAllPatient();
            Console.Write("Digite o código do paciente: ");
            int patientId = int.Parse(Console.ReadLine());

            Patient patient = patients.Find(p => p.Id == patientId);

            Console.Clear();
            Console.WriteLine($"Digite (C) para visualizar os atendimentos agendados por {patient.Name}, ou (R) para visualizar os procedimentos já realizados no paciente");
            string valor = Console.ReadLine().ToUpper();
            if (valor.Equals("C"))
            {
                if (patient.GetAllPatientProcedores().Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Lista de Agendamento está vazia!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{patient.Name} está cadastrada nos sequintes procedimentos: ");
                    foreach (var procedore in patient.GetAllPatientProcedores())
                    {
                        Console.WriteLine($"{procedore.Id} -    {procedore.Name}");
                    }
                }
            }
            else
            {
                if (patient.GetAllProcedoresAttended().Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Lista de atendimento está vazia!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{patient.Name} está cadastrada nos sequintes procedimentos: ");
                    foreach (var procedore in patient.GetAllProcedoresAttended())
                    {
                        Console.WriteLine($"{procedore.Id} -    {procedore.Name}");
                    }
                }
            }
        }

        private static void GetAllPatient()
        {
            foreach(var patient in patients)
            {
                Console.WriteLine($"{patient.Id} - {patient.Name}");
            }
        }

        private static void RegisterProcedore()
        {
            try
            {
                GetAllPatient();
                Console.Write("Digite o código do paciente: ");
                int patientId = int.Parse(Console.ReadLine());

                Patient patient = patients.Find(p => p.Id == patientId);
                int option = 0;
                do
                {
                    ShowProcedores();
                    option = int.Parse(Console.ReadLine());

                    if (option == 0) break;

                    ClinicProcedores procedore = procedores.Find(cP => cP.Id == option);
                    patient.RegisterProcedore(procedore);
                } while (true);
            }
            catch(CheckInException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private static void CreatePatient()
        {
            Console.WriteLine("Digite o código do paciente: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do paciente: ");
            string patientName = Console.ReadLine();

            Patient verification = patients.Find(p => p.Id == patientId);
            if (verification == null)
            {
                Patient patient = new Patient(patientId, patientName);

                Console.Clear();
                patients.Add(patient);
                Console.WriteLine($"O paciente {patient.Name}, com o código {patient.Id} foi cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"O código: {patientId}, já está cadastrado no sistema!");
            }
        }

        private static void CreateProcidore()
        {
            ClinicProcedores procedoreWhitening = new ClinicProcedores(typeof(Whitening), "Clareamento dental", 1);
            ClinicProcedores procedoreTratament = new ClinicProcedores(typeof(Tratament), "Tratamento ortodôntico", 2);
            ClinicProcedores procedoreImplant = new ClinicProcedores(typeof(Implant), "Implante", 3);
            ClinicProcedores procedoreExtraction = new ClinicProcedores(typeof(Extraction), "Extração", 4);
            ClinicProcedores procedoreGraft = new ClinicProcedores(typeof(Graft),"Enxerto gengival", 5);
            ClinicProcedores procedoreRestoration = new ClinicProcedores(typeof(Restoration), "Restauração", 6);
            ClinicProcedores procedoreChannel = new ClinicProcedores(typeof(Channel), "Canal", 7);

            procedores.Add(procedoreWhitening);
            procedores.Add(procedoreTratament);
            procedores.Add(procedoreImplant);
            procedores.Add(procedoreExtraction);
            procedores.Add(procedoreGraft);
            procedores.Add(procedoreRestoration);
            procedores.Add(procedoreChannel);
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("###### Sistema para uma clínica odontológica ######");
            Console.Write("");

            Console.WriteLine("1 - Cadastro de pacientes");
            Console.WriteLine("2 - Pesquisar por paciente");
            Console.WriteLine("3 - Cadastro de procedimentos");
            Console.WriteLine("4 - Realizar um atendimento");
            Console.WriteLine("0 - Sair");

            Console.Write("Digite uma opção: ");
        }

        static void ShowProcedores()
        {
            Console.Clear();
            Console.WriteLine("###### Selecione um dos procedimentos abaixo ######");

            foreach(var procedore in procedores)
            {
                Console.WriteLine($"{procedore.Id} -    {procedore.Name}.");
            }
            Console.WriteLine("0 -    Sair.");

            Console.Write("Digite uma opção: ");
        }
    }
}
