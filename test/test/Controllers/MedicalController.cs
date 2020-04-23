using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Services;

namespace test.Controllers
{
    [ApiController]
    [Route("api/prescription")]
    public class MedicalController : ControllerBase
    {

        private readonly IService _service;

        public MedicalController(IService dbService)  //wstrzykiwanie zaleznosci
        {
            _service = dbService;
        }


        [HttpGet]
        public IActionResult GetPrescriptions()
        {
            var list = new List<String>();

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select prescription.IdPrescription, prescription.Date, prescription.DueDate, Patient.LastName, Doctor.LastName FROM prescription INNER JOIN Doctor ON prescription.IdDoctor = Doctor.IdDoctor INNER JOIN Patient ON prescription.IdPatient = Patient.IdPatient";


                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var per = new Perscription();
                    var doc = new Doctor();
                    var pat = new Patient();

                    try
                    {
                        //per.IdPerscription = int.Parse(dr["IdPerscription"]).ToString());
                        per.Date = DateTime.Parse(dr["Date"].ToString());
                        per.DueDate = DateTime.Parse(dr["DueDate"].ToString());
                        pat.LastName = dr["LastName"].ToString();
                        doc.LastName = dr["LastName"].ToString();
                        list.Add(per.ToString());
                        list.Add(pat.ToString());
                        list.Add(doc.ToString());
                    }
                    catch(ArgumentNullException ex)
                    {
                        return NotFound();
                    }

                }
            }
            return Ok(list);
        }
    }
}