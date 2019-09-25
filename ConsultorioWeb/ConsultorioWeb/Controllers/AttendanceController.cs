using System;
using ConsultorioWeb.Database;
using ConsultorioWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioWeb.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View(DbContext.attendances);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendance a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                DbContext.attendances.Add(a);
                TempData["notification"] = "Procedimento agendado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            Attendance currentAttendance = GetContact(id);
            return View(currentAttendance);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Attendance a)
        {
            try
            {
                Attendance currentAttendance = GetContact(id);
                currentAttendance.Paciente = a.Paciente;
                currentAttendance.Procedimento = a.Procedimento;
                TempData["notification"] = "Paciente alterado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(Guid id)
        {
            Attendance currentPatient = GetContact(id);
            return View(currentPatient);
        }

        private Attendance GetContact(Guid id)
        {
            return DbContext.attendances.Find(c => c.Id == id);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Attendance a)
        {
            try
            {
                DbContext.attendances.Remove(GetContact(id));
                TempData["notification"] = "Atendimento realizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}