using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Task.Data;
using Student_Task.Models;

namespace Student_Task.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAccessLayer;

        public StudentController()
        {
            studentDataAccessLayer = new StudentDataAccessLayer();
        }

        // GET: StudentController
        public ActionResult Index()
        {
            List<StudentModel> students = studentDataAccessLayer.GetAllStudents();

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            StudentModel student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel student)
        {
            try
            {
                // TODO: Add insert logic here  
                studentDataAccessLayer.AddStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            StudentModel student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel student)
        {
            try
            {
                // TODO: Add update logic here  
                studentDataAccessLayer.UpdateStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            StudentModel student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StudentModel student)
        {
            try
            {
                // TODO: Add delete logic here  
                studentDataAccessLayer.DeleteStudent(student.ID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
