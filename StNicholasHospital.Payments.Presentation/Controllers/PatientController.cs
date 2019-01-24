using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Interface;
using StNicholasHospital.Payments.Domain.Service;
using StNicholasHospital.Payments.Persistence.Repository;
using StNicholasHospital.Payments.Presentation.App_Helper;
using StNicholasHospital.Payments.Presentation.Models;
using System.Configuration;
using System.Web.Mvc;

namespace StNicholasHospital.Payments.Presentation.Controllers
{
    public class PatientController : Controller
    {
        private readonly string _connectionString;
        private readonly PatientService _patientService;
        private readonly PaymentService _paymentService;
        private readonly IPatientRepository _patientRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PatientController() : base()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _patientRepository = new PatientRepository(_connectionString);
            _paymentRepository = new PaymentRepository(_connectionString);
            _patientService = new PatientService(_patientRepository);
            _paymentService = new PaymentService(_paymentRepository, _patientRepository);
        }

        public ActionResult Index()
        {
            try {
                var patients = _patientService.GetAll();
                return View(patients);
            }
            catch (System.Exception) {
                return View();
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PatientDto patient)
        {
            try {
                //var staffID = HttpContext.User.Identity.Name;
                _patientService.CreatePatient(patient.PhoneNo, patient.Firstname, patient.Lastname, "SYSTEM", patient.Email);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            try {
                var patientID = id;
                var patient = _patientRepository.FindByID(patientID);
                var payments = _paymentService.GetPaymentsByPatientID(patientID);

                MultipleModelInOneView testModel = new MultipleModelInOneView()
                {
                    Patient = patient, Payments = payments
                };
                
                return View(testModel);
            }
            catch {
                return RedirectToAction("Index");
            }
            
        }
    }
}