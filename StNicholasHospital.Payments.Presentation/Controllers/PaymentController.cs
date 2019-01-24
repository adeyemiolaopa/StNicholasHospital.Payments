using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Interface;
using StNicholasHospital.Payments.Domain.Service;
using StNicholasHospital.Payments.Persistence.Repository;
using StNicholasHospital.Payments.Presentation.Models;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace StNicholasHospital.Payments.Presentation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly string _connectionString;
        private readonly PatientService _patientService;
        private readonly PaymentService _paymentService;
        private readonly IPatientRepository _patientRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _patientRepository = new PatientRepository(_connectionString);
            _paymentRepository = new PaymentRepository(_connectionString);
            _patientService = new PatientService(_patientRepository);
            _paymentService = new PaymentService(_paymentRepository, _patientRepository);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();            
        }

        [HttpPost]
        public ActionResult Create(string id, PaymentDto payment)
        {
           try {
                var patientID = id;
                var paymentDto = _paymentService.CreatePayment(patientID, payment.Description, payment.Amount, "SYSTEM");
                return RedirectToAction("Details", "Patient", new { id = patientID });
            }
            catch (Exception) {
                return View(payment);
            }
        }

        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(string id, CalculateModel mData)
        {
            try {
                var patientID = id;
                mData.TotalPayment = _paymentService.GetTotalPaymentByPatientID(patientID, 
                                                                 mData.StartDate, mData.EndDate);
                mData.PatientID = patientID;
                return View(mData);
            }
            catch (Exception) {
                return View();
            }
        }
    }
}