using StNicholasHospital.Payments.Domain.Dto;
using StNicholasHospital.Payments.Domain.Interface;
using StNicholasHospital.Payments.Domain.Service;
using StNicholasHospital.Payments.Persistence.Repository;
using System.Configuration;
using System.Web.Mvc;

namespace StNicholasHospital.Payments.Presentation.Controllers
{
    public class StaffController : Controller
    {
        private readonly string _connectionString;
        private readonly StaffService _staffService;
        private readonly IStaffRepository _staffRepository;

        public StaffController() : base()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StNicholasHospitalConnString"].ConnectionString;
            _staffRepository = new StaffRepository(_connectionString);
            _staffService = new StaffService(_staffRepository);
        }

        public ActionResult Index()
        {
            try {
                var staffMembers = _staffService.GetAll();
                return View(staffMembers);
            }
            catch {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StaffDto staff)
        {
            try {
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
       
    }
}
